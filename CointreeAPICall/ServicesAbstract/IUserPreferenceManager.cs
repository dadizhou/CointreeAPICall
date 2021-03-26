using CointreeAPICall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CointreeAPICall.ServicesAbstract
{
    public interface IUserPreferenceManager
    {
        public void SetUserPreference(UserPreference userPref);
        public UserPreference GetUserPreference();
    }
}
