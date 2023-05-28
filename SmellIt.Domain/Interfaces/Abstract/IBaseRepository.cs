﻿using SmellIt.Domain.Entities.Abstract;

namespace SmellIt.Domain.Interfaces.Abstract;

public interface IBaseRepository<T> : IRepository 
    where T : BaseEntity
{
    Task CreateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task CommitAsync();
    Task<int> CountAsync();
    Task<IEnumerable<T>> GetPaginatedAsync(int pageNumber, int pageSize);
}