using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuide.Classes.Examples.Cryptography
{
    public class CryptographyMenu
    {
        #region fields
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

            switch (Console.ReadLine())
            {
                case "1":
                    RunSimpleRandomNumbersExample();
                    break;

                case "2":
                    RunRNGCryptoServiceRandomNumbersExample();
                    break;

                case "3":
                    break;

                case "4":
                    break;

                case "5":
                    break;

                case "0":
                    // go back to previous menu
                    return;

                default:
                    return;

            }
            Console.WriteLine(string.Empty);
            printCryptographyMenu();
            Console.ReadLine();
        }
        #endregion public methods


        #region private methods

        private void RunRNGCryptoServiceRandomNumbersExample()
        {
            Console.WriteLine("RNGCryptoService Simple Random Numbers started");
            Console.WriteLine();

            CryptographyExample CE = new CryptographyExample(32);

            for (int index = 1; index < 11; index++)
            {
                Console.WriteLine(String.Format("Random Number {0}: {1}", index, Convert.ToBase64String(CE.GenerateRandomNumber())));
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
            Console.WriteLine("0) Back Home");
        }



        #endregion private methods
    }
}
