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
        private readonly IAPICallService apiCaller;
        private readonly ICoinService coinService;
        private readonly IUserPreferenceManager userPrefManager;

        public CointreeAPICallController(IAPICallService apiCaller, ICoinService coinService, IUserPreferenceManager userPrefManager)
        {
            this.apiCaller = apiCaller;
            this.coinService = coinService;
            this.userPrefManager = userPrefManager;
        }

        [Route("GetValue")]
        [HttpGet]
        public string GetValue()
        {
            var currentUserPref = userPrefManager.GetUserPreference();

            if (currentUserPref == null)
                return "";

            return userPrefManager.GetUserPreference().PreferredCoin;
        }

        [Route("GetAllCoins")]
        [EnableCors("AllowEveryThing")]
        [HttpGet]
        public IEnumerable<Coin> GetAllCoins()
        {
            return coinService.GetCoinList();
        }

        [Route("SetUserPreferences")]
        [EnableCors("AllowEveryThing")]
        [HttpPost]
        public string SetUserPreferences([FromBody] UserPreference userPref)
        {
            userPrefManager.SetUserPreference(userPref);
            var currentUserPref = userPrefManager.GetUserPreference();

            if (currentUserPref == null)
                return "";

            return userPrefManager.GetUserPreference().PreferredCoin;
        }
    }
}
