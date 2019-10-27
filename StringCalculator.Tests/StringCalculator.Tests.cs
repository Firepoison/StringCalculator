using System;
using Xunit;
using challenge_calculator;

namespace challenge_calculator
{
    public class StringCalcualtorTests
    {
        private readonly StringCalculator _stringCalculator;

        public StringCalcualtorTests()
        {
            _stringCalculator = new StringCalculator();
        }

        [Fact]
        public void AddStringTest()
        {
            Assert.Equal(20, _stringCalculator.AddString("20"));
            Assert.Equal(5001, _stringCalculator.AddString("1,5001"));
            Assert.Equal(1, _stringCalculator.AddString("4,-3"));
        }

        [Fact]
        public void InvalidNumbersTest()
        {
            Assert.Equal(0, _stringCalculator.AddString(""));
            Assert.Equal(5, _stringCalculator.AddString("5,tytyt"));
        }
    }
}
