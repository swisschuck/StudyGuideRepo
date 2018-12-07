using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace StudyGuide.Classes.Examples.Cryptography
{
    public class CryptographyExample
    {

        #region fields

        private int? _randomNumberLength;
        private int _defaultRandomNumberLength = 50;

        #endregion fields


        #region properties

        public int? RandomNumberLength
        {
            get { return _randomNumberLength; }
            set { _randomNumberLength = value; }
        }

        #endregion properties


        #region constructors

        public CryptographyExample()
        {

        }

        public CryptographyExample(int randomNumberLength)
        {
            _randomNumberLength = randomNumberLength;
        }

        #endregion constructors


        #region public methods

        public byte[] GenerateRandomNumber()
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                byte[] randomNumber = new byte[_randomNumberLength.HasValue ? (int)_randomNumberLength : _defaultRandomNumberLength];
                randomNumberGenerator.GetBytes(randomNumber);
                return randomNumber;
            }
        }
        #endregion public methods


        #region private methods
        #endregion private methods
    }
}
