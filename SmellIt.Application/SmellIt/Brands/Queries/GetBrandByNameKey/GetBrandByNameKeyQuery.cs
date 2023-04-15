using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SmellIt.Application.SmellIt.Brands.Queries.GetBrandByNameKey
{
    public class GetBrandByNameKeyQuery : IRequest<BrandDto>
    {
        public string NameKey { get; set; }

        public GetBrandByNameKeyQuery(string nameKey)
        {
            NameKey = nameKey;
        }
    }
}
