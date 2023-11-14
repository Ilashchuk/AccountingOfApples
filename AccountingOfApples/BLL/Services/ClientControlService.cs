using AutoMapper;
using DAL.Models;
using DAL.Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ClientControlService : IClientControlService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ClientControlService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<ClientDTO> GetClients()
        {
            return _mapper.Map<IEnumerable<ClientDTO>>(_unitOfWork.Clients.GetAll());
        }
    }
}
