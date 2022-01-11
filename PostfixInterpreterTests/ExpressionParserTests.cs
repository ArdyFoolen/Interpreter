using NUnit.Framework;
using PostfixInterpreter;

namespace PostfixInterpreterTests
{
    public class ExpressionParserTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ExpressionParserTest_ShouldSucceed()
        {
            // Arrange
            string input = "2 1 5 + *";
            ExpressionParser parser = new ExpressionParser(new ExpressionBuilder(new ExpressionFactoryCreator()));

            // Act
            int result = parser.Parse(input).Interpret();

            // Assert
            Assert.AreEqual(12, result);
        }
    }
}