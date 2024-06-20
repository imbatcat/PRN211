using Core;
using Core.Appointments;
using Entities;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repos
{
    public class RequestAppointmentRepository : RepositoryBase<AppointmentRequest>, IRequestAppointment
    {
        private readonly IRepositoryBase<AppointmentRequest> _repository;
        private readonly HospitalAppDbContext _context;
        public RequestAppointmentRepository()
        {
            _context = new HospitalAppDbContext();
            _repository = new RepositoryBase<AppointmentRequest>();
        }

        public IEnumerable<AppointmentRequest> GetAllAppointmentRequest()
        {
            return _context.AppointmentRequests.Where(a => a.isApproved == false).OrderBy(a => a.requestDate).ToList();
        }

        public void saveRequestAppointment(AcceptedAppointmentDTO appointment)
        {
            AppointmentRequest toAddRequestAppointment = new AppointmentRequest
            {
                appRequestId = Guid.NewGuid(),
                requestDate = appointment.DateCreated,
                isApproved = false,
                customerName = appointment.CustomerName,
            };
            _repository.Add(toAddRequestAppointment);
        }
    }
}
