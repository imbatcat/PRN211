using Entities;
using Repositories.Interfaces;
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
    /// Interaction logic for CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : Window
    {
        private readonly IAccountRepository _accountRepository;
        private readonly AccountRepository _accountRepository2;
        public CreateAccount()
        {
            InitializeComponent();
            _accountRepository2 = new AccountRepository();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var user=txtUser.Text;
            var fullName=txtFullname.Text;
            var email=txtEmail.Text;
            var password=passWordbox.Password;
            var dateOfBirth= dprDOB.SelectedDate.Value;
            DateOnly dateOfBirth2=DateOnly.FromDateTime(dateOfBirth);
            //if (dateOfBirth.HasValue)
            //{
            //    string formatted = dateOfBirth.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
            //}
            var cbbDis= (ComboBoxItem)cbbDiscriminator.SelectedItem;
            string discriminator = cbbDis.Content.ToString();
            var cbbGen =(ComboBoxItem)cbbGender.SelectedValue;
            string gender=cbbGen.Content.ToString();
            var cbbDep=(ComboBoxItem)cbbDepartment.SelectedItem;
            string department=cbbDep.Content.ToString();
            if(string.IsNullOrEmpty(user) 
                || string.IsNullOrEmpty(fullName)
                || string.IsNullOrEmpty(email)
                || string.IsNullOrEmpty(password)
                || cbbDiscriminator.Items.Count==0
                || cbbDepartment.Items.Count == 0)
            {
                MessageBox.Show("Please fill all the required fields");
                return;
            }
            else
            {
                Account newAcc = new Account
                {
                    Id= Guid.NewGuid(),
                    Appointments = [],
                    JoinDate = DateOnly.FromDateTime(DateTime.Now), 
                    UserName = user,
                    FullName = fullName,
                    Email = email,
                    Password = password,
                    DateOfBirth = dateOfBirth2,
                    Discriminator = discriminator,
                    Department = department,
                    IsMale = gender =="Male"?true:false,
                    };
                _accountRepository2.Create(newAcc);
            }
            ShowDoctorList sd= new ShowDoctorList();
            sd.Show();
            Close();
        }

        private void btnBackPage_Click(object sender, RoutedEventArgs e)
        {
            AcceptedAppointment acceptedAppointment = new AcceptedAppointment();
            acceptedAppointment.Show();
            Close();
        }
    }
}
