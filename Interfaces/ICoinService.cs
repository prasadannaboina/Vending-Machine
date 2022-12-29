using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public interface ICoinService
    {
        ValidCoin GetCoin(decimal weight, decimal diameter, decimal thickness);
    }

}
