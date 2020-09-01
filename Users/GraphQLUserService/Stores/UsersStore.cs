using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQLUserService
{
    public class UsersStore
    {
        public static User[] users = new[] {
            new User { Id = "1", Name = "Ada Lovelace", Username = "@ada" },
            new User { Id = "2", Name = "Alan Turing", Username = "@complete" }
        };

        public Task<User> Me()
        {
            return Task.FromResult(users[0]);
        }

        public Task<User> User(string id)
        {
            Console.WriteLine("query for User: " + id);
            return Task.FromResult(users[0]);
        }

        public Task<User> GetUserById(string userId)
        {
            return Task.FromResult(users.FirstOrDefault(x => x.Id == userId));
        }

        public Task<IDictionary<string, User>> GetUsersByIdAsync(IEnumerable<string> userIds, CancellationToken token)
        {
            var list = userIds.ToList();
            IDictionary<string, User> result = users.Where(x => list.Contains(x.Id)).ToDictionary(x => x.Id, x => x);
            return Task.FromResult(result);
        }

        public Task<User> GetUserByUsername(string username)
        {
            return Task.FromResult(users.FirstOrDefault(x => x.Username == username));
        }

    }
}

