using Entities;
using Repositories.Interfaces;

namespace Repositories.Repos
{
    public class AppointmentRepository : RepositoryBase<Appointment>, IAppointmentRepository
    {
        private readonly IRepositoryBase<Appointment> _repository;

        public AppointmentRepository()
        {
            _repository = new RepositoryBase<Appointment>();
        }
    }
}
