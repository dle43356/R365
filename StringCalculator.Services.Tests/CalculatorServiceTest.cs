using NUnit.Framework;
using StringCalculator.Entities.Exceptions;
using StringCalculator.Services;
using StringCalculator.Services.Interfaces;

namespace Tests
{
    public class CalculatorServiceTest
    {
        private ICalculatorService _calculatorService;

        [SetUp]
        public void Setup()
        {
            _calculatorService = new CalculatorService(new InputProcessorService());
        }

        [Test]
        public void TestCalculate2Numbers()
        {
            var result = _calculatorService.Calculate("1,2");
            Assert.IsTrue(result == 3);
            result = _calculatorService.Calculate("20");
            Assert.IsTrue(result == 20);
            result = _calculatorService.Calculate("4,-3");
            Assert.IsTrue(result == 1);
            result = _calculatorService.Calculate(",-3");
            Assert.IsTrue(result == -3);
            result = _calculatorService.Calculate("5,dfaadf");
            Assert.IsTrue(result == 5);
        }

        [Test]
        public void TestCalculateNoLimitNumbers()
        {
            var result = _calculatorService.Calculate("1,2,4,5");
            Assert.IsTrue(result == 12);
            result = _calculatorService.Calculate("1,2,-4,5");
            Assert.IsTrue(result == 4);
        }
    }
}