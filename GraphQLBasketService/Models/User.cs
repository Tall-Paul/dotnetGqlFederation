using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLBasketService.Models;

namespace GraphQLBasketService
{
    [GraphQLMetadata("User")]
    public class User : ObjectGraphType
    {
   

        public string id { get; set; }

        public Basket Basket { get; set; }
    }
}
