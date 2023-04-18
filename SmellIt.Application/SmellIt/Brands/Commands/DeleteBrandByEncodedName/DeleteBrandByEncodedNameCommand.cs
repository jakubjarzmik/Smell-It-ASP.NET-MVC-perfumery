using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SmellIt.Application.SmellIt.Brands.Commands.DeleteBrandByEncodedName
{
    public class DeleteBrandByEncodedNameCommand : IRequest
    {
        public string EncodedName { get; set; }

        public DeleteBrandByEncodedNameCommand(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
