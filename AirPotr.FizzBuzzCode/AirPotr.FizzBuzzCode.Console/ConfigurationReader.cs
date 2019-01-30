using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPotr.FizzBuzzCode.Console
{
    public static class ConfigurationReader
    {
        public static string BuildConfigurationForScenarioOne()
        {
            NameValueCollection test = (NameValueCollection)ConfigurationManager.GetSection("genericAppSettings");

            string a = test["another"];
            return a;
        }
        public static string BuildConfigurationForScenarioTwo()
        {
            NameValueCollection test = (NameValueCollection)ConfigurationManager.GetSection("genericAppSettings");

            string a = test["another"];
            return a;
        }
        public static string BuildConfigurationForScenarioThree()
        {
            NameValueCollection test = (NameValueCollection)ConfigurationManager.GetSection("genericAppSettings");

            string a = test["another"];
            return a;
        }
    }

  
}
