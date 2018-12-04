using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StudyGuideUnitTests.Params
{
    [TestClass]
    public class ParamsTests
    {

        #region Params

        [TestMethod]
        public void MethodParamsExample()
        {
            // Arrange
            string string1;
            string string2;
            string string3;
            int int1;
            int int2;
            int int3;

            string stringParamsResult;
            int intParamsResult;


            // Act
            string1 = "string value 1";
            string2 = "string value 2";
            string3 = "string value 3";


            int1 = 1;
            int2 = 2;
            int3 = 3;

            stringParamsResult = AMethodThatTakesAnUnkownNumberOfParameters(string1, string2, string3);
            intParamsResult = AMethodThatTakesAnUnkownNumberOfParameters(int1, int2, int3);

            // Assert
            Assert.AreEqual(string1 + string2 + string3, stringParamsResult);
            Assert.AreEqual(int1 + int2 + int3, intParamsResult);
        }


        private int AMethodThatTakesAnUnkownNumberOfParameters(params int[] parametersPassedIn)
        {
            int tempInt = 0;

            foreach (int parameter in parametersPassedIn)
            {
                tempInt += parameter;
            }

            return tempInt;
        }


        private string AMethodThatTakesAnUnkownNumberOfParameters(params string[] parametersPassedIn)
        {
            return String.Concat(parametersPassedIn);
        }


        #endregion Params






        #region Overloading

        [TestMethod]
        public void MethodOverloadingExample()
        {
            // Arrange
            string someString;
            int someInt;

            // Act
            someString = "blah";
            someInt = 1;
            SomePrivateMethod(someString);
            SomePrivateMethod(someInt);

            // Assert

            Assert.AreNotSame(someInt, someString);
        }


        private void SomePrivateMethod(string blah)
        {
            // This method and the method below are examples of overloading methods
            // Method Overloading means creating multiple methods in the class having same name but different signatures (Parameters). 
            // It permits a class, struct, or interface to declare multiple methods with the same name with unique signatures.
        }

        private void SomePrivateMethod(int blah)
        {
            // see other method will same name for notes.
        }

        #endregion Overloading

    }
}
