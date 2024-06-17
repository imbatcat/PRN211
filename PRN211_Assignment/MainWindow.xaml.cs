using Repositories.Repos;
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

namespace PRN211_Assignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnDocLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginForDocNAdmin Window = new LoginForDocNAdmin();
            Window.Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //if (true)     if db + 1 row
            //{
            MessageBox.Show("Register appointment Succesfully !!!", "caption", MessageBoxButton.OK, MessageBoxImage.Information);
            //} else MessageBox.Show("Register appointment Succesfully !!!", "caption", MessageBoxButton.OK, MessageBoxImage.Warning);

        }

    }
}