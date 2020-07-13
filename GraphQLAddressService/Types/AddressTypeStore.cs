using GraphQLAddressService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLAddressService.Types
{
    public class AddressTypeStore
    {
        public AddressStore _baseStore;

        public AddressTypeStore(AddressStore store)
        {
            _baseStore = store;
        }

        public AddressType getAddressByUserId(int id)
        {
            return new AddressType(_baseStore.GetAddressByUserId(id));
        }

        public System.Threading.Tasks.Task<AddressType> GetAddressByUserIdAsync(int Id)
        {
            return Task.FromResult(getAddressByUserId(Id));
        }

        public AddressType getAddressById(int id)
        {
            return new AddressType(_baseStore.GetAddressById(id));            
        }

        public System.Threading.Tasks.Task<AddressType> GetAddressByIdAsync(int Id)
        {
            return Task.FromResult(getAddressById(Id));
        }


    }
}
