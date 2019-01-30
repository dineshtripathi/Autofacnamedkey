using System.Collections.Generic;
using System.Text;
using AirPotr.FizzbuzzCode.Engine.Impl;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace AirPotr.FizzbuzzCode.Engine.ImplTests
{
    [TestFixture]
    public class FizzBuzzScenarioThreeTests
    {
        private FizzBuzzScenarioThree _fizzBuzzScenarionThree;


        [SetUp]
        public void Setup()
        {
            _fizzBuzzScenarionThree = new FizzBuzzScenarioThree();
        }

        [Test]
        public void Get_ScenarioOne_With_Range_of_10_And_DictonaryOfItems_And_Multiples_()
        {
            StringBuilder scenarioResult = new StringBuilder("1 2 Lucky 4 Buzz Fizz 7 8 Fizz Buzz integer :5 Lucky :1 Buzz :2 Fizz :2");

            var result = _fizzBuzzScenarionThree.BuildScenarioString(10, new Dictionary<string, int>()
            {
                {"Fizz", 3},
                {"Buzz", 5},
                {"FizzBuzz", 15},
                {"Lucky",3 }
            });
            Assert.AreEqual(result.ToString(), scenarioResult.ToString());
        }
        [Test]
        public void Get_ScenarioOne_With_Range_of_20_And_DictonaryOfItems_And_Multiples_()
        {
            StringBuilder scenarioResult = new StringBuilder("1 2 Lucky 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz Lucky 14 FizzBuzz 16 17 Fizz 19 Buzz integer :10 Lucky :2 Buzz :3 Fizz :4 FizzBuzz :1");

            var result = _fizzBuzzScenarionThree.BuildScenarioString(20, new Dictionary<string, int>()
            {
                {"Fizz", 3},
                {"Buzz", 5},
                {"FizzBuzz", 15},
                {"Lucky",3 }
            });
            Assert.AreEqual(result.ToString(), scenarioResult.ToString());
        }
        [Test]
        public void Get_ScenarioOne_With_Range_of_30_And_DictonaryOfItems_And_Multiples_()
        {
            StringBuilder scenarioResult = new StringBuilder("1 2 Lucky 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz Lucky 14 FizzBuzz 16 17 Fizz 19 Buzz Fizz 22 Lucky Fizz Buzz 26 Fizz 28 29 Lucky integer :14 Lucky :4 Buzz :4 Fizz :7 FizzBuzz :1");

            var result = _fizzBuzzScenarionThree.BuildScenarioString(30, new Dictionary<string, int>()
            {
                {"Fizz", 3},
                {"Buzz", 5},
                {"FizzBuzz", 15},
                {"Lucky",3 }
            });
            Assert.AreEqual(result.ToString(), scenarioResult.ToString());
        }
    }
}