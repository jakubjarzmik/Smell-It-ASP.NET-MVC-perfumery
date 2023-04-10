using SmellIt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmellIt.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task Create(Product product);
    }
}
