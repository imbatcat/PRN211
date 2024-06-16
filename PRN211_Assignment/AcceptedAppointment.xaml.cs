using Entities;
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
    /// Interaction logic for AcceptedAppointment.xaml
    /// </summary>
    public partial class AcceptedAppointment : Window
    {

        public AcceptedAppointment()
        {
            InitializeComponent();

            //load datagrid
            //using (var dbcontext = new db())
            //{
            //    var listRequest = dbcontext.Appointment.ToList();
            //    dtgCusRequest.ItemsSource = listRequest;
            //}
        }

        private void btnBackPage_Click(object sender, object e)
        {
            AdminScreen ad = new AdminScreen();
            ad.Show();
            ad.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //UpdateAppointment CreateWindow = new UpdateAppointment();
            //using (var dbcontext = new db())
            //{

            //    if (CreateWindow.ShowDialog() == true)
            //    {
            //        var newRe = CreateWindow.Tag as Appointment;
            //        app.Add(newRe);
            //        dbcontext.Appointment.Update(newRe);
            //        dbcontext.SaveChanges();
            //    }

            //    var listRe = dbcontext.Appointment.ToList();
            //    dtgAccepted.ItemsSource = listRe;
            //}
        }
    }
}
