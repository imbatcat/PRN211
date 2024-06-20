using Core.Appointments;
using Entities;
using Repositories.Interfaces;
using Repositories.Repos;
using System.Windows;

namespace PRN211_Assignment
{
    /// <summary>
    /// Interaction logic for LoginForDocNAdmin.xaml
    /// </summary>
    public partial class LoginForDocNAdmin : Window
    {
        private readonly IAccountRepository accountRepository = new AccountRepository();
        public List<AcceptedAppointmentDTO> _list { get; set; }
        public LoginForDocNAdmin(List<AcceptedAppointmentDTO> list)
        {
            InitializeComponent();
            _list = list;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please enter username and password", "Error!");
                return;
            }
            var acc = accountRepository.Login(txtUser.Text, txtPassword.Text);
            if (acc != null)
            {
                switch (acc.Discriminator)
                {
                    case "Doctor":
                        DoctorScreen window = new DoctorScreen(acc.Id);
                        window.Show();
                        Close();
                        break;
                    case "Admin":
                        AdminScreen Window = new AdminScreen();
                        //ShowDoctorList Window = new ShowDoctorList();
                        Window.Show();
                        Close();
                        //admin window
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Wrong username or password", "Error!");
            }
        }

        private void btnBackPage_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Window = new MainWindow();
            Window.Show();
            this.Close();
        }
    }
}
