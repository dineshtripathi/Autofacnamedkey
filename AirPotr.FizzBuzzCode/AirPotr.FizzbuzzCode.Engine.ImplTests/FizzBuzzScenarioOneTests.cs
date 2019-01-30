using System;
using System.Collections.Generic;
using System.Text;
using AirPotr.FizzbuzzCode.Engine.Impl;
using AirPotr.FizzbuzzCode.Engine.Interface;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace AirPotr.FizzbuzzCode.Engine.ImplTests
{
    [TestFixture]
    public class FizzBuzzScenarioOneTests
    {
        private FizzBuzzScenarioOne _fizzBuzzScenarionOne;
     

        [SetUp]
        public void Setup()
        {
            _fizzBuzzScenarionOne = new FizzBuzzScenarioOne();
        }

        [Test]
        public void Get_ScenarioOne_With_Range_of_10_And_DictonaryOfItems_And_Multiples_()
        {
            StringBuilder scenarioResult = new StringBuilder("1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz ");

            var result = _fizzBuzzScenarionOne.BuildScenarioString(10, new Dictionary<string, int>()
            {
                {"Fizz", 3},
                {"Buzz", 5},
                {"FizzBuzz", 15},
            });
            Assert.AreEqual(result.ToString(), scenarioResult.ToString());
        }
        [Test]
        public void Get_ScenarioOne_With_Range_of_20_And_DictonaryOfItems_And_Multiples_()
        {
            StringBuilder scenarioResult = new StringBuilder("1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz 16 17 Fizz 19 Buzz ");

            var result = _fizzBuzzScenarionOne.BuildScenarioString(20, new Dictionary<string, int>()
            {
                {"Fizz", 3},
                {"Buzz", 5},
                {"FizzBuzz", 15},
            });
            Assert.AreEqual(result.ToString(), scenarioResult.ToString());
        }
        [Test]
        public void Get_ScenarioOne_With_Range_of_30_And_DictonaryOfItems_And_Multiples_()
        {
            StringBuilder scenarioResult = new StringBuilder("1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz 16 17 Fizz 19 Buzz Fizz 22 23 Fizz Buzz 26 Fizz 28 29 FizzBuzz ");

            var result = _fizzBuzzScenarionOne.BuildScenarioString(30, new Dictionary<string, int>()
            {
                {"Fizz", 3},
                {"Buzz", 5},
                {"FizzBuzz", 15},
            });
            Assert.AreEqual(result.ToString(), scenarioResult.ToString());
        }
    }
}