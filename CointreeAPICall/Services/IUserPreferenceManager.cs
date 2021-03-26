using CointreeAPICall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CointreeAPICall.Services
{
    public interface IUserPreferenceManager
    {
        public string SetUserPreference(UserPreference userPref);
        public UserPreference GetUserPreference();
    }
}
