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
            new User { id = "1", name = "Ada Lovelace", username = "@ada" },
            new User { id = "2", name = "Alan Turing", username = "@complete" }
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
            return Task.FromResult(users.FirstOrDefault(x => x.id == userId));
        }

        public Task<IDictionary<string, User>> GetUsersByIdAsync(IEnumerable<string> userIds, CancellationToken token)
        {
            var list = userIds.ToList();
            IDictionary<string, User> result = users.Where(x => list.Contains(x.id)).ToDictionary(x => x.id, x => x);
            return Task.FromResult(result);
        }
    }
}
