using GraphQL;
using GraphQL.Introspection;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLAddressService.Types
{
    [GraphQLMetadata("User")]
    public class User : ObjectGraphType
    {       

        public String Id { get; set; }

        public AddressType Address { get; set; }
    }
}
