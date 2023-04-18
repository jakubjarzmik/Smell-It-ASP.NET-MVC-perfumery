using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SmellIt.Application.SmellIt.Brands.Queries.DeleteBrandByEncodedName
{
    public class DeleteBrandByEncodedNameQuery : IRequest
    {
        public string EncodedName { get; set; }

        public DeleteBrandByEncodedNameQuery(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
