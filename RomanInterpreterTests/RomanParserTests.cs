using NUnit.Framework;
using RomanInterpreter;
using System;

namespace RomanInterpreterTests
{
    public class RomanParserTests
    {
        RomanParser Parser;

        [SetUp]
        public void Setup()
        {
            Parser = new RomanParser(new RomanBuilder());
        }

        [TestCase("I", 1)]
        [TestCase("II", 2)]
        [TestCase("III", 3)]
        [TestCase("IV", 4)]
        [TestCase("V", 5)]
        [TestCase("VI", 6)]
        [TestCase("VII", 7)]
        [TestCase("VIII", 8)]
        [TestCase("IX", 9)]
        [TestCase("X", 10)]
        [TestCase("XI", 11)]
        [TestCase("XII", 12)]
        [TestCase("XX", 20)]
        [TestCase("XXI", 21)]
        [TestCase("XXII", 22)]
        [TestCase("XL", 40)]
        [TestCase("XLV", 45)]
        [TestCase("XLVI", 46)]
        [TestCase("1L", 49)]
        [TestCase("L", 50)]
        [TestCase("LI", 51)]
        [TestCase("LX", 60)]
        [TestCase("LXX", 70)]
        [TestCase("XC", 90)]
        [TestCase("IC", 99)]
        [TestCase("C", 100)]
        [TestCase("D", 500)]
        [TestCase("M", 1000)]
        [TestCase("MM", 2000)]
        public void RomanParserTest_ShouldSucceed(string input, int expected)
        {
            // Act
            int result = Parser.Parse(input).Interpret();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestCase("IIV", RomanEnum.V)]
        [TestCase("IIX", RomanEnum.X)]
        [TestCase("IIL", RomanEnum.L)]
        [TestCase("IIC", RomanEnum.C)]
        [TestCase("IID", RomanEnum.D)]
        [TestCase("IIM", RomanEnum.M)]
        [TestCase("XXL", RomanEnum.L)]
        [TestCase("XXC", RomanEnum.C)]
        [TestCase("XXD", RomanEnum.D)]
        [TestCase("XXM", RomanEnum.M)]
        [TestCase("CCD", RomanEnum.D)]
        [TestCase("CCM", RomanEnum.M)]
        public void RomanParserTest_WithMultipleLowers_ShouldThrow(string input, RomanEnum actual)
        {
            // Arrange
            TestDelegate action = CreateDelegate(input);

            // Act
            var exception = Assert.Throws<RomanNotAllowedException>(action);

            // Assert
            Assert.AreEqual($"Roman {actual} not allowed", exception.Message);
        }

        [TestCase("VV", RomanEnum.V)]
        [TestCase("LL", RomanEnum.L)]
        [TestCase("DD", RomanEnum.D)]
        public void RomanParserTest_WithMultipleFives_ShouldThrow(string input, RomanEnum actual)
        {
            // Arrange
            TestDelegate action = CreateDelegate(input);

            // Act
            var exception = Assert.Throws<RomanNotAllowedException>(action);

            // Assert
            Assert.AreEqual($"Roman {actual} not allowed", exception.Message);
        }

        [TestCase("IVI", RomanEnum.I)]
        [TestCase("ILI", RomanEnum.I)]
        [TestCase("IDI", RomanEnum.I)]
        [TestCase("XLX", RomanEnum.X)]
        [TestCase("XDX", RomanEnum.X)]
        [TestCase("CDC", RomanEnum.C)]
        public void RomanParserTest_WithSubtract_ShouldThrow(string input, RomanEnum actual)
        {
            // Arrange
            TestDelegate action = CreateDelegate(input);

            // Act
            var exception = Assert.Throws<RomanNotAllowedException>(action);

            // Assert
            Assert.AreEqual($"Roman {actual} not allowed", exception.Message);
        }

        private TestDelegate CreateDelegate(string input)
          => () => Parser.Parse(input).Interpret();
    }
}