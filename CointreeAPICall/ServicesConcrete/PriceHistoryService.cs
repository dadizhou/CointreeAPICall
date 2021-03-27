using CointreeAPICall.Models;
using CointreeAPICall.ServicesAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CointreeAPICall.ServicesConcrete
{
    public class PriceHistoryService : IPriceHistoryService
    {
        private IDictionary<string, CustomerPrice> priceHistory = new Dictionary<string, CustomerPrice>();

        /// <summary>
        /// Get the most recent customer price history for a particular coin
        /// </summary>
        /// <param name="coinSymbol"></param>
        /// <returns></returns>
        public CustomerPrice GetPreviousPrice(string coinSymbol)
        {
            var result = new CustomerPrice();
            if (priceHistory.ContainsKey(coinSymbol))
                result = priceHistory[coinSymbol];
            return result;
        }

        /// <summary>
        /// Update customer price history for coin.
        /// If it doens't exist, add a new entry.
        /// </summary>
        /// <param name="coinSymbol"></param>
        /// <param name="custPrice"></param>
        public void UpdateCustomerPrice(string coinSymbol, CustomerPrice custPrice)
        {
            if (priceHistory.ContainsKey(coinSymbol))
                priceHistory[coinSymbol] = custPrice;
            else
                priceHistory.Add(coinSymbol, custPrice);
        }
    }
}
