using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CointreeAPICall.Models
{
    public class CoinPriceEnquiryResponse
    {
        public decimal Ask { get; set; }
        public decimal Bid { get; set; }
        public decimal Rate { get; set; }
        public CustomerPrice PreviousPrice { get; set; }
        public List<string> Messages { get; set; } = new List<string>();
    }
}
