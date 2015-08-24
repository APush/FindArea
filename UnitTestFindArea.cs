using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FindArea;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestFindArea
    {
        [TestMethod]
        public void TestMethod1()
        {
            double x_test = 11.99; 
            double y_test = 4.55; 
            double expected = 54.5545; 

            double result= FindAreaR.RectArea(x_test, y_test);

            Assert.AreEqual(expected, result, 0.0001, "Not correctly");

        }
    }
}
