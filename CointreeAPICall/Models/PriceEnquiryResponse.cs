using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CointreeAPICall.Models
{
    public class PriceEnquiryResponse
    {
        public decimal Ask { get; set; }
        public decimal Bid { get; set; }
        public decimal Rate { get; set; }
        public PricePercentage PriceChange { get; set; }
        public List<string> Messages { get; set; } = new List<string>();
    }
}
