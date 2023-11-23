namespace DAL.Repositories.UnitOfWork;

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

    IPackagingRepository Packagings { get; }

    int Complete();
}
