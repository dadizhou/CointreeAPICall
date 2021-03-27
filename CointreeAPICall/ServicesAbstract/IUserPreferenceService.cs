using CointreeAPICall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CointreeAPICall.ServicesAbstract
{
    public interface IUserPreferenceService
    {
        public void SetUserPreference(UserPreference userPref);
        public UserPreference GetUserPreference();
        public string GetUserPreferredCoin();
    }
}
