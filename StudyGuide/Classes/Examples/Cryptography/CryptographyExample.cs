using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Diagnostics;

namespace StudyGuide.Classes.Examples.Cryptography
{
    public class CryptographyExample
    {

        #region fields

        private int? _randomNumberLength;
        private int _defaultRandomNumberLength = 50;
        private const int _keySize = 32;
        private const int _saltLength = 32;
        private const int _passwordBasedKeyDerivationFunctionIterations = 50000;

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

        public static byte[] GenerateSalt()
        {
            using (RNGCryptoServiceProvider RNGCSP = new RNGCryptoServiceProvider())
            {
                byte[] randomNumber = new byte[_saltLength];
                RNGCSP.GetBytes(randomNumber);

                return randomNumber;
            }
        }

        public static byte[] CombineByteArrays(byte[] firstByteArray, byte[] secondByteArray)
        {
            byte[] returnValue = new byte[firstByteArray.Length + secondByteArray.Length];

            // Buffer.BlockCopy = Copies a specified number of bytes from a source array starting at a particular 
            //                    offset to a destination array starting at a particular offset.

            // Buffer.ClockCopy parameters
            // src - (Array) The source buffer
            // srcOffset - (int32) The zero-based byte offset into src
            // dst - (Array) The destination buffer.
            // dstOffset - (int32) The zero-based byte offset into dst.
            // count - (int32) The number of bytes to copy.

            Buffer.BlockCopy(firstByteArray, 0, returnValue, 0, firstByteArray.Length);

            Buffer.BlockCopy(secondByteArray, 0, returnValue, firstByteArray.Length, secondByteArray.Length);

            return returnValue;
        }


        public static byte[] HashPasswordWithSalt(byte[] toBeHashed, byte[] salt)
        {
            using (SHA256 SHA256 = SHA256.Create())
            {
                return SHA256.ComputeHash(CombineByteArrays(toBeHashed, salt));
            }
        }

        public static void HashUsingPasswordBasedKeyDerivationFunction(string passwordToBeHashed, int numberOfIterations)
        {
            Stopwatch SW = new Stopwatch();

            SW.Start();

            byte[] hashedPassword = GetPasswordBasedKeyDerivationFunction(Encoding.UTF8.GetBytes(passwordToBeHashed), GenerateSalt(), numberOfIterations);


            SW.Stop();

            Console.WriteLine();
            Console.WriteLine(String.Format("password to hash: {0}", passwordToBeHashed));
            Console.WriteLine(String.Format("hashed password: {0}", Convert.ToBase64String(hashedPassword)));
            Console.WriteLine(String.Format("with {0} iterations, it took {1} seconds to hash.", 
                                            numberOfIterations, 
                                            (decimal)SW.ElapsedMilliseconds / 1000)
                                            );
        }



        #endregion public methods


        #region private methods

        private static byte[] GetPasswordBasedKeyDerivationFunction(byte[] toBeHashed, byte[] salt, int numberOfIterations)
        {
            using (Rfc2898DeriveBytes rfc2898 = new Rfc2898DeriveBytes(toBeHashed, salt, numberOfIterations))
            {
                return rfc2898.GetBytes(32);
            }
        }

        #endregion private methods
    }
}
