using Core.Appointments;
using Entities;

namespace Repositories.Interfaces
{
    public interface IAppointmentRepository : IRepositoryBase<Appointment>
    {
        public bool UpdateCheckinStatus(string appointmentId);
        public IEnumerable<Appointment> getAllDoctorAppointments(Guid doctorId);
        public void CreateAppointment(Appointment appointment); 

    }
}
