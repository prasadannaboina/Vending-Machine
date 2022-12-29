using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class ProductInventoryData : IProductInventoryData
    {
        private static Dictionary<string, int> _productQuantities;
        public Dictionary<string, int> GetInventory()
        {
            return _productQuantities ?? (_productQuantities = new Dictionary<string, int> { { "COLA1", 2 }, { "CHIPS1", 0 }, { "CANDY1", 5 } });
        }
        public void UpdateInventory(string code)
        {
            var currentCount = _productQuantities[code];
            if (currentCount > 0)
                _productQuantities[code]--;
        }
    }
}
