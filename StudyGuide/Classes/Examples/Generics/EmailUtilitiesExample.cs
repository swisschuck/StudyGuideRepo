using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuide.Classes.Examples.Generics
{
    public class EmailUtilitiesExample
    {

        #region fields

        private string _emailDestination;

        #endregion fields


        #region properties

        public string EmailDestination
        {
            get { return _emailDestination; }
            set { _emailDestination = value; }
        }

        #endregion properties


        #region constructors

        public EmailUtilitiesExample()
        {

        }

        #endregion constructors


        #region public methods

        // using an interface as a parameter
        public bool SendVendorsEmail(ICollection<VendorExample> vendorsToSend)
        {
            //.. some actual code to send an email here

            Console.WriteLine(String.Format("The vendors email was sent using a {0}", vendorsToSend.GetType().ToString()));

            return true;
        }


        #endregion public methods


        #region private methods
        #endregion private methods
    }
}
