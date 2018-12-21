using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Diagnostics;
using System.IO;
using StudyGuide.Database.JSON;

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
        private RSAParameters _publicKey;
        private RSAParameters _privateKey;
        private JSONDataBase _jsonDataBaseInstance;
        private const string _cspContainerName = "MyCSPContainer";

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

        public byte[] GenerateRandomNumber(int randomNumberLength)
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                byte[] randomNumber = new byte[randomNumberLength];
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

        public byte[] EncryptUsingDES(byte[] dataToEncrypt, byte[] key, byte[] initializationVector)
        {
            using (DESCryptoServiceProvider desCryptoServiceProvider = new DESCryptoServiceProvider())
            {
                desCryptoServiceProvider.Mode = CipherMode.CBC; // CBC = Cypher Block Chaining
                desCryptoServiceProvider.Padding = PaddingMode.PKCS7;

                desCryptoServiceProvider.Key = key;
                desCryptoServiceProvider.IV = initializationVector;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                                 desCryptoServiceProvider.CreateEncryptor(),
                                                                 CryptoStreamMode.Write);
                    cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                    cryptoStream.FlushFinalBlock();

                    return memoryStream.ToArray();
                }
            }
        }


        public byte[] DecryptUsingDES(byte[] dataToDecrypt, byte[] key, byte[] initializationVector)
        {
            using (DESCryptoServiceProvider desCryptoServiceProvider = new DESCryptoServiceProvider())
            {
                desCryptoServiceProvider.Mode = CipherMode.CBC; // CBC = Cypher Block Chaining
                desCryptoServiceProvider.Padding = PaddingMode.PKCS7;

                desCryptoServiceProvider.Key = key;
                desCryptoServiceProvider.IV = initializationVector;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                                 desCryptoServiceProvider.CreateDecryptor(),
                                                                 CryptoStreamMode.Write);
                    cryptoStream.Write(dataToDecrypt, 0, dataToDecrypt.Length);
                    cryptoStream.FlushFinalBlock();

                    return memoryStream.ToArray();
                }
            }
        }


        public byte[] EncryptUsingTripleDES(byte[] dataToEncrypt, byte[] key, byte[] initializationVector)
        {
            using (TripleDESCryptoServiceProvider tripleDesCryptoServiceProvider = new TripleDESCryptoServiceProvider())
            {
                tripleDesCryptoServiceProvider.Mode = CipherMode.CBC; // CBC = Cypher Block Chaining
                tripleDesCryptoServiceProvider.Padding = PaddingMode.PKCS7;

                tripleDesCryptoServiceProvider.Key = key;
                tripleDesCryptoServiceProvider.IV = initializationVector;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                                 tripleDesCryptoServiceProvider.CreateEncryptor(),
                                                                 CryptoStreamMode.Write);
                    cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                    cryptoStream.FlushFinalBlock();

                    return memoryStream.ToArray();
                }
            }
        }


        public byte[] DecryptUsingTripleDES(byte[] dataToDecrypt, byte[] key, byte[] initializationVector)
        {
            using (TripleDESCryptoServiceProvider tripleDesCryptoServiceProvider = new TripleDESCryptoServiceProvider())
            {
                tripleDesCryptoServiceProvider.Mode = CipherMode.CBC; // CBC = Cypher Block Chaining
                tripleDesCryptoServiceProvider.Padding = PaddingMode.PKCS7;

                tripleDesCryptoServiceProvider.Key = key;
                tripleDesCryptoServiceProvider.IV = initializationVector;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                                 tripleDesCryptoServiceProvider.CreateDecryptor(),
                                                                 CryptoStreamMode.Write);
                    cryptoStream.Write(dataToDecrypt, 0, dataToDecrypt.Length);
                    cryptoStream.FlushFinalBlock();

                    return memoryStream.ToArray();
                }
            }
        }


        public byte[] EncryptUsingAES(byte[] dataToEncrypt, byte[] key, byte[] initializationVector)
        {
            using (AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider())
            {
                aesCryptoServiceProvider.Mode = CipherMode.CBC; // CBC = Cypher Block Chaining
                aesCryptoServiceProvider.Padding = PaddingMode.PKCS7;

                aesCryptoServiceProvider.Key = key;
                aesCryptoServiceProvider.IV = initializationVector;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                                 aesCryptoServiceProvider.CreateEncryptor(),
                                                                 CryptoStreamMode.Write);
                    cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                    cryptoStream.FlushFinalBlock();

                    return memoryStream.ToArray();
                }
            }
        }


        public byte[] DecryptUsingAES(byte[] dataToDecrypt, byte[] key, byte[] initializationVector)
        {
            using (AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider())
            {
                aesCryptoServiceProvider.Mode = CipherMode.CBC; // CBC = Cypher Block Chaining
                aesCryptoServiceProvider.Padding = PaddingMode.PKCS7;

                aesCryptoServiceProvider.Key = key;
                aesCryptoServiceProvider.IV = initializationVector;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                                 aesCryptoServiceProvider.CreateDecryptor(),
                                                                 CryptoStreamMode.Write);
                    cryptoStream.Write(dataToDecrypt, 0, dataToDecrypt.Length);
                    cryptoStream.FlushFinalBlock();

                    return memoryStream.ToArray();
                }
            }
        }


        public void AssignNewRSAKey(bool storeKeysInDB = false)
        {
            // here we are saying we want to use a 2048 bit key
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(2048))
            {
                RSA.PersistKeyInCsp = false;
                _publicKey = RSA.ExportParameters(false);
                _privateKey = RSA.ExportParameters(true);

                if (storeKeysInDB)
                {
                    RSAKeys rsaKeys = new RSAKeys();
                    rsaKeys.RsaPrivateKey = RSA.ToXmlString(true); // true gets the private key
                    rsaKeys.RsaPublicKey = RSA.ToXmlString(false);  // false gets the public key

                    _jsonDataBaseInstance = new JSONDataBase();
                    _jsonDataBaseInstance.AddRSAKey(rsaKeys);
                }
            }
        }

        public byte[] EncryptDataUsingRSA(byte[] dataToEncrypt, bool getKeyFromDataBase = false)
        {
            byte[] cipherBytes;

            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(2048))
            {
                RSA.PersistKeyInCsp = false;

                if (getKeyFromDataBase)
                {
                    RSAKeys rsaKeys = _jsonDataBaseInstance.GetRSAKeys();
                    RSA.FromXmlString(rsaKeys.RsaPublicKey);
                }
                else
                {
                    RSA.ImportParameters(_publicKey);
                }

                cipherBytes = RSA.Encrypt(dataToEncrypt, true);
            }

            return cipherBytes;
        }


        public byte[] DecryptDataUsingRSA(byte[] dataToEncrypt, bool getKeyFromDataBase = false)
        {
            byte[] dataToSendBack;

            // using a 2048 bit key
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(2048))
            {
                RSA.PersistKeyInCsp = false; // is set to false because we are not using the key container

                if (getKeyFromDataBase)
                {
                    RSAKeys rsaKeys = _jsonDataBaseInstance.GetRSAKeys();
                    RSA.FromXmlString(rsaKeys.RsaPrivateKey);
                }
                else
                {
                    RSA.ImportParameters(_privateKey);
                }

                dataToSendBack = RSA.Decrypt(dataToEncrypt, true); // setting true here adds a padding scheme as an extra protection for our data
            }

            return dataToSendBack;
        }


        public void AssignNewRSAKeyAndStoreInCSP()
        {
            CspParameters cspParameters = new CspParameters(1);
            cspParameters.KeyContainerName = _cspContainerName;
            cspParameters.Flags = CspProviderFlags.UseMachineKeyStore;
            cspParameters.ProviderName = "Microsoft Strong Cryptographic Provider";

            RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider(cspParameters)
            {
                PersistKeyInCsp = true
            };

        }


        public void DeleteRSPkeyStoredInCSP()
        {
            CspParameters cspParameters = new CspParameters
            {
                KeyContainerName = _cspContainerName
            };

            RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider(cspParameters)
            {
                PersistKeyInCsp = false
            };

            rSACryptoServiceProvider.Clear();
        }


        public byte[] EncryptDataUsingRSAStoredinCSP(byte[] dataToEncrypt)
        {
            byte[] cipherBytes;

            CspParameters cspParameters = new CspParameters
            {
                KeyContainerName = _cspContainerName
            };

            using (RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider(2048, cspParameters))
            {
                cipherBytes = rSACryptoServiceProvider.Encrypt(dataToEncrypt, false);
            }

            return cipherBytes;
        }


        public byte[] DecryptDataUsingRSAStoredinCSP(byte[] dataToEncrypt, bool getKeyFromDataBase = false)
        {
            byte[] dataToSendBack;

            CspParameters cspParameters = new CspParameters
            {
                KeyContainerName = _cspContainerName
            };

            using (RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider(2048, cspParameters))
            {
                dataToSendBack = rSACryptoServiceProvider.Decrypt(dataToEncrypt, false);
            }

            return dataToSendBack;
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
