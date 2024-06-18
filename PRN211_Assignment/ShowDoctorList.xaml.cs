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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PRN211_Assignment
{
    /// <summary>
    /// Interaction logic for ShowDoctorList.xaml
    /// </summary>
    public partial class ShowDoctorList : System.Windows.Window
    {
        public ShowDoctorList()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminScreen ad = new AdminScreen();
            ad.Show();
            Close();
        }

        private void btnShowAppointment_Click(object sender, RoutedEventArgs e)
        {
            AcceptedAppointment ad = new AcceptedAppointment();
            ad.Show();
            Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //delete doctor

            //using (var dbcontext = new db())
            //{
            //    Button button = sender as Button;
            //    Doctor selected = button.CommandParameter as Doctor;
            //    staffs.Remove(selected);
            //    dbcontext.Doctor.Remove(selected);
            //    dbcontext.SaveChanges();
            //    var listUser = dbcontext.Doctor.ToList();
            //    dgDocList.ItemsSource = listUser;
            //}
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
