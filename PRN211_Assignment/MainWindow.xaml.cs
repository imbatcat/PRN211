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
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //// viết điều kiện trước (sau khi register thành công thì hiện notification succesfully)
            ////if (true)
            ////{
            //var notificationWindow = new Notification();
            //notificationWindow.Owner = Application.Current.MainWindow; // Optional: Set owner to main window
            //notificationWindow.ShowDialog();
            ////}
            MessageBox.Show("Register appointment Succesfully !!!","caption",MessageBoxButton.OK,MessageBoxImage.Information);

        }

    }
}