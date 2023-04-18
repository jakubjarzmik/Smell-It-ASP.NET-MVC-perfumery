using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SmellIt.Application.SmellIt.Brands.Queries.GetBrandByEncodedName
{
    public class GetBrandByEncodedNameQuery : IRequest<BrandDto>
    {
        public string EncodedName { get; set; }

        public GetBrandByEncodedNameQuery(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
