using CointreeAPICall.APICall;
using CointreeAPICall.Models;
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

        public CointreeAPICallController(IAPICallService apiCaller, ICoinService coinService)
        {
            this.apiCaller = apiCaller;
            this.coinService = coinService;
        }

        [Route("GetValue")]
        [HttpGet]
        public string GetValue()
        {
            return apiCaller.GetValue();
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
            return userPref.PreferredCoin;
        }
    }
}
