using Core;
using Repositories.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PRN211_Assignment
{
    /// <summary>
    /// Interaction logic for LoginForDocNAdmin.xaml
    /// </summary>
    public partial class LoginForDocNAdmin : Window
    {
        private readonly AccountRepository accountRepository = new AccountRepository();
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
                switch (acc.Discrimator)
                {
                    case "Doctor":
                        //doctor window
                        break;
                    case "Admin":
                        AdminScreen Window = new AdminScreen();
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
