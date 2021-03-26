using CointreeAPICall.Models;
using CointreeAPICall.ServicesAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CointreeAPICall.ServicesConcrete
{
    public class UserPreferenceManager : IUserPreferenceManager
    {
        private UserPreference currentUserPref;

        /// <summary>
        /// Retrieves the current user preference.
        /// Also use default coin if no preference is set
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
    }
}
