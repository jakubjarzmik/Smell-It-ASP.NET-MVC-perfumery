﻿using MediatR;

namespace SmellIt.Application.SmellIt.Products.Queries.GetProductByEncodedName
{
    public class GetProductByEncodedNameQuery : IRequest<ProductDto>
    {
        public string EncodedName { get; set; }

        public GetProductByEncodedNameQuery(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}