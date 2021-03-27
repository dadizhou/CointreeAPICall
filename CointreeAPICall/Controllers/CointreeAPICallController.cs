using CointreeAPICall.Models;
using CointreeAPICall.ServicesAbstract;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CointreeAPICall.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CointreeAPICallController : ControllerBase
    {
        private readonly IPriceService priceService;
        private readonly ICoinService coinService;
        private readonly IUserPreferenceService userPrefService;

        public CointreeAPICallController(IPriceService priceService, ICoinService coinService, IUserPreferenceService userPrefService)
        {
            this.priceService = priceService;
            this.coinService = coinService;
            this.userPrefService = userPrefService;
        }

        /// <summary>
        /// Supply a list of coins avaiable for the client
        /// </summary>
        /// <returns></returns>
        [Route("GetAllCoins")]
        [EnableCors("AllowEveryThing")]
        [HttpGet]
        public IEnumerable<Coin> GetAllCoins()
        {
            return coinService.GetCoinList();
        }

        /// <summary>
        /// Set user preference. Currently only accept the coin symbol
        /// </summary>
        /// <param name="userPref"></param>
        /// <returns></returns>
        [Route("SetUserPreferences")]
        [EnableCors("AllowEveryThing")]
        [HttpPost]
        public string SetUserPreferences([FromBody] UserPreference userPref)
        {
            userPrefService.SetUserPreference(userPref);
            var currentUserPref = userPrefService.GetUserPreference();

            if (currentUserPref == null)
                return "";

            return userPrefService.GetUserPreference().PreferredCoin;
        }

        /// <summary>
        /// Retrieve current coin price details
        /// </summary>
        /// <returns></returns>
        [Route("EnquireCoinPriceDetails")]
        [EnableCors("AllowEveryThing")]
        [HttpGet]
        public async Task<CoinPriceEnquiryResponse> EnquireCoinPriceDetails()
        {
            return await priceService.GetCoinPriceDetails();
        }
    }
}
