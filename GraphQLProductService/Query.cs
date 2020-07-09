using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.DataLoader;
using GraphQL.Server.Transports.AspNetCore;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using GraphQL.Utilities.Federation;

namespace GraphQLProductService
{
    public class Query
    {
        private readonly ProductsStore _store;

        public Query(ProductsStore store)
        {
            _store = store;
        }

        public Task<Product> getProduct(string id)
        {
            return _store.GetProductById(id);
        }




    }
}
