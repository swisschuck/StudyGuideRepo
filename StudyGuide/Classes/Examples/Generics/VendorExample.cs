using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuide.Classes.Examples.Generics
{
    public class VendorExample
    {
        #region fields

        private string _vendorName;
        private int _vendorID;
        private string _vendorEmail;

        #endregion fields


        #region properties

        public string VendorName
        {
            get { return _vendorName; }
            set { _vendorName = value; }
        }

        public int VendorID
        {
            get { return _vendorID; }
            set { _vendorID = value; }
        }

        public string VendorEmail
        {
            get { return _vendorEmail; }
            set { _vendorEmail = value; }
        }

        #endregion properties


        #region constructors

        public VendorExample()
        {

        }

        public VendorExample(string vendorNamePassedIn)
        {
            _vendorName = vendorNamePassedIn;
        }


        #endregion constructors


        #region public methods
        #endregion public methods


        #region private methods
        #endregion private methods
    }
}
