using System.Collections.ObjectModel;

namespace Core.Appointments
{
    public class AcceptedAppointmentList : ObservableCollection<AcceptedAppointmentDTO>
    {
        public void AddAppointment(AcceptedAppointmentDTO appointment)
        {
            Add(appointment);
        }

    }
}
