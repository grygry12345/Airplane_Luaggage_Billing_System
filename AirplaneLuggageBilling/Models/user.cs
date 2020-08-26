using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirplaneLuggageBilling.Models
{
    public class user
    {
        public string username { get; set; }
        public string password { get; set; }

    }

    public class userInit
    {
        public static List<user> Init()
        {
            return new List<user>
            {
                new user { username = "saLugage", password = "1234" }
            };
        }
    } 
}