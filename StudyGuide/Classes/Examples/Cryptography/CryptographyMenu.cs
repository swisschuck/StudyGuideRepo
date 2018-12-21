using StudyGuide.Database.JSON;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuide.Classes.Examples.Cryptography
{
    public class CryptographyMenu
    {
        #region fields

        const string _originalMessage = "Original Message To Hash";
        const string _originalMessage2 = "This is another message to Hash";
        const string _tempPassword = "V3ryC0mpl3xP455word";

        #endregion fields


        #region properties
        #endregion properties


        #region constructors

        public CryptographyMenu()
        {

        }
        #endregion constructors


        #region public methods

        public void RunCryptographyMenu()
        {
            Console.Clear();
            printCryptographyMenu();

            do
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        RunSimpleRandomNumbersExample();
                        break;

                    case "2":
                        RunRNGCryptoServiceRandomNumbersExample();
                        break;

                    case "3":
                        RunMD5Algorithm();
                        break;

                    case "4":
                        RunSHA1Algorithm();
                        break;

                    case "5":
                        RunSHA2Algorithm256();
                        break;

                    case "6":
                        RunSHA2Algorithm512();
                        break;

                    case "7":
                        RunHMACExample();
                        break;

                    case "8":
                        StoringPasswordsUsingSaltedHashes();
                        break;

                    case "9":
                        RunPasswordBasedKeyDerivationFunction();
                        break;

                    case "10":
                        RunEncryptionUsingDES();
                        break;

                    case "11":
                        RunEncryptionUsingTripleDES();
                        break;

                    case "12":
                        RunEncryptionUsingAES();
                        break;

                    case "13":
                        RunRsaWithRsaParameterKey();
                        break;

                    case "14":
                        RunRsaWithRsaParameterKeyFromDB();
                        break;

                    case "15":
                        RunRsaWithRsaParameterKeyFromCSP();
                        break;

                    case "0":
                        // go back to previous menu
                        return;

                    default:
                        return;

                }
                Console.WriteLine(string.Empty);
                printCryptographyMenu();
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }
        #endregion public methods


        #region private methods

        private static void RunRsaWithRsaParameterKeyFromCSP()
        {
            // CSP = Configuration Service Provider or Windows Key Container
            // these can be stores as either:
            //  1) User-level key containers (C:\Users\<user_name>\AppData\Roaming\Microsoft\Crypto\RSA). 
            //     These are only accessable by the user as they are stored in the users profile
            //  2) machine-level key container (C:\Users\All Users\Application Data\Microsoft\Crypto\RSA)
            //     These are stored on a global level that all users on the machine can access

            Console.WriteLine("Encryption Using RSA with Parameter key from CSP started");
            Console.WriteLine();

            CryptographyExample cryptographyExample = new CryptographyExample();

            const string originalMessage = "Some Text to Encrypt";
            Console.WriteLine(String.Format("Message before encryption: {0}", originalMessage));

            cryptographyExample.AssignNewRSAKeyAndStoreInCSP();

            byte[] encryptedMessage = cryptographyExample.EncryptDataUsingRSAStoredinCSP(Encoding.UTF8.GetBytes(originalMessage));
            Console.WriteLine(String.Format("Message after encryption: {0}", Encoding.UTF8.GetString(encryptedMessage)));

            byte[] decryptedMessage = cryptographyExample.DecryptDataUsingRSAStoredinCSP(encryptedMessage);
            Console.WriteLine(String.Format("Message after encryption: {0}", Encoding.UTF8.GetString(decryptedMessage), true));

            cryptographyExample.DeleteRSPkeyStoredInCSP();

            Console.WriteLine();
            Console.WriteLine("Encryption Using RSA with Parameter key from CSP ended");
        }

        private static void RunRsaWithRsaParameterKeyFromDB()
        {
            Console.WriteLine("Encryption Using RSA with Parameter key from DB started");
            Console.WriteLine();

            CryptographyExample cryptographyExample = new CryptographyExample();

            const string originalMessage = "Some Text to Encrypt";
            Console.WriteLine(String.Format("Message before encryption: {0}", originalMessage));

            cryptographyExample.AssignNewRSAKey(true);

            byte[] encryptedMessage = cryptographyExample.EncryptDataUsingRSA(Encoding.UTF8.GetBytes(originalMessage), true);
            Console.WriteLine(String.Format("Message after encryption: {0}", Encoding.UTF8.GetString(encryptedMessage)));

            byte[] decryptedMessage = cryptographyExample.DecryptDataUsingRSA(encryptedMessage);
            Console.WriteLine(String.Format("Message after encryption: {0}", Encoding.UTF8.GetString(decryptedMessage), true));


            Console.WriteLine();
            Console.WriteLine("Encryption Using RSA with Parameter key from DB ended");
        }

        private static void RunRsaWithRsaParameterKey()
        {
            Console.WriteLine("Encryption Using RSA with Parameter key started");
            Console.WriteLine();

            CryptographyExample cryptographyExample = new CryptographyExample();

            const string originalMessage = "Some Text to Encrypt";
            Console.WriteLine(String.Format("Message before encryption: {0}", originalMessage));

            cryptographyExample.AssignNewRSAKey();

            byte[] encryptedMessage = cryptographyExample.EncryptDataUsingRSA(Encoding.UTF8.GetBytes(originalMessage));
            Console.WriteLine(String.Format("Message after encryption: {0}", Encoding.UTF8.GetString(encryptedMessage)));

            byte[] decryptedMessage = cryptographyExample.DecryptDataUsingRSA(encryptedMessage);
            Console.WriteLine(String.Format("Message after encryption: {0}", Encoding.UTF8.GetString(decryptedMessage)));


            Console.WriteLine();
            Console.WriteLine("Encryption Using RSA with Parameter key ended");
        }

        private void RunEncryptionUsingAES()
        {
            Console.WriteLine("Encryption Using AES started");
            Console.WriteLine();

            CryptographyExample cryptographyExample = new CryptographyExample();

            // here we are creating a key that is 32 bytes in length or 256 bits, which is the max size of an AES key
            byte[] key = cryptographyExample.GenerateRandomNumber(32);

            // AES using a 16 byte Initialization Vector
            byte[] initializationVector = cryptographyExample.GenerateRandomNumber(16);
            const string originalMessage = "Text To Encrypt";

            Console.WriteLine(String.Format("Message before encryption: {0}", originalMessage));

            byte[] encryptedMessage = cryptographyExample.EncryptUsingAES(Encoding.UTF8.GetBytes(originalMessage), key, initializationVector);
            Console.WriteLine(String.Format("Message after encryption: {0}", Encoding.UTF8.GetString(encryptedMessage)));

            byte[] decryptedMessage = cryptographyExample.DecryptUsingAES(encryptedMessage, key, initializationVector);
            Console.WriteLine(String.Format("Message after decryption: {0}", Encoding.UTF8.GetString(decryptedMessage)));

            Console.WriteLine();
            Console.WriteLine("Encryption Using AES ended");
        }

        private void RunEncryptionUsingTripleDES()
        {
            Console.WriteLine("Encryption Using Triple DES started");
            Console.WriteLine();

            CryptographyExample cryptographyExample = new CryptographyExample(8);

            // we are using 24 bytes to make use of the tripple key variants of triple DES
            // 24 bytes represents three 64 bit keys or three 8 byte keys
            // under the covers our data will be encrypted with key1, then with key2, then with key3
            byte[] key = cryptographyExample.GenerateRandomNumber(24);


            // we could just send in 16 bytes and it will still work fine, however this means that
            // under the covers our data will get encrypted using the first key, then encrypted again using the 2nd key, then once more
            // using the first key again.
            //byte[] key = cryptographyExample.GenerateRandomNumber(16); 


            byte[] initializationVector = cryptographyExample.GenerateRandomNumber(8);
            const string originalMessage = "Text To Encrypt";

            Console.WriteLine(String.Format("Message before encryption: {0}", originalMessage));

            byte[] encryptedMessage = cryptographyExample.EncryptUsingTripleDES(Encoding.UTF8.GetBytes(originalMessage), key, initializationVector);
            Console.WriteLine(String.Format("Message after encryption: {0}", Encoding.UTF8.GetString(encryptedMessage)));

            byte[] decryptedMessage = cryptographyExample.DecryptUsingTripleDES(encryptedMessage, key, initializationVector);
            Console.WriteLine(String.Format("Message after decryption: {0}", Encoding.UTF8.GetString(decryptedMessage)));

            Console.WriteLine();
            Console.WriteLine("Encryption Using Triple DES ended");
        }

        private void RunEncryptionUsingDES()
        {
            Console.WriteLine("Encryption Using DES started");
            Console.WriteLine();

            CryptographyExample cryptographyExample = new CryptographyExample(8);

            byte[] key = cryptographyExample.GenerateRandomNumber();
            byte[] initializationVector = cryptographyExample.GenerateRandomNumber();
            const string originalMessage = "Text To Encrypt";

            Console.WriteLine(String.Format("Message before encryption: {0}", originalMessage));

            byte[] encryptedMessage = cryptographyExample.EncryptUsingDES(Encoding.UTF8.GetBytes(originalMessage), key, initializationVector);
            Console.WriteLine(String.Format("Message after encryption: {0}", Encoding.UTF8.GetString(encryptedMessage)));

            byte[] decryptedMessage = cryptographyExample.DecryptUsingDES(encryptedMessage, key, initializationVector);
            Console.WriteLine(String.Format("Message after decryption: {0}", Encoding.UTF8.GetString(decryptedMessage)));

            Console.WriteLine();
            Console.WriteLine("Encryption Using DES ended");
        }


        private void RunPasswordBasedKeyDerivationFunction()
        {
            Console.WriteLine("Password Based Key Derivation Functions started");


            CryptographyExample.HashUsingPasswordBasedKeyDerivationFunction(_tempPassword, 100);
            CryptographyExample.HashUsingPasswordBasedKeyDerivationFunction(_tempPassword, 1000);
            CryptographyExample.HashUsingPasswordBasedKeyDerivationFunction(_tempPassword, 10000);
            CryptographyExample.HashUsingPasswordBasedKeyDerivationFunction(_tempPassword, 50000);
            CryptographyExample.HashUsingPasswordBasedKeyDerivationFunction(_tempPassword, 100000);
            CryptographyExample.HashUsingPasswordBasedKeyDerivationFunction(_tempPassword, 200000);
            CryptographyExample.HashUsingPasswordBasedKeyDerivationFunction(_tempPassword, 500000);


            Console.WriteLine("Password Based Key Derivation Functions ended");
        }

        private void StoringPasswordsUsingSaltedHashes()
        {
            // using salted hashes

            Console.WriteLine("Encrypting Passwords started");

            Console.WriteLine(string.Empty);

            User U = new User();

            Console.WriteLine("please enter the user name");
            U.UserName = Console.ReadLine().Trim();

            //Console.WriteLine("please enter the password");
            //U.Password = Console.ReadLine().Trim();

            byte[] salt = CryptographyExample.GenerateSalt();
            byte[] saltedHash = CryptographyExample.HashPasswordWithSalt(Encoding.UTF8.GetBytes(_tempPassword), salt);
            U.Password = Convert.ToBase64String(saltedHash);

            JSONDataBase JsonDB = new JSONDataBase();
            JsonDB.AddUser(U);


            Console.WriteLine("Encrypting Passwords ended");
            Console.WriteLine(string.Empty);
        }

        private void RunHMACExample()
        {
            // Hashed Message Authentication Codes
            Console.WriteLine("Hashed Message Authentication Codes started");

            Console.WriteLine(String.Format("Message before Hashing: {0}", _originalMessage));
            Console.WriteLine(string.Empty);

            byte[] keyToUse = CryptographyExample.GenerateKey();


            byte[] MD5Hash = CryptographyExample.ComputeMd5HashWithKey(Encoding.UTF8.GetBytes(_originalMessage), keyToUse);
            Console.WriteLine(String.Format("Message after MD5 Hash: {0}", Convert.ToBase64String(MD5Hash)));

            byte[] SHA1Hash = CryptographyExample.ComputeSha1HashWithKey(Encoding.UTF8.GetBytes(_originalMessage), keyToUse);
            Console.WriteLine(String.Format("Message after SHA1 Hash: {0}", Convert.ToBase64String(SHA1Hash)));

            byte[] SHA2Hash256 = CryptographyExample.ComputeSha2Hash256WithKey(Encoding.UTF8.GetBytes(_originalMessage), keyToUse);
            Console.WriteLine(String.Format("Message after SHA2 (256) Hash: {0}", Convert.ToBase64String(SHA2Hash256)));

            byte[] SHA2Hash512 = CryptographyExample.ComputeSha2Hash512WithKey(Encoding.UTF8.GetBytes(_originalMessage), keyToUse);
            Console.WriteLine(String.Format("Message after SHA2 (512) Hash: {0}", Convert.ToBase64String(SHA2Hash512)));

            Console.WriteLine(string.Empty);
            Console.WriteLine("Hashed Message Authentication Codes ended");
        }



        private void RunSHA2Algorithm512()
        {
            Console.WriteLine("SHA2 (512) Hash Algorithm started");

            Console.WriteLine(String.Format("Message before Hash: {0}", _originalMessage));

            byte[] hashedMessage = CryptographyExample.ComputeSha2Hash512(Encoding.UTF8.GetBytes(_originalMessage));

            Console.WriteLine(String.Format("Message after Hash: {0}", Convert.ToBase64String(hashedMessage)));

            Console.WriteLine("SHA2 (512) Hash Algorithm ended");
        }


        private void RunSHA2Algorithm256()
        {
            Console.WriteLine("SHA2 (256) Hash Algorithm started");

            Console.WriteLine(String.Format("Message before Hash: {0}", _originalMessage));

            byte[] hashedMessage = CryptographyExample.ComputeSha2Hash256(Encoding.UTF8.GetBytes(_originalMessage));

            Console.WriteLine(String.Format("Message after Hash: {0}", Convert.ToBase64String(hashedMessage)));

            Console.WriteLine("SHA2 (256) Hash Algorithm ended");
        }


        private void RunSHA1Algorithm()
        {
            Console.WriteLine("SHA1 Hash Algorithm started");

            Console.WriteLine(String.Format("Message before Hash: {0}", _originalMessage));

            byte[] hashedMessage = CryptographyExample.ComputeSha1Hash(Encoding.UTF8.GetBytes(_originalMessage));

            Console.WriteLine(String.Format("Message after Hash: {0}", Convert.ToBase64String(hashedMessage)));

            Console.WriteLine("SHA1 Hash Algorithm ended");
        }

        private void RunMD5Algorithm()
        {
            Console.WriteLine("MD5 Hash Algorithm started");

            Console.WriteLine(String.Format("Message before Hash: {0}", _originalMessage));

            byte[] hashedMessage = CryptographyExample.ComputeMd5Hash(Encoding.UTF8.GetBytes(_originalMessage));

            Console.WriteLine(String.Format("Message after Hash: {0}", Convert.ToBase64String(hashedMessage)));

            Console.WriteLine("MD5 Hash Algorithm ended");

        }


        private void RunRNGCryptoServiceRandomNumbersExample()
        {
            Console.WriteLine("RNGCryptoService Simple Random Numbers started");
            Console.WriteLine();

            CryptographyExample CE = new CryptographyExample(32);

            for (int index = 1; index < 11; index++)
            {
                Console.WriteLine(String.Format("Random Number {0}: {1}", index, Convert.ToBase64String(CE.GenerateRandomNumber())));
                //check the console readout for this comment:
                //The final '==' sequence indicates that the last group contained only one byte, and '=' indicates that it contained two bytes.
            }

            Console.WriteLine();
            Console.WriteLine("RNGCryptoService Simple Random Numbers complete");
        }


        private void RunSimpleRandomNumbersExample()
        {
            Console.WriteLine("Generating Simple Random Numbers started");

            Random randomObject = new Random(250);

            for (int index = 0; index < 10; index++)
            {
                Console.WriteLine("{0,3}   ", randomObject.Next(-10, 11));
            }

            Console.WriteLine("Generating Simple Random Numbers complete");
        }


        private void printCryptographyMenu()
        {
            Console.WriteLine("Cryptography Menu:");
            Console.WriteLine("----------------------");
            Console.WriteLine("1) Random Numbers");
            Console.WriteLine("2) RNG Crypto Service Random Number");
            Console.WriteLine("3) MD-5 Algorithm");
            Console.WriteLine("4) SHA-1 Algorithm");
            Console.WriteLine("5) SHA-2 (256) Algorithm");
            Console.WriteLine("6) SHA-2 (512) Algorithm");
            Console.WriteLine("7) Hashed Message Authentication Code");
            Console.WriteLine("8) Storing Passwords Using Salted Hashes");
            Console.WriteLine("9) Password Based Key Derivation Functions");
            Console.WriteLine("10) Encryption Using DES");
            Console.WriteLine("11) Encryption Using Triple DES");
            Console.WriteLine("12) Encryption Using AES");
            Console.WriteLine("13) Encryption Using RSA with Parameter key");
            Console.WriteLine("14) Encryption Using RSA with Parameter key from DB");
            Console.WriteLine("15) Encryption Using RSA with Parameter key from CSP");
            Console.WriteLine("0) Back Home");
        }



        #endregion private methods
    }
}
