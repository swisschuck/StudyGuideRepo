using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StudyGuideUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        // General Notes
        // ---------------------------------------
        // - tests should not depend or interact with one another
        // - try to keep them as short and sweet as possible

        [TestMethod]
        public void TestMethod1()
        {
            // Arrange - Build out varables needed, instantiate new objects, etc

            int firstNumber;
            int secondNumber;
            int additionResult;
            int threshold;


            // Act - Take all the items from the Arrange the code to do something

            firstNumber = 2;
            secondNumber = 3;
            threshold = 6;
            additionResult = firstNumber + secondNumber;

            // Assert - The actual action you are trying to test
            //        - Should only have one assert per test method

            Assert.IsFalse(additionResult > threshold);

        }
    }
}
