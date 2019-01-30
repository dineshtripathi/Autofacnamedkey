using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using AirPotr.FizzbuzzCode.Engine.Interface;
using Autofac;

namespace AirPotr.FizzBuzzCode.Console
{
    class AirPotrScenariosConsoleApp
    {
        static void Main(string[] args)
        {
            // Get DI LifetimeScope to resolve the Implementation class for an interface
            ILifetimeScope scope = AutoFacContainerConfig.RegisterLifetimeScope();

            using (var resolveEntity = scope.BeginLifetimeScope())
            {
                while (true)
                {
                    //User Input to feed the range
                    PrintIntialStep();

                    try
                    {
                        var range = System.Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(range))
                        {
                            if (Convert.ToInt32(range) < 3)
                            {
                                PrintError("Invalid Range selected \n");
                            }
                            else
                            {
                                //The three scenarios which was provided in the AirPotr Test Document
                                PrintScenarioMenu();
                                var selectedScenario = System.Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(selectedScenario))
                                {
                                    PrintError("Selection cannot be empty \n");
                                }
                                else
                                {
                                    if (Convert.ToInt32(selectedScenario) < 1 || Convert.ToInt32(selectedScenario) > 3)
                                    {
                                        PrintError("Selected Scenario should be within 1-3 \n");
                                    }
                                    else
                                    {
                                        bool ifConfigured = false;
                                        while (ifConfigured == false)
                                        {
                                            System.Console.ForegroundColor = ConsoleColor.Green;
                                            System.Console.WriteLine("\n");
                                            System.Console.ForegroundColor = ConsoleColor.Red;

                                            string scenarioInput;
                                            IProvideFizzBuzz iReturnFizzBuzz = null;
                                                // Contract for BuildingScenarioString 
                                            switch (Convert.ToInt32(selectedScenario))
                                            {
                                                case 1:

                                                    System.Console.WriteLine(
                                                        "Enter Multiples for Fizz,Buzz,FizzBuzz [ space or comma seperated values] \n");
                                                    scenarioInput = System.Console.ReadLine();
                                                    if (!string.IsNullOrWhiteSpace(scenarioInput))
                                                    {
                                                        var val = SplitCommaSpaceStrings(scenarioInput);
                                                        iReturnFizzBuzz =
                                                            resolveEntity.ResolveNamed<IProvideFizzBuzz>("ScenarioOne");
                                                            // Resolve the First Scenario implementation
                                                        var retVal = iReturnFizzBuzz
                                                            .BuildScenarioString(
                                                                Convert.ToInt32(range),
                                                                new Dictionary<string, int>()
                                                                {
                                                                    {"Fizz", Convert.ToInt32(val[0])},
                                                                    {"Buzz", Convert.ToInt32(val[1])},
                                                                    {"FizzBuzz", Convert.ToInt32(val[2])},
                                                                });
                                                        PrintBuildScenarioOutput(retVal);
                                                        PressKeyToContinue();
                                                    }
                                                    ifConfigured = true;
                                                    break;
                                                case 2:
                                                    System.Console.WriteLine(
                                                        "Enter Multiples for Fizz,Buzz,FizzBuzz and number for Lucky [ space or comma seperated values] \n");
                                                    scenarioInput = System.Console.ReadLine();
                                                    if (!string.IsNullOrWhiteSpace(scenarioInput))
                                                    {
                                                        var val = SplitCommaSpaceStrings(scenarioInput);
                                                        iReturnFizzBuzz =
                                                            resolveEntity.ResolveNamed<IProvideFizzBuzz>("ScenarioTwo");
                                                        var retVal = iReturnFizzBuzz
                                                            .BuildScenarioString(
                                                                Convert.ToInt32(range),
                                                                new Dictionary<string, int>()
                                                                {
                                                                    {"Fizz", Convert.ToInt32(val[0])},
                                                                    {"Buzz", Convert.ToInt32(val[1])},
                                                                    {"FizzBuzz", Convert.ToInt32(val[2])},
                                                                    {"Lucky", Convert.ToInt32(val[3])},
                                                                });
                                                        PrintBuildScenarioOutput(retVal);
                                                        PressKeyToContinue();
                                                    }
                                                    ifConfigured = true;
                                                    break;
                                                case 3:

                                                    System.Console.WriteLine(
                                                        "Enter Multiples for Fizz,Buzz,FizzBuzz and number for Lucky [ space or comma seperated values] and Print Occurence and number \n");
                                                    scenarioInput = System.Console.ReadLine();
                                                    if (!string.IsNullOrWhiteSpace(scenarioInput))
                                                    {
                                                        var val = SplitCommaSpaceStrings(scenarioInput);
                                                        iReturnFizzBuzz =
                                                            resolveEntity.ResolveNamed<IProvideFizzBuzz>("ScenarioThree");
                                                        var retVal = iReturnFizzBuzz
                                                            .BuildScenarioString(
                                                                Convert.ToInt32(range),
                                                                new Dictionary<string, int>()
                                                                {
                                                                    {"Fizz", Convert.ToInt32(val[0])},
                                                                    {"Buzz", Convert.ToInt32(val[1])},
                                                                    {"FizzBuzz", Convert.ToInt32(val[2])},
                                                                    {"Lucky", Convert.ToInt32(val[3])},
                                                                });
                                                        PrintBuildScenarioOutput(retVal);
                                                        PressKeyToContinue();
                                                    }
                                                    ifConfigured = true;
                                                    break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            PrintError("Range cannot be left blank or null");
                        }
                    }
                    catch (AirPotrException e)
                    {
                        System.Console.WriteLine(e.ErrorResult != null
                            ? e.ErrorResult.ReasonPhrase
                            : "Exception Occured during Building Scenario Results");
                    }
                    catch (Exception e)
                    {
                        System.Console.WriteLine(e.Message);
                    }
                }
            }
        }

        private static void PrintBuildScenarioOutput(StringBuilder retVal)
        {
            System.Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine(retVal);
        }

        private static void PressKeyToContinue()
        {
            System.Console.WriteLine("\n Press any key to continue....");
            System.Console.ReadKey();
        }

        private static string[] SplitCommaSpaceStrings(string scenarioInput)
        {
            return scenarioInput.Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
        }

        private static void PrintScenarioMenu()
        {
            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine(
                "1) Print [ Fizz ] for multiple of <enter number>,[ Buzz ] for multiple of <enter number>,[ FizzBuzz ] for multiple of <enter number> :\n");
            System.Console.WriteLine(
                "2) Print [ Fizz ] for multiple of <enter number>,[ Buzz ] for multiple of <enter number>,[ FizzBuzz ] for multiple of <enter number>. If <enter number> contains <enter digit> print [Lucky] :\n");
            System.Console.WriteLine(
                "3) Print number of occurrence for each [ Fizz Buzz FizzBuzz Lucky] and the numbers which do not match any items :\n");
        }

        private static void PrintIntialStep()
        {
            System.Console.BackgroundColor = ConsoleColor.Black;
            System.Console.Clear();
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("{0," + ((System.Console.WindowWidth / 2) + ("AirPotr Scenario based Test".Length / 2)) + "}", "AirPotr Scenario based Test \n");

            System.Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine("Please select from the following Scenario :\n");
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine("----------------------------------------:\n");
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("Please Enter Range first <nNumber>. Should be >= 3 :\n");
        }

        private static void PrintError(string errorMessage)
        {
            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine(
                errorMessage + " Please retry . Press Any Key To Continue....:\n");
            System.Console.ReadKey();
            System.Console.Clear();
        }
    }
}