using NUnit.Framework;
using StringCalculator.Utilities.Interfaces;
using System.Linq;

namespace StringCalculator.Utilities.Tests
{
    public class DelimiterHelperTest
    {
        private IDelimiterHelper _delimiterHelper;

        [SetUp]
        public void Setup()
        {
            _delimiterHelper = new DelimiterHelper();
        }

        [Test]
        public void TestGetCustomDelimiterChar()
        {
            var customDelimiter = _delimiterHelper.GetCustomDelimiter(@"//#\n2#5");
            Assert.IsTrue(customDelimiter.Delimiters.Count() == 1);
            Assert.IsTrue(customDelimiter.Delimiters.First() == "#");
            Assert.IsTrue(customDelimiter.LengthToRemoveFromInput == 3);
        }

        [Test]
        public void TestGetCustomDelimiterString()
        {
            var customDelimiter = _delimiterHelper.GetCustomDelimiter(@"//[***]\n11***22***33");
            Assert.IsTrue(customDelimiter.Delimiters.Count() == 1);
            Assert.IsTrue(customDelimiter.Delimiters.First() == "***");
            Assert.IsTrue(customDelimiter.LengthToRemoveFromInput == 7);
        }

        [Test]
        public void TestGetCustomDelimiterMultipleString()
        {
            var customDelimiter = _delimiterHelper.GetCustomDelimiter(@"//[*][!!][r9r]\n11r9r22*hh*33!!44");
            Assert.IsTrue(customDelimiter.Delimiters.Count() == 3);
            Assert.IsTrue(customDelimiter.LengthToRemoveFromInput == 14);
        }
    }
}