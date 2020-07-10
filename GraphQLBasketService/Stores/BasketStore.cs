
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using GraphQLBasketService.Models;

namespace GraphQLBasketService
{
    public class BasketStore
    {
        public static Basket[] baskets = new[] {
            new Basket {
                id = "1",
                Products = new[]  {
                    new Product
                    {
                        id = "1"
                    },
                    new Product
                    {
                        id = "3"
                    },
                },
                User =  new User
                {
                    id = "1"
                }
             },
            new Basket {
                id = "2",
                Products = new[]  {
                    new Product
                    {
                        id = "4"
                    },
                    new Product
                    {
                        id = "2"
                    },
                },
                User =  new User
                {
                    id = "2"
                }
             }
        };


        public System.Threading.Tasks.Task<Basket> GetBasketById(string Id)
        {
            return Task.FromResult(baskets.FirstOrDefault(x => x.id == Id));
        }

    }
}