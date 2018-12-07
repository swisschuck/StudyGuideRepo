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
                    break;

                case "2":
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

        private void printCryptographyMenu()
        {
            Console.WriteLine("Cryptography Menu:");
            Console.WriteLine("----------------------");
            Console.WriteLine("1) ");
            Console.WriteLine("0) Back Home");
        }
        #endregion private methods
    }
}
