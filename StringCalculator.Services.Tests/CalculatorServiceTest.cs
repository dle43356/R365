using NUnit.Framework;
using StringCalculator.Entities.Exceptions;
using StringCalculator.Services;
using StringCalculator.Services.Interfaces;
using StringCalculator.Utilities;

namespace Tests
{
    public class CalculatorServiceTest
    {
        private ICalculatorService _calculatorService;

        [SetUp]
        public void Setup()
        {
            _calculatorService = new CalculatorService(new InputProcessorService(new DelimiterHelper()),
                                                       new ValidatorService());
        }

        [Test]
        public void TestCalculate2Numbers()
        {
            var result = _calculatorService.Calculate("1,2");
            Assert.IsTrue(result == 3);
            result = _calculatorService.Calculate("20");
            Assert.IsTrue(result == 20);
            result = _calculatorService.Calculate("5,dfaadf");
            Assert.IsTrue(result == 5);
        }

        [Test]
        public void TestCalculateNoLimitNumbers()
        {
            var result = _calculatorService.Calculate("1,2,4,5");
            Assert.IsTrue(result == 12);
            result = _calculatorService.Calculate("1,2,4,5,6,8,10");
            Assert.IsTrue(result == 36);
        }

        [Test]
        public void TestCalculateNewlineDelimiter()
        {
            var result = _calculatorService.Calculate(@"1\n2,3");
            Assert.IsTrue(result == 6);
            result = _calculatorService.Calculate(@"1\n2,3\n4,5");
            Assert.IsTrue(result == 15);
        }

        [Test]
        public void TestCalculateNegativeNumbersNotAllowed()
        {
            Assert.Throws<NegativeNumberException>(NegativeNumbers);
        }

        private void NegativeNumbers() => _calculatorService.Calculate(@"1\n2,-3");

        [Test]
        public void TestCalculateMax1000()
        {
            var result = _calculatorService.Calculate(@"1\n1001,3");
            Assert.IsTrue(result == 4);
        }

        [Test]
        public void TestCalculateCustomDelimiter()
        {
            var result = _calculatorService.Calculate(@"//#\n2#5");
            Assert.IsTrue(result == 7);
            result = _calculatorService.Calculate(@"//,\n2,ff,100");
            Assert.IsTrue(result == 102);
        }
    }
}