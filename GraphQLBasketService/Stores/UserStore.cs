using GraphQL;
using System.Data;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using GraphQLBasketService.Models;
using GraphQLBasketService.Types;

namespace GraphQLBasketService
{
    public class UserStore
    {
        public static User[] users = new[] {
            new User
            {
                id = "1",
                Basket = new Basket
                {
                    id = "1",               
                }
            },
            new User
            {
                id ="2",
                Basket = new Basket
                {
                    id = "2"
                }
            }
        };



       
        public System.Threading.Tasks.Task<User> GetUserById(string userid)
        {
           return Task.FromResult(users.FirstOrDefault(x => x.id == userid));
        }

    }
}