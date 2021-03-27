using CointreeAPICall.Models;
using CointreeAPICall.ServicesAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CointreeAPICall.ServicesConcrete
{
    public class UserPreferenceService : IUserPreferenceService
    {
        private UserPreference currentUserPref;
        private readonly IDataService dataService;

        public UserPreferenceService(IDataService dataService)
        {
            this.dataService = dataService;
        }

        /// <summary>
        /// Retrieves the current user preference.
        /// </summary>
        /// <returns></returns>
        public UserPreference GetUserPreference()
        {
            return currentUserPref;
        }

        /// <summary>
        /// Set current preference. Just setting private variable at the stage.
        /// </summary>
        /// <param name="userPref"></param>
        public void SetUserPreference(UserPreference userPref)
        {
            currentUserPref = userPref;
        }

        /// <summary>
        /// Get the user's preferred coin. Return default coin if there's no preference.
        /// </summary>
        /// <returns></returns>
        public string GetUserPreferredCoin()
        {
            if (currentUserPref != null)
            {
                return currentUserPref.PreferredCoin;
            }
            else
            {
                var coinList = dataService.AllCoins();
                var defaultCoin = coinList.Where(c => c.IsDefault).FirstOrDefault();

                return defaultCoin.CoinSymbol;
            }
        }
    }
}
