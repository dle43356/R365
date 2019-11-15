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
        public void TestGetCustomDelimiter()
        {
            var customDelimiter = _delimiterHelper.GetCustomDelimiter(@"//#\n2#5");
            Assert.IsTrue(customDelimiter.Delimiter == "#");
            Assert.IsTrue(customDelimiter.LengthToRemoveFromInput == 3);
        }
    }
}