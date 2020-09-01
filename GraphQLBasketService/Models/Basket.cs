using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLBasketService.Models
{
    public class Basket
    {

        public string id { get; set; }
        public Product[] Products { get; set; }
        public User User { get; set; }

        public String subtotal {get; set;} 
    }
}
