using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuide.Classes.Examples.Cryptography
{
    public class EncryptedPacket
    {
        #region fields
        #endregion fields


        #region properties

        public byte[] EncryptedSessionKey;
        public byte[] EncryptedData;
        public byte[] IV;
        public byte[] Hmac; // Hash MAC or Hashed Message Authentication Code

        #endregion properties


        #region constructors
        #endregion constructors


        #region public methods
        #endregion public methods


        #region private methods
        #endregion private methods
    }
}
