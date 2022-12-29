using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public interface IVendingMachine
    {
        VendingResponse AcceptCoin(InputCoin coin);
        VendingResponse SelectProduct(string code);
        IEnumerable<ItemChange> ReturnCoins();
    }
}
