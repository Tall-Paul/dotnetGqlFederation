using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLBasketService.Types
{
    public class Contents : ObjectGraphType
    {
        public string basketId;
        public int total;
        public ProductType[] products;

    }
}
