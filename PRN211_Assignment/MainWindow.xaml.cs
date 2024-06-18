using Core;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
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
        public List<AcceptedAppointmentDTO> _list { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            _list = new List<AcceptedAppointmentDTO>();
        }

        public MainWindow(List<AcceptedAppointmentDTO> list)
        {
            InitializeComponent();
            _list = list;
        }

        private void btnDocLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginForDocNAdmin Window = new LoginForDocNAdmin(_list);
            Window.Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtFullname.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Fill in your name before registering", "Error");
                return;
            }
            var newAppointment = new AcceptedAppointmentDTO
            {
                CustomerName = txtFullname.Text,
                DateCreated = DateOnly.FromDateTime(DateTime.Now)
            };
            _list.Add(newAppointment);

            MessageBox.Show("Register appointment Successfully !!!", "caption", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}