using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilitiess;

namespace Utilities.Test.MsTest
{
    [TestClass]
    public class MathUtilsTests
    {
        //Needed only if using multiple parameters in tests
        private TestContext testContext;

        public TestContext TestContext
        {
            get
            {
                return this.testContext;
            }
            set
            {
                this.testContext = value;
            }
        }
        //Needed only if using multiple parameters in tests

        [TestMethod]
        public void MSTest_MathUtils_SumZeroNumbers_ShouldReturnZero()
        {
            var util = new MathUtilities();

            var numbers = new List<int>() { };
            var result = util.Sum(numbers);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void MSTest_MathUtils_SumTwoPositiveNumbers_ShouldReturnCorrectResult()
        {
            var util = new MathUtilities();
            var numbers = new List<int>() { 1, 2 };

            var result = util.Sum(numbers);

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void MSTest_MathUtils_SumOneNegativeNumber_ShouldReturnTheNumberItself()
        {
            var util = new MathUtilities();
            var numbers = new List<int>() { -1 };

            var result = util.Sum(numbers);

            Assert.AreEqual(-1, result);
        }



        [DeploymentItem(@"C:\Users\Vladimir\Desktop\Telerik-Academy\07.Unit Testing with C#\01. Unit Testing\Utilities\Utilities.Test.MsTest\data\SumData.xml", "Data"), TestMethod]
        [DataSource(
           "Microsoft.VisualStudio.TestTools.DataSource.XML",
           "Data\\SumData.xml",
           "Row",
           DataAccessMethod.Sequential)]
        public void MSTest_MathUtils_MultipleCases_ShouldReturnRightResult()
        {
            var util = new MathUtilities();

            var arr = ((string)TestContext.DataRow["Array"]).Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            var expected = int.Parse((string)TestContext.DataRow["Result"]);

            var result = util.Sum(arr);

            Assert.AreEqual(expected, result);
        }
    }
}
