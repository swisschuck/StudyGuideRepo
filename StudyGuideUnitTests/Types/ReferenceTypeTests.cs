using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyGuide.Classes.Testing;
using System;

namespace StudyGuideUnitTests.Types
{
    [TestClass]
    public class ReferenceTypeTests
    {
        [TestMethod]
        public void VariablesHoldAReference()
        {
            // Arrange
            GradeBook gradeBook1 = new GradeBook();
            GradeBook gradeBook2 = new GradeBook();


            // Act
            gradeBook1 = new GradeBook();
            gradeBook2 = gradeBook1;
            gradeBook1.Name = "Charlies Grade Book";


            // Assert
            Assert.AreEqual(gradeBook1.Name, gradeBook2.Name);
        }


        [TestMethod]
        public void IntVariablesHoldAValue()
        {
            // Arrange
            int int1;
            int int2;

            // Act
            int1 = 100;
            int2 = int1;
            int1 = 4;

            // Assert
            Assert.AreNotEqual(int1, int2);
        }


        [TestMethod]
        public void StringComparisions()
        {
            // Arrange
            string name1;
            string name2;
            bool result;

            // Act
            name1 = "Charlie";
            name2 = "charlie";
            result = String.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
