using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyGuide.Classes.Testing;

namespace StudyGuideUnitTests.Types
{
    [TestClass]
    public class TypeTests
    {
        // making use of the ref keyword and what happens to both Reference and Value types when they are passed around and changed
        private const string _gradeBookName = "charlies gradebook";
        private const int _someNumber = 5;


        [TestMethod]
        public void ReferenceTypesPassByRef()
        {
            // Arrange
            int firstNumber;

            // Act
            firstNumber = _someNumber;
            IncrementNumberRef(ref firstNumber);

            // Assert
            // this will pass cause we passed a reference to the original value so it will get changed in the 
            // IncrementNumberRef method. the values will not be equal.
            Assert.AreNotEqual(_someNumber, firstNumber);
        }




        [TestMethod]
        public void ValueTypesPassByRef()
        {
            // Arrange
            GradeBook gradeBook1 = new GradeBook();
            GradeBook gradeBook2 = gradeBook1; // coping the reference that inside book 1 into book 2


            // Act
            GiveBookANameRef(ref gradeBook2);


            // Assert

            // 
            Assert.AreEqual(_gradeBookName, gradeBook2.Name);
        }


        [TestMethod]
        public void ValueTypesPassByValue()
        {
            // Arrange
            GradeBook gradeBook1 = new GradeBook();
            GradeBook gradeBook2 = gradeBook1; // coping the reference that inside book 1 into book 2


            // Act
            GiveBookAName(gradeBook2);


            // Assert

            // so because we are passing a reference type this Assert will be true even though gradeBook2 didnt 
            // have a name until after it was copied from gradeBook1
            Assert.AreEqual(_gradeBookName, gradeBook2.Name);
        }


        [TestMethod]
        public void ReferenceTypesPassByValue()
        {
            // Arrange
            int firstNumber;

            // Act
            firstNumber = _someNumber;
            IncrementNumber(firstNumber);

            // Assert
            // this will always pass cause we are passing a value type to the IncrementNumber method which leaves the scope of this 
            // test method and gets altered in the IncrementNumber method only.
            Assert.AreEqual(_someNumber, firstNumber);
        }



        private void GiveBookAName(GradeBook gradebook)
        {
            gradebook.Name = _gradeBookName;
        }

        private void GiveBookANameRef(ref GradeBook gradebook)
        {
            gradebook.Name = _gradeBookName;
        }

        private void IncrementNumber(int numberToIncrement)
        {
            numberToIncrement += 1;
        }

        private void IncrementNumberRef(ref int numberToIncrement)
        {
            numberToIncrement += 1;
        }

    }
}
