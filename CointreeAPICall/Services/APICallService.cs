﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CointreeAPICall.APICall
{
    public class APICallService : IAPICallService
    {
        public string GetValue()
        {
            return $"{DateTime.Now.ToLongDateString()} {DateTime.Now.ToLongTimeString()}";
        }
    }
}
