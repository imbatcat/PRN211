using Entities;

namespace Repositories.Interfaces
{
    public interface IAppointmentRepository : IRepositoryBase<Appointment>
    {
        public IEnumerable<Appointment> getAllDoctorAppointments(Guid doctorId);
        public bool UpdateCheckinStatus(string appointmentId);
    }
}
