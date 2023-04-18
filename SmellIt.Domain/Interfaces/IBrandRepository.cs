﻿using SmellIt.Domain.Entities;

namespace SmellIt.Domain.Interfaces;
public interface IBrandRepository
{
    Task Create(Brand brand);
    Task<Brand?> GetByName(string name);
    Task<Brand?> GetByEncodedName(string encodedName);
    Task<IEnumerable<Brand>> GetAll();
    Task Commit();
}
