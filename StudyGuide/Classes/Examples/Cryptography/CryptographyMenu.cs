using StudyGuide.Database.JSON;
using System;
using System.Collections.Generic;
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

        private void StoringPasswordsUsingSaltedHashes()
        {
            // using salted hashes

            Console.WriteLine("Encrypting Passwords started");

            Console.WriteLine(string.Empty);

            User U = new User();

            Console.WriteLine("please enter the user name");
            U.UserName = Console.ReadLine().Trim();

            Console.WriteLine("please enter the password");
            U.Password = Console.ReadLine().Trim();

            JSONDataBase JsonDB = new JSONDataBase();
            JsonDB.DeleteUser(U);


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
            Console.WriteLine("Generating Simple Random Numbers");

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
            Console.WriteLine("0) Back Home");
        }



        #endregion private methods
    }
}
