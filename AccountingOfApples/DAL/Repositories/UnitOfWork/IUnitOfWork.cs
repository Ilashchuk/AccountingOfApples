using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAppleVarietyRepository AppleVarieties { get; }
        IAreaRepository Areas { get; }
        IAreaAppleVarietyRepository AreaAppleVarieties { get; }
        IClientRepository Clients { get; }
        IForJuiceRepository ForJuices { get; }
        IOrderRepository Orders { get; }
        IOrderAppleVarietyRepository OrderAppleVarieties { get; }
        IOwnerRepository Owners { get; }
        int Complete();
    }
}
