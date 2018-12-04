using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuide.Classes.Examples
{
    public class InheritanceBase
    {
        #region fields
        #endregion fields


        #region properties
        #endregion properties


        #region constructors

        public InheritanceBase()
        {

        }

        #endregion constructors


        #region public methods

        public void PrintMessage(string messageToPrint)
        {
            Console.WriteLine(String.Format("Here is the message to print from the parent class: {0}", messageToPrint));
        }


        #endregion public methods


        #region private methods
        #endregion private methods
    }
}
