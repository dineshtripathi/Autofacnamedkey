using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AirPotr.FizzbuzzCode.Engine.Interface;

namespace AirPotr.FizzbuzzCode.Engine.Impl
{
    public class FizzBuzzScenarioOne : IProvideFizzBuzz
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
                        scenario.Append(stringToPrint.ElementAt(0).Key + stringToPrint.ElementAt(1).Key + " ");
                    else if (value % Convert.ToInt32(stringToPrint.ElementAt(0).Value) == 0)
                        scenario.Append(stringToPrint.ElementAt(0).Key + " ");
                    else if (value % Convert.ToInt32(stringToPrint.ElementAt(1).Value) == 0)
                        scenario.Append(stringToPrint.ElementAt(1).Key + " ");
                    else
                        scenario.Append(Convert.ToString(value) + " ");
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
    }
}