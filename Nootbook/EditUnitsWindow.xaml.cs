using Logic;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Nootbook
{
    /// <summary>
    /// Logique d'interaction pour EditUnitsWindow.xaml
    /// </summary>
    public partial class EditUnitsWindow : Window
    {
        private NoteBook notebook;
        public EditUnitsWindow(NoteBook notebook)
        {
            InitializeComponent();

            this.notebook = notebook;

            DrawUnits();
            DrawModules();
        }

        private void DrawUnits()
        {
            var list = notebook.ListUnits();
            units.Items.Clear();
            foreach (var item in list)
                units.Items.Add(item);
        }

        private void listunit(object sender, MouseButtonEventArgs e)
        {
            if (units.SelectedItem is Unit u)
            {
                EditElementWindow third = new EditElementWindow(u);
                if (third.ShowDialog() == true)
                {
                    DrawUnits();
                }
            }
        }

        private void Addunit(object sender, RoutedEventArgs e)
        {
            try
            {
                Unit newUnit = new Unit();
                EditElementWindow third = new EditElementWindow(newUnit);
                if (third.ShowDialog() == true)
                {
                    notebook.AddUnit(newUnit);
                    DrawUnits();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void Removeunit(object sender, RoutedEventArgs e)
        {
            try
            {
                if (units.SelectedItem is Unit unit)
                {
                    notebook.RemoveUnit(unit);
                    DrawUnits();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void DrawModules()
        {
            Modules.Items.Clear();

    if (units.SelectedItem is Unit unit)
    {
        foreach (Logic.Module m in unit.ListModules())
        {
            Modules.Items.Add(m);
        }
    }
        }

        private void SelectUnit(object sender, SelectionChangedEventArgs e)
        {
            DrawModules();
        }

        private void Addmodule(object sender, RoutedEventArgs e)
        {
            try
            {
                if (units.SelectedItem is Unit unit)
                {
                    Logic.Module newModule = new Logic.Module();

                    EditElementWindow third = new EditElementWindow(newModule);

                    if (third.ShowDialog() == true)
                    {
                        unit.Listmodules.Add(newModule);
                        DrawModules();
                    }
                }
                else
                {
                    MessageBox.Show("Select a unit first.");
                }
                }
                catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }


        private void Removemodule(object sender, RoutedEventArgs e)
        {
            try
            {
                if (units.SelectedItem is Unit unit &&
                    Modules.SelectedItem is Logic.Module module)
                {
                    unit.Listmodules.Remove(module);
                    DrawModules();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void listmodule(object sender, MouseButtonEventArgs e)
        {
            if (Modules.SelectedItem is Logic.Module m)
            {
                EditElementWindow third = new EditElementWindow(m);

                if (third.ShowDialog() == true)
                {
                    DrawModules();
                }
            }
        }
    }
}
