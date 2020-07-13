using GraphQL;
using GraphQL.Instrumentation;
using GraphQL.Types;
using GraphQLParser.AST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace GraphQLAddressService
{

    [GraphQLMetadata("Address")]
    public class AddressType : ObjectGraphType<Address>
    {
        public String Id { get; set; } 
        public String Address1 { get; set; }
        public String Address2 { get; set; }
        public String Address3 { get; set; }
        public String PostCode { get; set; }

        public AddressType(Address address)
        {
            Id = address.Id.ToString();
            Address1 = address.Street;
            Address2 = address.Town;
            Address3 = address.City;
            PostCode = address.PostCode;
                        
        }
       

    }
}
