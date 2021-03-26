using CointreeAPICall.Models;
using CointreeAPICall.ServicesAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CointreeAPICall.ServicesConcrete
{
    public class CoinService : ICoinService
    {
        /// <summary>
        /// Supplies list of coins available. Hardcoded at the moment.
        /// </summary>
        /// <returns>List of existing coins available</returns>
        public List<Coin> GetCoinList()
        {
            var coinList = new List<Coin>() {
                new Coin() { CoinId = 1, CoinSymbol = "BTC", IsDefault = false },
                new Coin() { CoinId = 2, CoinSymbol = "ETH", IsDefault = true },
                new Coin() { CoinId = 3, CoinSymbol = "XRP", IsDefault = false }
            };

            return coinList;
        }
    }
}
