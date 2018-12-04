using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuide.Classes.Examples
{
    public class Polymorphism : PolymorphismBase
    {

        #region fields
        #endregion fields


        #region properties
        #endregion properties


        #region constructors

        public Polymorphism()
        {

        }

        #endregion constructors


        #region public methods

        public override void PrintMessage(string messageToPrint)
        {
            Console.WriteLine(String.Format("Here is the message to print from Polymorphism: {0}", messageToPrint));
        }

        #endregion public methods


        #region private methods
        #endregion private methods
    }
}
