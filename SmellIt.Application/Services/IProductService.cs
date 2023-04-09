using SmellIt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmellIt.Application.Services
{
    public interface IProductService
    {
        Task Create(Product product);
    }
}
