using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class VendingResponse
    {
        public string Message { get; set; }
        public bool IsRejectedCoin { get; set; }
        public InputCoin RejectedCoin { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<ItemChange> Change { get; set; }
    }
}
