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
        private readonly IDataService dataService;

        public CoinService(IDataService dataService)
        {
            this.dataService = dataService;
        }

        /// <summary>
        /// Supplies list of coins available.
        /// </summary>
        /// <returns>List of existing coins available</returns>
        public List<Coin> GetCoinList()
        {
            return dataService.AllCoins();
        }
    }
}
