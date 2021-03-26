using CointreeAPICall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CointreeAPICall.APICall
{
    public interface ICoinService
    {
        public List<Coin> GetCoinList();
    }
}
