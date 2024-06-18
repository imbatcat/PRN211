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
    /// Interaction logic for AdminScreen.xaml
    /// </summary>
    public partial class AdminScreen : System.Windows.Window
    {
        public AdminScreen()
        {
            InitializeComponent();

            //show customer request ngay khi login thành công vào Admin Screen
            //using (var dbcontext = new db())
            //{
            //    var listRequest = dbcontext.Request.ToList();
            //    dtgCusRequest.ItemsSource = listRequest;
            //}
        }

        private void dtgCusRequest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //CreateAppointment CreateWindow = new CreateAppointment();
            //using (var dbcontext = new db())
            //{

            //    if (CreateWindow.ShowDialog() == true)
            //    {
            //        var newRe = CreateWindow.Tag as Appointment;
            //        app.Add(newRe);
            //        dbcontext.Appointment.Add(newRe);
            //        dbcontext.SaveChanges();
            //    }

            //    var listRe = dbcontext.Appointment.ToList();
            //    dtgCusRequest.ItemsSource = listRe;
            //}
        }

        private void btnShowAcceptedRequest_Click(object sender, RoutedEventArgs e)
        {
            AcceptedAppointment app = new AcceptedAppointment();
            app.Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
