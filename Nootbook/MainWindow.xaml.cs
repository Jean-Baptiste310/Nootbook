using Logic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Nootbook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NoteBook notebook;
        public MainWindow()
        {
            InitializeComponent();

            notebook = new NoteBook();
        }

        private void GoEditUnits(object sender, RoutedEventArgs e)
        {
            EditUnitsWindow second = new EditUnitsWindow(notebook);
            second.Show();
        }

        private void GocreateExam(object sender, RoutedEventArgs e)
        {
            Examen window = new Examen(this.notebook);
            window.ShowDialog();
        }
    }
}