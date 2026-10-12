using Logic;
using System;
using System.Collections.Generic;
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
        }

        private void DrawUnits()
        {
            var list = notebook.ListUnits();
            unit.Items.Clear();
            foreach (var item in list)
                unit.Items.Add(item);
        }

        private void listunit(object sender, MouseButtonEventArgs e)
        {
            if (unit.SelectedItem is Unit u)
            {
                EditElementWindow third = new EditElementWindow(u);
                if (third.ShowDialog() == true)
                {
                    DrawUnits();
                }
            }
        }
    }
}
