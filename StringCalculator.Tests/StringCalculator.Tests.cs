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
            Assert.Equal(1, _stringCalculator.AddString("1,5000"));
            Assert.Equal(7, _stringCalculator.AddString("4,3"));
        }

        [Fact]
        public void InvalidNumbersTest()
        {
            Assert.Equal(0, _stringCalculator.AddString(""));
            Assert.Equal(5, _stringCalculator.AddString("5,tytyt"));
            Assert.Equal(0, _stringCalculator.AddString("      "));
        }

        [Fact]
        public void ManyNumbersTest()
        {
            Assert.Equal(78, _stringCalculator.AddString("1,2,3,4,5,6,7,8,9,10,11,12"));
            Assert.Equal(10, _stringCalculator.AddString("1,2,4,3"));
            Assert.Equal(60, _stringCalculator.AddString("blah,yes, fantastic, 30, fun, 30    "));
        }

        [Fact]
        public void ManyDelimitersTest()
        {
            Assert.Equal(6, _stringCalculator.AddString("1\n2,3"));
            Assert.Equal(13, _stringCalculator.AddString("1\n2\n10"));
            Assert.Equal(4, _stringCalculator.AddString("1\n,3"));
        }

        [Fact]
        public void NegativeNumbersTest()
        {
            var exception = Assert.Throws<ArgumentException>(() => _stringCalculator.AddString("-1, 4"));

            Assert.Equal("Cannot use negative numbers. -1 is invalid.", exception.Message);
        }

        [Fact]
        public void LargeNumbersTest()
        {
            Assert.Equal(8, _stringCalculator.AddString("2, 1001, 6"));
            Assert.Equal(0, _stringCalculator.AddString("5000, 1001"));
            Assert.Equal(2, _stringCalculator.AddString("2, 7000, 10000"));
        }

        [Fact]
        public void CustomDelimiterTest()
        {
            Assert.Equal(7, _stringCalculator.AddString("//#\n2#5"));
            Assert.Equal(66, _stringCalculator.AddString("//[***]\n11***22***33"));
        }

        [Fact]
        public void MultiCustomDelimiterTest()
        {
            Assert.Equal(110, _stringCalculator.AddString("//[*][!!][r9r]\n11r9r22*hh*33!!44"));
            Assert.Equal(206, _stringCalculator.AddString("//[*][!!][+]\n22*hh+33!!50, 101"));
        }
    }
}
