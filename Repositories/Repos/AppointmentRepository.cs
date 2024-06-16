using Entities;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repos
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly IRepositoryBase<Appointment> _repository;

        public AppointmentRepository()
        {
            _repository = new RepositoryBase<Appointment>();
        }

    }
}
