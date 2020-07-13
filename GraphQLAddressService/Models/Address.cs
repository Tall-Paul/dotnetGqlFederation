using GraphQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLAddressService
{
    public class Address
    {
        public int Id;

        public int UserId;
      
        public string Street;

        public string Town;

        public string City;

        public string PostCode;

    }
}
