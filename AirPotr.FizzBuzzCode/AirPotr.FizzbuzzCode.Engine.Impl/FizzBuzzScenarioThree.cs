using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AirPotr.FizzbuzzCode.Engine.Interface;

namespace AirPotr.FizzbuzzCode.Engine.Impl
{
    public class FizzBuzzScenarioThree : IProvideFizzBuzz
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
                var st = FindWordOccurence(scenario);
                scenario.Append(st);

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scenario"></param>
        /// <returns></returns>
        private static string FindWordOccurence(StringBuilder scenario)
        {
            Dictionary<string, int> tempOccurenceCount = new Dictionary<string, int>();
            foreach (var s in scenario.ToString().Split(' '))
            {
                int n;
                if (!string.IsNullOrWhiteSpace(s))
                {
                    if (int.TryParse(s, out n) == true)
                    {
                        if (tempOccurenceCount.ContainsKey("integer :"))
                        {
                            tempOccurenceCount["integer :"]++;
                        }
                        else tempOccurenceCount.Add("integer :", 1);
                    }
                    else
                    {
                        if (tempOccurenceCount.ContainsKey(s + " :"))
                        {
                            tempOccurenceCount[s + " :"]++;
                        }
                        else tempOccurenceCount.Add(s + " :", 1);
                    }
                }
            }
            var st = string.Join(" ", tempOccurenceCount.Select(x => x.Key + "" + x.Value).ToArray());
            return st;
        }

        private static string CountWordOccurence(StringBuilder scenario)
        {
            int n = 0;
            var countWordOccurence = from word in scenario.ToString().Split(' ')
                group word by word
                into g
                where (int.TryParse(g.Key, out n) == false && !string.IsNullOrWhiteSpace(g.Key))
                select new {Word = g.Key, Count = g.Count()};
            var sumvalue=countWordOccurence.Sum(x => x.Count);
            var integerCount = (scenario.ToString().Split(' ').Length-1) - sumvalue;

            var st = string.Join(" ", countWordOccurence.Select(x => x.Word + " :" + x.Count).ToArray());
            return st + "Integer :" + Convert.ToString(integerCount);

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