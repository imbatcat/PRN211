using Core.Appointments;
using Entities;

namespace Repositories.Interfaces
{
    public interface IRequestAppointment : IRepositoryBase<AppointmentRequest>
    {
        public void saveRequestAppointment(AcceptedAppointmentDTO appointment);
        public IEnumerable<AppointmentRequest> GetAllAppointmentRequest();

        public void UpdateApprovedStatus(Guid appointmentRequestId);
    }
}
