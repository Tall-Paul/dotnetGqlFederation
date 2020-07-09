using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GraphQL;

namespace GraphQLProductService
{
   

    public class ProductsStore
    {
        public static Product[] products = new [] {
            new Product { id = "1", sku = "Keyboard-White", name = "White Keyboard", description = "A keyboard.  For typing on and that.  It's white", price = 10.99 },
            new Product { id = "2", sku = "Keyboard-Blue", name = "Blue Keyboard", description = "A keyboard.  For typing on and that.  It's blue", price = 10.99 },
            new Product { id = "3", sku = "Mouse-White", name = "White Mouse", description = "A mouse.  For moving a cursor. And clicking.  It's white", price = 5.99 },
            new Product { id = "4", sku = "Mouse-Blue", name = "Blue Mouse", description = "A mouse.  For moving a cursor. And clicking.  It's blue", price = 5.99 },
        };

        public Task<Product> Product(string id)
        {
            return GetProductById(id);
        }


        public Task<Product> GetProductById(string id)
        {
            System.Console.WriteLine("resolving product by sku");
            return Task.FromResult(products.FirstOrDefault(x => x.id == id));
        }



        public Task<IDictionary<string, Product>> GetUsersByIdAsync(IEnumerable<string> skus, CancellationToken token)
        {
            System.Console.WriteLine("resolving product by sku async");
            var list = skus.ToList();
            IDictionary<string, Product> result = products.Where(x => list.Contains(x.sku)).ToDictionary(x => x.sku, x => x);
            return Task.FromResult(result);
        }
        
    }
}
