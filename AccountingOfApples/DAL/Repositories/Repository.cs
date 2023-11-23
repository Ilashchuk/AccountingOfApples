using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly AccountOfApplesContext _dbContext;
    public Repository(AccountOfApplesContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public virtual async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Set<TEntity>().FindAsync(id);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbContext.Set<TEntity>().ToListAsync();
    }

    public async Task AddAsync(TEntity entity)
    {
        await _dbContext.Set<TEntity>().AddAsync(entity);
    }

    public void Update(TEntity entity)
    {
        _dbContext.Set<TEntity>().Local.Clear();
        
        _dbContext.Set<TEntity>().Update(entity);
    }

    public void Remove(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
    }
    public bool NotEmpty()
    {
        return _dbContext.Set<TEntity>().Any();
    }
    public async Task<bool> ExistsAsync(Guid id)
    {
        if (await _dbContext.Set<TEntity>().FindAsync(id) != null)
        {
            return true;
        }
        return false;
    }
}
