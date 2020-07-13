using GraphQL;
using GraphQLAddressService.Models;
using GraphQLAddressService.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLAddressService
{
    public class Query
    {
        private readonly AddressTypeStore _store;

        public Query(AddressTypeStore store)
        {
            _store = store;
        }


        [GraphQLMetadata("address")]
        public Task<AddressType> getAddress(string id)
        {
            Console.WriteLine("in resolver for Address");
            return _store.GetAddressByIdAsync(int.Parse(id));
        }




    }
}
