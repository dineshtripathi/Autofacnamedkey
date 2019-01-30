using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AirPotr.FizzbuzzCode.Engine.Interface;

namespace AirPotr.FizzbuzzCode.Engine.Impl
{
    public class FizzBuzzScenarioTwo : IProvideFizzBuzz
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inRange"></param>
        /// <param name="stringToPrint"></param>
        /// <returns></returns>
        public StringBuilder BuildScenarioString(int inRange, IDictionary<string, int> stringToPrint)
        {
            try
            {
                CheckRangeAndThrowException(inRange);
                StringBuilder scenario = new StringBuilder();
                for (var value = 1; value <= inRange; value++)
                {
                    if ((value % Convert.ToInt32(stringToPrint.ElementAt(0).Value) == 0) &&
                        (value % Convert.ToInt32(stringToPrint.ElementAt(1).Value) == 0))
                    {
                        GetScenarioValue(value, scenario, stringToPrint.ElementAt(3),
                            stringToPrint.ElementAt(0).Key + stringToPrint.ElementAt(1).Key);
                    }
                    else if (value % Convert.ToInt32(stringToPrint.ElementAt(0).Value) == 0)
                    {
                        GetScenarioValue(value, scenario, stringToPrint.ElementAt(3), stringToPrint.ElementAt(0).Key);
                    }
                    else if (value % Convert.ToInt32(stringToPrint.ElementAt(1).Value) == 0)
                    {
                        GetScenarioValue(value, scenario, stringToPrint.ElementAt(3), stringToPrint.ElementAt(1).Key);
                    }
                    else
                    {
                        GetScenarioValue(value, scenario, stringToPrint.ElementAt(3), Convert.ToString(value));
                    }
                }
                return scenario;
            }
            catch (Exception e)
            {
                throw new AirPotrException(new ErrorResult()
                {
                    ReasonPhrase = "Invalid Dictionary Items.Should Contain valid <Key> as string and <value> as Integer ",
                    ErrorCode = AirPotrErrorCode.InvalidItemsInDictionary
                });
            }
          
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inRange"></param>
        private static void CheckRangeAndThrowException(int inRange)
        {
            if (inRange < 3)
            {
                throw new AirPotrException(new ErrorResult()
                {
                    ReasonPhrase = "Invalid Range : Range should not be less than 3",
                    ErrorCode = AirPotrErrorCode.InvalidRange
                }, AirPotrErrorCode.InvalidRange);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="scenario"></param>
        /// <param name="stringTobeReplaced"></param>
        /// <param name="fizzbuzz"></param>
        private static void GetScenarioValue(int value, StringBuilder scenario,
            KeyValuePair<string, int> stringTobeReplaced, string fizzbuzz)
        {
            if (value.ToString().Contains(stringTobeReplaced.Value.ToString()))
            {
                scenario.Append(stringTobeReplaced.Key + " ");
            }
            else scenario.Append(fizzbuzz + " ");
        }
    }
}