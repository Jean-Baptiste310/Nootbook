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
    /// Logique d'interaction pour ListExamsWindow.xaml
    /// </summary>
    public partial class ListExamsWindow : Window
    {
        private Logic.NoteBook notebook;
        public ListExamsWindow(Logic.NoteBook notebook)
        {
            InitializeComponent();
            this.notebook = notebook;
            DrawExams();
            DrawAverages();
        }

        private void DrawExams()
        {
            exams.Items.Clear();
            foreach (Exam e in notebook.ListExam())
            {
                exams.Items.Add(e);
            }
        }

        private void DrawAverages()
        {
            averages.Items.Clear();

            foreach (AvgScore score in notebook.ComputeScores())
            {
                averages.Items.Add(score);
            }
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
