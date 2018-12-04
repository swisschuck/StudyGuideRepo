using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuide.Classes.Examples
{
    public class PolymorphismBase
    {

        #region fields
        #endregion fields


        #region properties
        #endregion properties


        #region constructors

        public PolymorphismBase()
        {

        }

        #endregion constructors


        #region public methods

        public virtual void PrintMessage(string messageToPrint)
        {
            Console.WriteLine(String.Format("Here is the message to print from PolymorphismBase: {0}", messageToPrint));
        }

        #endregion public methods


        #region private methods
        #endregion private methods
    }
}
