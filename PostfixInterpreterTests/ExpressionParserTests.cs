using NUnit.Framework;
using PostfixInterpreter;

namespace PostfixInterpreterTests
{
    public class ExpressionParserTests
    {
        ExpressionParser Parser;

        [SetUp]
        public void Setup()
        {
            Parser = new ExpressionParser(new ExpressionBuilder(new ExpressionFactoryCreator()));
        }

        [TestCase("2 1 5 + *", 12)]
        [TestCase("2 1 - 5 *", 5)]
        [TestCase("2 1 5 - *", -8)]
        public void ExpressionParserTest_ShouldSucceed(string input, int expected)
        {
            // Act
            int result = Parser.Parse(input).Interpret();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ExpressionParserTest_StackSmallCount_ThrowsInvalidOperatorException()
        {
            // Arrange
            TestDelegate action = CreateDelegate("1 *");

            // Act
            var exception = Assert.Throws<InvalidOperatorException>(action);

            // Assert
            Assert.AreEqual($"Operator count: 1 is invalid", exception.Message);
        }

        [Test]
        public void ExpressionParserTest_OperatorHasNoFactory_ThrowsInvalidContextException()
        {
            // Arrange
            TestDelegate action = CreateDelegate("2 1 /");

            // Act
            var exception = Assert.Throws<InvalidContextException>(action);

            // Assert
            Assert.AreEqual($"Context: / is invalid", exception.Message);
        }

        [Test]
        public void ExpressionParserTest_StackMoreThanOneOnBuild_ThrowsInvalidBuildException()
        {
            // Arrange
            TestDelegate action = CreateDelegate("2 3 4 +");

            // Act
            var exception = Assert.Throws<InvalidBuildException>(action);

            // Assert
            Assert.AreEqual($"Expression cannot be build, count: 2 is invalid", exception.Message);
        }

        private TestDelegate CreateDelegate(string input)
            => () => Parser.Parse(input).Interpret();
    }
}