using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuide.Classes.Examples.Cryptography
{
    public class RSAKeys
    {
        #region fields

        private string _rsaPrivateKey;
        private string _rsaPublicKey;

        #endregion fields


        #region properties

        public string RsaPrivateKey
        {
            get { return _rsaPrivateKey; }
            set { _rsaPrivateKey = value; }
        }

        public string RsaPublicKey
        {
            get { return _rsaPublicKey; }
            set { _rsaPublicKey = value; }
        }

        #endregion properties


        #region constructors
        #endregion constructors


        #region public methods
        #endregion public methods


        #region private methods
        #endregion private methods
    }
}
