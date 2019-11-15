using NUnit.Framework;
using StringCalculator.Utilities.Interfaces;

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
        public void TestGetCustomDelimiterSingleChar()
        {
            var customDelimiter = _delimiterHelper.GetCustomDelimiter(@"//#\n2#5");
            Assert.IsTrue(customDelimiter.Delimiter == "#");
            Assert.IsTrue(customDelimiter.LengthToRemoveFromInput == 3);
        }

        [Test]
        public void TestGetCustomDelimiterString()
        {
            var customDelimiter = _delimiterHelper.GetCustomDelimiter(@"//[***]\n11***22***33");
            Assert.IsTrue(customDelimiter.Delimiter == "***");
            Assert.IsTrue(customDelimiter.LengthToRemoveFromInput == 7);
        }
    }
}