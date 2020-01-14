using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalorieCalculator.API;

namespace CalorieCalculator.Test
{
    [TestClass]
    public class CalcTests
    {
        string firstName = "Bob";
        string lastName = "Smith";
        string ssnPart1 = "123";
        string ssnPart2 = "33";
        string ssnPart3 = "1234";
        Calc.The_sex sex = Calc.The_sex.Male;
        string age = "33";
        string heightFeet = "5";
        string heightInches = "10";
        string weight = "250";

        [TestMethod]
        public void TestMethod1()
        {
        }

        public void Calculate_WithValidData()
        { 
            
        }
    }
}
