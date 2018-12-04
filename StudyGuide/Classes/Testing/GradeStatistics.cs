
namespace StudyGuide.Classes.Testing
{
    public class GradeStatistics
    {
        #region fields
        #endregion fields


        #region properties

        public float AverageGrade;
        public float HighestGrade;
        public float LowestGrade;

        #endregion properties


        #region constructors
        #endregion constructors


        #region public methods

        public GradeStatistics()
        {
            HighestGrade = 0;
            LowestGrade = float.MaxValue;
        }

        #endregion public methods


        #region private methods
        #endregion private methods
    }
}
