using System;
using System.Collections.Generic;
using System.Drawing.Imaging.Effects;
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
    /// Logique d'interaction pour Examen.xaml
    /// </summary>
    public partial class Examen : Window
    {

        private Logic.Exam exam;

        private Logic.NoteBook notebook;
        public Examen(Logic.NoteBook nb)
        {
            InitializeComponent();
            notebook = nb;
            DrawModules();

            exam = new Logic.Exam();
            date.SelectedDate = exam.Date;
            coef.Text = exam.Coef.ToString();
            isAbsent.IsChecked = exam.IsAbsent;
            score.Text = exam.Note.ToString();
            teacher.Text = exam.Teacher;
            modules.SelectedItem = exam.Module;
        }

        private void DrawModules()
        {
            modules.Items.Clear();
            foreach(Logic.Module m in notebook.ListModules())
            {
                modules.Items.Add(m);
            }
        }

        private void Validate(object sender, RoutedEventArgs e)
        {
            try
            {
                exam.Coef = (float)Convert.ToDouble(coef.Text);
                exam.Date = date.SelectedDate.Value;
                exam.IsAbsent = isAbsent.IsChecked.Value;
                exam.Module = modules.SelectedItem as Logic.Module;
                exam.Note = (float)Convert.ToDouble(score.Text);
                exam.Teacher = teacher.Text;

                notebook.AddExam(exam);
                Close();
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }

            
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
