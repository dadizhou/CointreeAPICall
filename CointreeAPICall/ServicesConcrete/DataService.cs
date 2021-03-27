using CointreeAPICall.Models;
using CointreeAPICall.ServicesAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CointreeAPICall.ServicesConcrete
{
    public class DataService : IDataService
    {
        /// <summary>
        /// Retrieve all coins. Hardcoded at the moment.
        /// </summary>
        /// <returns></returns>
        public List<Coin> AllCoins()
        {
            var coinList = new List<Coin>() {
                new Coin() { CoinId = 1, CoinSymbol = "BTC", IsDefault = true },
                new Coin() { CoinId = 2, CoinSymbol = "ETH", IsDefault = false },
                new Coin() { CoinId = 3, CoinSymbol = "XRP", IsDefault = false }
            };

            return coinList;
        }

        /// <summary>
        /// Retrieve endpoint to get coin price. Hardcoded at the moment.
        /// </summary>
        /// <returns></returns>
        public string CointreePriceURL()
        {
            return "https://trade.cointree.com/api/prices/aud/";
        }
    }
}
