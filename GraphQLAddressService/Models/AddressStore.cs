using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLAddressService.Models
{
    public class AddressStore
    {
        public static Address[] addresses = new[] {
            new Address {
                Id = 1,
                UserId = 1,
                Street = "1 a street",
                Town = "some town",
                City = "Some City",
                PostCode = "BL1 6DD"
             },
             new Address {
                Id = 2,
                UserId = 2,
                Street = "2 a street",
                Town = "another town",
                City = "another City",
                PostCode = "BL1 6DD"
             },
        };

        public Address GetAddressByUserId(int UserId)
        {
            return addresses.FirstOrDefault(x => x.UserId == UserId);
        }

        public System.Threading.Tasks.Task<Address> GetAddressByUserIdAsync(int Id)
        {
            return Task.FromResult(GetAddressByUserId(Id));
        }

        public Address GetAddressById(int Id)
        {
            return addresses.FirstOrDefault(x => x.Id == Id);
        }

        public System.Threading.Tasks.Task<Address> GetAddressByIdAsync(int Id)
        {
            return Task.FromResult(GetAddressById(Id));
        }

    }
}

