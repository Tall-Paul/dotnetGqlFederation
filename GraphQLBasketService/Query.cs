using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLBasketService.Models;

namespace GraphQLBasketService
{
    public class Query : ObjectGraphType
    {
        private readonly BasketStore _store;

        public Query(BasketStore store)
        {
            _store = store;
        }

        [GraphQLMetadata("User")]
        public Task<User> GetBasketByUserId(string id)
        {
            return Task.FromResult(new User
            {
                id = id,
                Basket = new Basket
                {
                    id = "1"
                }
            });
        } 

        [GraphQLMetadata("_entities")]
        public Task<Basket> getEntities(Object Representations)
        {
            Console.WriteLine("here");
            return _store.GetBasketById("1");
            
        }
        
        [GraphQLMetadata("Basket")]
        public Task<Basket> Basket(String id)
        {
            Console.WriteLine("trying to query basket for "+id);
            return _store.GetBasketById("1");
        }

    }
}
