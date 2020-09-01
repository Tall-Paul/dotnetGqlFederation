using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLBasketService.Models;
using GraphQL.Instrumentation;
using GraphQLBasketService.TypeStores;
using System.Threading;
using GraphQL;

namespace GraphQLBasketService.Types
{
    [GraphQLMetadata("Basket")]
    public class BasketType : ObjectGraphType<Basket>
    {
        public BasketType()
        {
            ProductTypeStore productTypeStore = new ProductTypeStore();
            Field(o => o.id);
            Field(o => o.User);
            Field<ProductPaginationType,ProductPaginationType>()
                .Name("contents")
                .ResolveAsync(ctx =>
                {
                    Console.WriteLine("HERE");
                    return productTypeStore.GetContentsForId(ctx.Source.id,(int)ctx.Arguments["count"],(int)ctx.Arguments["offset"]);
                });
        }
    }
}
