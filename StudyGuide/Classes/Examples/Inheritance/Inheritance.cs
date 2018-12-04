using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuide.Classes.Examples
{
    public class Inheritance : InheritanceBase
    {
        // Inheritance binds two classes into a relationshop that cannot be broken, so it needs to be used more carefully. Sometimes partial classes and 
        #region fields
        #endregion fields


        #region properties
        #endregion properties


        #region constructors

        public Inheritance()
        {

        }

        #endregion constructors


        #region public methods

        public void PrintMessage(string messageToPrint)
        {
            Console.WriteLine(String.Format("Here is the message to print from the child class: {0}", messageToPrint));
        }


        #endregion public methods


        #region private methods
        #endregion private methods
    }
}
