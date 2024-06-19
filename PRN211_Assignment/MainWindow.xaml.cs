using Core.Appointments;
using Microsoft.IdentityModel.Tokens;
using Repositories.Interfaces;
using Repositories.Repos;
using System.Windows;

namespace PRN211_Assignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<AcceptedAppointmentDTO> _list { get; set; }
        public readonly IRequestAppointment _requestAppointmentRepository;
        public MainWindow()
        {
            InitializeComponent();
            _requestAppointmentRepository = new RequestAppointmentRepository();
            _list = new List<AcceptedAppointmentDTO>();
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
            //_list.Add(newAppointment);
            _requestAppointmentRepository.saveRequestAppointment(newAppointment);

            MessageBox.Show("Register appointment Successfully !!!", "caption", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}