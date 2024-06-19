using System.Windows;

namespace PRN211_Assignment
{
    /// <summary>
    /// Interaction logic for UpdateDoctor.xaml
    /// </summary>
    public partial class UpdateDoctor : Window
    {
        //tạo thêm database cho Doctor
        //private Doctor _doc = new Doctor();

        public UpdateDoctor()
        {
            InitializeComponent();
            //lấy database lên cho cbbDepartment sử dụng
        }

        private void btnBackPage_Click(object sender, RoutedEventArgs e)
        {
            ShowDoctorList ad = new ShowDoctorList();
            ad.Show();
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //if (_doc != null)
            //{
            //    var user = txtUSer.Text;
            //    if (string.IsNullOrWhiteSpace(user))
            //    {
            //        MessageBox.Show("Doctor's name cannot be empty.");
            //        return;
            //    }

            //    var password = txtPassword.Text;
            //    if (string.IsNullOrWhiteSpace(password))
            //    {
            //        MessageBox.Show("Password cannot be empty.");
            //        return;
            //    }

            //    var full = txtFullname.Text;
            //    if (string.IsNullOrWhiteSpace(full))
            //    {
            //        MessageBox.Show("Fulname cannot be empty.");
            //        return;
            //    }

            //    string email = txtEmail.Text;
            //    if (string.IsNullOrWhiteSpace(email))
            //    {
            //        MessageBox.Show("Email cannot be empty.");
            //        return;
            //    } else if (!(email.Contains("@") && email.Contains(".")))
            //    {
            //        MessageBox.Show("Wrong email format !");
            //        return;
            //    }

            //    var dob = dprDOB.Text;
            //    if (string.IsNullOrEmpty(dob))
            //    {
            //        MessageBox.Show("Date of birth cannot be empty.");
            //        return;
            //    }

            //    var join = dprJoinDate.Text;
            //    if (string.IsNullOrEmpty(join))
            //    {
            //        MessageBox.Show("Join date cannot be empty.");
            //        return;
            //    }

            //    bool discri = false;
            //    if (cbbDiscriminator.SelectedItem != null)
            //    {
            //        string selectedValue = cbbDiscriminator.SelectedItem.ToString();
            //        if (selectedValue.Equals("Admin"))
            //        {
            //            discri = true;
            //        }
            //        else discri = false;
            //    }

            //    bool sex = false;
            //    if (cbbGender.SelectedItem != null)
            //    {
            //        string selectedValue = cbbGender.SelectedItem.ToString();
            //        if (selectedValue.Equals("Female"))
            //        {
            //            sex = true;
            //        }
            //        else sex = false;
            //    }

            //    bool isdis = false;
            //    if (cbbIsDisabled.SelectedItem != null)
            //    {
            //        string selectedValue = cbbIsDisabled.SelectedItem.ToString();
            //        if (selectedValue.Equals("Yes"))
            //        {
            //            isdis = true;
            //        }
            //        else isdis = false;
            //    }


            //    _doc.  chỗ này chấm rồi thêm vào

            //    DialogResult = true;
            //    this.Tag = _doc;
            //    Close();
            //}
        }
    }
}
