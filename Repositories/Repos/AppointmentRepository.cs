using Entities;
using Repositories.Interfaces;

namespace Repositories.Repos
{
    public class AppointmentRepository : RepositoryBase<Appointment>, IAppointmentRepository
    {
        private readonly IRepositoryBase<Appointment> _repository;
        private readonly HospitalAppDbContext _context;
        private readonly IRequestAppointment requestAppointment;
        public AppointmentRepository()
        {
            _context = new HospitalAppDbContext();
            _repository = new RepositoryBase<Appointment>();
            requestAppointment = new RequestAppointmentRepository();
        }

        public void CreateAppointment(Appointment appointment)
        {
            _repository.Add(appointment);
            requestAppointment.UpdateApprovedStatus(appointment.appRequestId);
        }

        public IEnumerable<Appointment> getAllDoctorAppointments(Guid doctorId)
        {
            return _context.Appointments.Where(a => a.AccountId.Equals(doctorId) && a.IsCheckedUp == false).OrderBy(a => a.DateCreated);
        }

        public bool UpdateCheckinStatus(string appointmentId)
        {
            var appointment = _context.Appointments.FirstOrDefault(a => a.Id == Guid.Parse(appointmentId));
            if (appointment != null)
            {
                appointment.IsCheckedUp = true;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
