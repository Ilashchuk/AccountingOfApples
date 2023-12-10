using DAL.Data;

namespace DAL.Repositories.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AccountOfApplesContext _context;

    public UnitOfWork(AccountOfApplesContext context)
    {
        _context = context;
        AppleVarieties = new AppleVarietyRepository(_context);
        Areas = new AreaRepository(_context);
        AreaAppleVarieties = new AreaAppleVarietyRepository(_context);
        Clients = new ClientRepository(_context);
        ForJuices = new ForJuiceRepository(_context);
        Orders = new OrderRepository(_context);
        OrderAppleVarieties = new OrderAppleVarietyRepository(_context);
        Owners = new OwnerRepository(_context);
        Packagings = new PackagingRepository(_context);
    }
    
    public IAppleVarietyRepository AppleVarieties { get; private set; }

    public IAreaRepository Areas { get; private set; }

    public IAreaAppleVarietyRepository AreaAppleVarieties { get; private set;}

    public IClientRepository Clients { get; private set;}

    public IForJuiceRepository ForJuices { get; private set;}

    public IOrderRepository Orders { get; private set;}

    public IOrderAppleVarietyRepository OrderAppleVarieties { get; private set;}

    public IOwnerRepository Owners { get; private set;}

    public IPackagingRepository Packagings { get; private set;}

    public int Complete()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }

}
