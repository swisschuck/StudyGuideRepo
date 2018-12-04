
using System;
using System.Collections.Generic;
namespace StudyGuide.Classes.Testing
{
    public class GradeBook
    {
        #region fields

        private List<float> _grades;

        #endregion fields


        #region properties
        #endregion properties


        #region constructors

        public GradeBook()
        {
            _grades = new List<float>();
        }

        public string Name;

        #endregion constructors


        #region public methods

        public void AddGrade(float grade)
        {
            _grades.Add(grade);
        }


        public GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();

            float sum = 0;

            foreach (float grade in _grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            stats.AverageGrade = sum / _grades.Count;

            return stats;
        }

        #endregion public methods


        #region private methods
        #endregion private methods
    }
}
