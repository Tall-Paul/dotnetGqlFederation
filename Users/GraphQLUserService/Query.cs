using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLUserService
{
    public class Query
    {
        private readonly UsersStore _store;

        public Query(UsersStore store)
        {
            _store = store;
        }

        public Task<User> Me()
        {
            return _store.Me();
        }

        public Task<User> UserById(string Id)
        {
            Console.WriteLine("Querying for user: " + Id);
            return _store.GetUserById(Id);
        }

        public Task<User> UserByUsername(string username)
        {
            return _store.GetUserByUsername(username);
        }
    }
}
