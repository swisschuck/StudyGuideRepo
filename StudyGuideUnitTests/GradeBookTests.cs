using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyGuide.Classes.Testing;

namespace StudyGuideUnitTests
{
    [TestClass]
    public class GradeBookTests
    {
        [TestMethod]
        public void ComputeHighestGrade()
        {
            GradeBook gradeBook = new GradeBook();
            gradeBook.AddGrade(10);
            gradeBook.AddGrade(90);

            GradeStatistics gradeStatistics = gradeBook.ComputeStatistics();

            Assert.AreEqual(90, gradeStatistics.HighestGrade);
        }

        [TestMethod]
        public void ComputeLowestGrade()
        {
            GradeBook gradeBook = new GradeBook();
            gradeBook.AddGrade(10);
            gradeBook.AddGrade(90);

            GradeStatistics gradeStatistics = gradeBook.ComputeStatistics();

            Assert.AreEqual(10, gradeStatistics.LowestGrade);
        }

        [TestMethod]
        public void ComputeAverageGrade()
        {
            GradeBook gradeBook = new GradeBook();
            gradeBook.AddGrade(91);
            gradeBook.AddGrade(89.5f);
            gradeBook.AddGrade(75);

            GradeStatistics gradeStatistics = gradeBook.ComputeStatistics();

            // try not to do assertions with floats or any other type that could give very minute numbers
            //Assert.AreEqual(85.16666666666667, gradeStatistics.AverageGrade);
            Assert.AreEqual(85.16f, gradeStatistics.AverageGrade, 0.01);
        }

    }
}
