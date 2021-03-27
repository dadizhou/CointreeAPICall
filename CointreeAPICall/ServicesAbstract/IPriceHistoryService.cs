using CointreeAPICall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CointreeAPICall.ServicesAbstract
{
    public interface IPriceHistoryService
    {
        public CustomerPrice GetPreviousPrice(string coinSymbol);
        public void UpdateCustomerPrice(string coinSymbol, CustomerPrice customerPrice);
    }
}
