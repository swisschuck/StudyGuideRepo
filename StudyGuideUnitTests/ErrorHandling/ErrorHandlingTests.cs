using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StudyGuideUnitTests.ErrorHandling
{
    [TestClass]
    public class ErrorHandlingTests
    {

        [TestMethod]
        public void ASimpleExceptionHandler()
        {
            // Arrange
            int number1;
            int number2;
            int total;

            // Act
            try
            {
                number1 = 1;
                number2 = int.MaxValue;
                total = number1 + number2;


            }
            catch (Exception ex)
            {
                // Assert
                Assert.IsTrue(ex is OverflowException);
            }

        }

        [TestMethod]
        public void NestedExceptions()
        {
            // Arrange

            // Act
            try
            {
                // in this method the method being called has its own try catch that will simply throw the
                // the exception. When the throw is used in a nested try catch the orignal exception will be sent up
                // to the highest level exception block
                ExceptionMethodThatJustThrows();

            }
            catch (Exception ex)
            {
                // Assert
                Assert.IsTrue(ex is NullReferenceException);
            }

        }

        [TestMethod]
        public void NestedExceptions2()
        {
            // Arrange

            // Act
            try
            {
                // here the nested try catch method is throwing a new exception in its try catch so even through the try catch
                // in this method will detect that something went wrong it wont have any knowledge of the type of exception that 
                // was thrown in the nested try catch method below.
                ExceptionMethodThatThrowsNewException();

            }
            catch (Exception ex)
            {
                // Assert
                Assert.IsFalse(ex is NullReferenceException);
            }

        }






        private void ExceptionMethodThatJustThrows()
        {
            string tempVal = null;
            try
            {
                tempVal.ToLower();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void ExceptionMethodThatThrowsNewException()
        {
            string tempVal = null;
            try
            {
                tempVal.ToLower();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
