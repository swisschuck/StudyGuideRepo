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
        private const int _keySize = 32;

        #endregion fields


        #region properties

        public int? RandomNumberLength
        {
            get { return _randomNumberLength; }
            set { _randomNumberLength = value; }
        }

        public int KeySize
        {
            get { return _keySize; }
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

        public static byte[] GenerateKey()
        {
            using (RNGCryptoServiceProvider RNGCSP = new RNGCryptoServiceProvider())
            {
                byte[] randomNumber = new byte[_keySize];

                RNGCSP.GetBytes(randomNumber);

                return randomNumber;
            }
        }

        public byte[] GenerateRandomNumber()
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                byte[] randomNumber = new byte[_randomNumberLength.HasValue ? (int)_randomNumberLength : _defaultRandomNumberLength];
                randomNumberGenerator.GetBytes(randomNumber);
                return randomNumber;
            }
        }

        public static byte[] ComputeMd5HashWithKey(byte[] toBeHashedByteArray, byte[] key)
        {
            using (HMACMD5 md5 = new HMACMD5(key))
            {
                return md5.ComputeHash(toBeHashedByteArray);
            }
        }

        public static byte[] ComputeSha1HashWithKey(byte[] toBeHashedByteArray, byte[] key)
        {
            using (HMACSHA1 sha1 = new HMACSHA1(key))
            {
                return sha1.ComputeHash(toBeHashedByteArray);
            }
        }

        public static byte[] ComputeSha2Hash256WithKey(byte[] toBeHashedByteArray, byte[] key)
        {
            using (HMACSHA256 sha256 = new HMACSHA256(key))
            {
                return sha256.ComputeHash(toBeHashedByteArray);
            }
        }

        public static byte[] ComputeSha2Hash512WithKey(byte[] toBeHashedByteArray, byte[] key)
        {
            using (HMACSHA512 sha512 = new HMACSHA512(key))
            {
                return sha512.ComputeHash(toBeHashedByteArray);
            }
        }

        public static byte[] ComputeMd5Hash(byte[] toBeHashedByteArray)
        {
            using (MD5 md5 = MD5.Create())
            {
                return md5.ComputeHash(toBeHashedByteArray);
            }
        }

        public static byte[] ComputeSha1Hash(byte[] toBeHashedByteArray)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                return sha1.ComputeHash(toBeHashedByteArray);
            }
        }

        public static byte[] ComputeSha2Hash256(byte[] toBeHashedByteArray)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(toBeHashedByteArray);
            }
        }

        public static byte[] ComputeSha2Hash512(byte[] toBeHashedByteArray)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                return sha512.ComputeHash(toBeHashedByteArray);
            }
        }

        #endregion public methods


        #region private methods
        #endregion private methods
    }
}
