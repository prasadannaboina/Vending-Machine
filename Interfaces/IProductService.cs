using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public interface IProductService
    {
        int GetProductQuantity(string code);
        Product GetProduct(string code);
        IEnumerable<Product> GetAllProducts();
        void UpdateProductQuantity(string code);
    }
}
