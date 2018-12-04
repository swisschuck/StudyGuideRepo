using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StudyGuideUnitTests.Immutability
{
    [TestClass]
    public class ImmutabilityTests
    {


        [TestMethod]
        public void UppercaseToString2()
        {
            // Arrange
            string name;

            // Act
            name = "charlie";
            name = name.ToUpper();

            // Assert

            // here it will change the value because we are re-assigning that value
            Assert.AreEqual("CHARLIE", name);
        }

        [TestMethod]
        public void UppercaseToString1()
        {
            // Arrange
            string name;

            // Act
            name = "charlie";
            name.ToUpper();

            // Assert

            // the string type is a reference type but behaves like a value type where it doesnt change the
            // string that we are pointing to, instead it creates a new string and returns that string from the method ToUpper()
            Assert.AreEqual("charlie", name);
        }



        [TestMethod]
        public void AddDaysToDateTime1()
        {
            // Arrange
            DateTime date1 = new DateTime(2000, 1, 1);

            // Act
            date1.AddDays(1);

            // Assert

            // because the DateTime type is Immutable or cannot be changed, this test will pass even
            // though we used the AddDays method cause we never changed the actual value
            Assert.AreNotEqual(2, date1.Day);
        }

        [TestMethod]
        public void AddDaysToDateTime2()
        {
            // Arrange
            DateTime date1 = new DateTime(2000, 1, 1);

            // Act
            date1 = date1.AddDays(1);

            // Assert

            // here it will pass because we changed the actual value of the date by writing over it
            Assert.AreEqual(2, date1.Day);
        }
    }
}
