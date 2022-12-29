using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Interfaces;

namespace VendingMachine
{
    public class ItemChange
    {
        public CoinType Type { get; set; }
        public int Number { get; set; }

    }
}