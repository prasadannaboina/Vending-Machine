using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class ProductData : IProductData
    {
        private static List<Product> _products;

        public IEnumerable<Product> GetProductList()
        {
            return _products ?? (_products = new List<Product>
            {
                new Product() {Code = "COLA1", Type = ProductItemType.Cola, Name = "Cola", Price = 1.00m},
                new Product() {Code = "CHIPS1", Type = ProductItemType.Chips, Name = "Chips", Price = 0.50m},
                new Product() {Code = "CANDY1", Type = ProductItemType.Candy, Name = "Candy", Price = 0.65m},
                
            });
        }
    }
}
