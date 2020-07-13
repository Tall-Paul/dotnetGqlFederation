using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLAddressService.Types
{
    public class UserTypeStore
    {
        public AddressTypeStore _addressStore;

        public UserTypeStore(AddressTypeStore addressStore)
        {
            _addressStore = addressStore;
        }

        public User getUserById(string id)
        {
            return new User
            {
                Id = id,
                Address = _addressStore.getAddressByUserId(int.Parse(id))
            };
        }

        public Task<User> getUserByIdAsync(string id)
        {
            return Task.FromResult(getUserById(id));
        }
    }
}
