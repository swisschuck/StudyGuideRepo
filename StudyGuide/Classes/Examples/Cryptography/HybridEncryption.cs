using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuide.Classes.Examples.Cryptography
{
    public class HybridEncryption
    {
        #region fields

        CryptographyExample _cryptographyExample;

        #endregion fields


        #region properties
        #endregion properties


        #region constructors

        public HybridEncryption()
        {
            _cryptographyExample = new CryptographyExample();
        }

        #endregion constructors


        #region public methods

        public EncryptedPacket EncryptData(byte[] originalMessage, RsaWithRsaParameterKey rsaParams)
        {
            // Sender generates AES session key
            byte[] sessionKey = _cryptographyExample.GenerateRandomNumber(32);

            // Sender generates Initialization Vector 
            byte[] initializationVector = _cryptographyExample.GenerateRandomNumber(16);

            // Sender stores that IV in the packet object
            EncryptedPacket EP = new EncryptedPacket
            {
                IV = initializationVector
            };

            // Sender encrypts data using AES
            EP.EncryptedData = _cryptographyExample.EncryptUsingAES(originalMessage, sessionKey, EP.IV);

            //Sender encrypts the session key with RSA
            EP.EncryptedSessionKey = rsaParams.EncryptData(sessionKey);

            return EP;
        }


        public byte[] DecryptData(EncryptedPacket EP, RsaWithRsaParameterKey rsaParams)
        {
            // Receiver decrypts AES session key with RSA
            byte[] decryptedSessionKey = rsaParams.DecryptData(EP.EncryptedSessionKey);

            // Receiver decrypts the data wuth AES using the decrypted session key
            byte[] decryptedData = _cryptographyExample.DecryptUsingAES(EP.EncryptedData, decryptedSessionKey, EP.IV);

            return decryptedData;
        }



        public EncryptedPacket EncryptDataWithIntegrity(byte[] originalMessage, RsaWithRsaParameterKey rsaParams)
        {
            // Sender generates AES session key
            byte[] sessionKey = _cryptographyExample.GenerateRandomNumber(32);

            // Sender generates Initialization Vector 
            byte[] initializationVector = _cryptographyExample.GenerateRandomNumber(16);

            // Sender stores that IV in the packet object
            EncryptedPacket EP = new EncryptedPacket
            {
                IV = initializationVector
            };

            // Sender encrypts data using AES
            EP.EncryptedData = _cryptographyExample.EncryptUsingAES(originalMessage, sessionKey, EP.IV);

            //Sender encrypts the session key with RSA
            EP.EncryptedSessionKey = rsaParams.EncryptData(sessionKey);

            // create an HMAC using the session key and store an HMAC of the encrypted data in the packet
            using (HMACSHA256 hmac = new HMACSHA256(sessionKey))
            {
                EP.Hmac = hmac.ComputeHash(EP.EncryptedData);
            }

            return EP;
        }


        public byte[] DecryptDataWithIntegrity(EncryptedPacket EP, RsaWithRsaParameterKey rsaParams)
        {
            // Receiver decrypts AES session key with RSA
            byte[] decryptedSessionKey = rsaParams.DecryptData(EP.EncryptedSessionKey);


            // Receiver compares 
            using (HMACSHA256 hmac = new HMACSHA256(decryptedSessionKey))
            {
                byte[] hmacToCheck = hmac.ComputeHash(EP.EncryptedData);

                if (!CompareHashes(EP.Hmac, hmacToCheck))
                {
                    throw new CryptographicException("HMAC for decryption does not match encrypted packet HMAC");
                }
            }

            // Receiver decrypts the data wuth AES using the decrypted session key
            byte[] decryptedData = _cryptographyExample.DecryptUsingAES(EP.EncryptedData, decryptedSessionKey, EP.IV);

            return decryptedData;
        }


        #region Hybrid with Signature

        public EncryptedPacket EncryptDataWithSignature(byte[] originalMessage, RsaWithRsaParameterKey rsaParams, DigitalSignatures DS)
        {
            // Sender generates AES session key
            byte[] sessionKey = _cryptographyExample.GenerateRandomNumber(32);

            // Sender generates Initialization Vector 
            byte[] initializationVector = _cryptographyExample.GenerateRandomNumber(16);

            // Sender stores that IV in the packet object
            EncryptedPacket EP = new EncryptedPacket
            {
                IV = initializationVector
            };

            // Sender encrypts data using AES
            EP.EncryptedData = _cryptographyExample.EncryptUsingAES(originalMessage, sessionKey, EP.IV);

            //Sender encrypts the session key with RSA
            EP.EncryptedSessionKey = rsaParams.EncryptData(sessionKey);

            // Sender generates hash mac using our session key
            using (HMACSHA256 hmac = new HMACSHA256(sessionKey))
            {
                EP.Hmac = hmac.ComputeHash(EP.EncryptedData);
            }

            //Sender signs the message with a digital signature
            EP.Signature = DS.SignData(EP.Hmac);

            return EP;
        }

        public byte[] DecryptDataWithSignature(EncryptedPacket EP, RsaWithRsaParameterKey rsaParams, DigitalSignatures DS)
        {
            // Receiver decrypts AES session key with RSA
            byte[] decryptedSessionKey = rsaParams.DecryptData(EP.EncryptedSessionKey);


            // Receiver compares 
            using (HMACSHA256 hmac = new HMACSHA256(decryptedSessionKey))
            {
                byte[] hmacToCheck = hmac.ComputeHash(EP.EncryptedData);

                if (!CompareHashes(EP.Hmac, hmacToCheck))
                {
                    throw new CryptographicException("HMAC for decryption does not match encrypted packet HMAC");
                }

                if (!DS.VerifySignature(EP.Hmac, EP.Signature))
                {
                    throw new CryptographicException("Digital Signature cannot be verified");
                }
            }

            // Receiver decrypts the data wuth AES using the decrypted session key
            byte[] decryptedData = _cryptographyExample.DecryptUsingAES(EP.EncryptedData, decryptedSessionKey, EP.IV);

            return decryptedData;
        }

        #endregion Hybrid with Signature

        #endregion public methods


        #region private methods

        private static bool CompareHashes(byte[] hashOneToCompare, byte[] hashTwoToCompare)
        {
            // first just check to see if they match, we dont want to return this result right away as hackers can use the timing of a method
            // execution to figure out the hash
            bool compareResult = hashOneToCompare.Length == hashTwoToCompare.Length;

            // next we check every char in the hash
            for (int index = 0; index < hashOneToCompare.Length && index < hashTwoToCompare.Length; ++index)
            {
                compareResult &= hashOneToCompare[index] == hashTwoToCompare[index];
            }

            return compareResult;
        }


        /// <summary>
        /// this method is here as an example of how not to compare hashes
        /// </summary>
        /// <param name="hashOneToCompare"></param>
        /// <param name="hashTwoToCompare"></param>
        /// <returns></returns>
        private static bool CompareHashesTheWrongWay(byte[] hashOneToCompare, byte[] hashTwoToCompare)
        {
            if (hashOneToCompare.Length != hashTwoToCompare.Length)
            {
                return false;
            }

            for (int index = 0; index < hashOneToCompare.Length; ++index)
            {
                if (hashOneToCompare[index] != hashTwoToCompare[index])
                {
                    return false;
                }
            }

            return true;
        }

        #endregion private methods
    }
}
