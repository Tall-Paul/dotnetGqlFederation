using GraphQLBasketService.Models;
using GraphQLBasketService.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLBasketService.TypeStores
{
    public class ProductTypeStore
    {
        public static ProductPaginationType[] products = new[] {
            new ProductPaginationType
            {
                basketId = "1",
                products = new[]
                {
                    new ProductType()
                    {

                    }
                }
            }
        };


        public System.Threading.Tasks.Task<ProductPaginationType> GetContentsForId(string Id, int Count, int Offset)
        {
            
            return Task.FromResult(products.FirstOrDefault(x => x.basketId == Id));
            
        }
    }
}
