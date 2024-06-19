using Core;
using Core.Appointments;
using Entities;
using Repositories.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IRequestAppointment : IRepositoryBase<AppointmentRequest>
    {
        public void saveRequestAppointment(AcceptedAppointmentDTO appointment);
    }
}
