﻿using SmellIt.Domain.Entities.Abstract;

namespace SmellIt.Domain.Interfaces.Abstract
{
    public interface IBaseRepositoryWithEncodedName<T> : IBaseRepository<T> where T : BaseEntityWithEncodedName
    {
        Task<T?> GetByEncodedName(string encodedName);
        Task DeleteByEncodedName(string encodedName);
    }
}
