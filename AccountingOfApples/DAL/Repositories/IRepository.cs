﻿namespace DAL.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity?> GetByIdAsync(Guid id);

    Task<IEnumerable<TEntity>> GetAllAsync();

    Task AddAsync(TEntity entity);

    void Update(TEntity entity);

    void Remove(TEntity entity);

    bool NotEmpty();

    Task<bool> ExistsAsync(Guid id);
}
