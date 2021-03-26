using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CointreeAPICall.Models
{
    public class Coin
    {
        public int CoinId { get; set; }
        public String CoinSymbol { get; set; }
        public bool IsDefault { get; set; }
    }
}
