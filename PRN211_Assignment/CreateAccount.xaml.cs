using Entities;
using Microsoft.IdentityModel.Tokens;
using Repositories.Interfaces;
using Repositories.Repos;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PRN211_Assignment
{
    /// <summary>
    /// Interaction logic for CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : Window
    {
        private readonly IAccountRepository _accountRepository = new AccountRepository();
        public CreateAccount()
        {
            InitializeComponent();
            LoadComboboxData();
        }

        public void LoadComboboxData()
        {
            List<string> department = new List<string>
            {
                "Obstetrics and gynaecology",
                "Emergency medicine",
                "Cardiology",
                "Surgery",
                "Paediatrics"
            };

            List<string> gender = new List<string>
            {
                "Male",
                "Female"
            };

            List<string> discriminator = new List<string>
            {
                "Doctor",
                "Admin"
            };

            cbbDepartment.ItemsSource = department;
            cbbDiscriminator.ItemsSource = discriminator;
            cbbGender.ItemsSource = gender;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool isDepartmentEmpty = true; //if the Admin role was selected cbbDiscriminator will be set to false
            if(cbbDepartment.IsEnabled== false )
            {
                isDepartmentEmpty = false;
            } else
            {
                if(cbbDepartment.SelectedIndex == -1 )
                {
                    isDepartmentEmpty = true;
                }
                else
                {
                    isDepartmentEmpty = false;
                }
            }
            try
            {
                if (txtUser.Text.IsNullOrEmpty()
                    || txtFullname.Text.IsNullOrEmpty()
                    || txtEmail.Text.IsNullOrEmpty()
                    || passWordbox.Password.IsNullOrEmpty()
                    || cbbDiscriminator.SelectedItem == null
                    || dprDOB.Text.IsNullOrEmpty()
                    || isDepartmentEmpty
                    || cbbGender.SelectedItem == null)
                {
                    throw new Exception("Empty field");
                    
                } else
                {
                    if(isUsernameDuplicateCheck(txtUser.Text))
                    {
                        throw new Exception("Username duplicated");
                    }
                    if(!txtEmail.Text.Contains("@"))
                    {
                        throw new Exception("Wrong email format");
                    }
                    string department = "None"; //admin role will disable cbbDepartment leading to null value
                    if(cbbDepartment.SelectedItem != null)
                    {
                        department = cbbDepartment.SelectedItem.ToString();
                    }
                    Account newAcc = new Account
                    {
                        Id = Guid.NewGuid(),
                        JoinDate = DateOnly.FromDateTime(DateTime.Now),
                        UserName = txtUser.Text,
                        FullName = txtFullname.Text,
                        Email = txtEmail.Text,
                        Password = passWordbox.Password,
                        DateOfBirth = DateOnly.Parse(dprDOB.Text),
                        Discriminator = cbbDiscriminator.SelectedItem.ToString(),
                        Department = department,
                        IsMale = cbbGender.SelectedItem.ToString() == "Male" ? true : false,
                    };
                    _accountRepository.Add(newAcc);
                    clearBox();
                }
            }
            catch(Exception ex)
            {
                if(ex.Message.Equals("Empty field"))
                {
                    MessageBox.Show("Please fill all the required fields", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }else if(ex.Message.Equals("Username duplicated"))
                {
                    MessageBox.Show("Username duplicate please try again", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if(ex.Message.Equals("Wrong email format"))
                {
                     MessageBox.Show("Please enter email in the right format", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    MessageBox.Show("An error occurred while saving, message: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            
        }

        private void btnBackPage_Click(object sender, RoutedEventArgs e)
        {
            AcceptedAppointment acceptedAppointment = new AcceptedAppointment();
            acceptedAppointment.Show();
            Close();
        }
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void btn_acceptedApp_Click(object sender, RoutedEventArgs e)
        {
            AcceptedAppointment acceptedAppointmentWindow = new AcceptedAppointment();
            acceptedAppointmentWindow.Show();
            Close();
        }

        private void btn_showDocList_Click(object sender, RoutedEventArgs e)
        {
            ShowDoctorList showDoctorListWindow = new ShowDoctorList();
            showDoctorListWindow.Show();
            Close();
        }

        private void btn_CreateAccount_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_cusRequest_Click(object sender, RoutedEventArgs e)
        {
            AdminScreen adminScreenWindow = new AdminScreen();
            adminScreenWindow.Show();
            Close();
        }



        private void dprDOB_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = false; //not allow user to change date manually in date picker box
        }

        private void cbbDiscriminator_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbbDiscriminator.SelectedItem is string selectedRole)
            {
                if(selectedRole == "Admin")
                {
                    cbbDepartment.SelectedIndex = -1;
                    cbbDepartment.SelectedItem = "None";
                    cbbDepartment.IsEnabled = false;
                } else if(selectedRole == "Doctor")
                {
                    cbbDepartment.IsEnabled = true;
                }
            }
        }

        private void btn_ViewMedicalRecord_Click(object sender, RoutedEventArgs e)
        {
            AdminMedicalRecord adminMedicalRecord = new AdminMedicalRecord();
            adminMedicalRecord.Show();
            Close();
        }

        public bool isUsernameDuplicateCheck(string userName)
        {
            var account = _accountRepository.GetByCondition(a => a.UserName == userName);
            if(account != null)
            {
                return true;
            }
            return false;
        }

        public void clearBox()
        {
            txtEmail.Clear();
            txtFullname.Clear();
            txtUser.Clear();
            passWordbox.Clear();
            dprDOB.Text = string.Empty;
            cbbDepartment.SelectedIndex = -1;
            cbbDiscriminator.SelectedIndex = -1;
            cbbGender.SelectedIndex = -1;
        }
    }
}
