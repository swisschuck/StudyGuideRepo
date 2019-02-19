using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuide.Classes.Examples.SQLBulkCopy
{
    public class SQLBulkCopyMenu
    {
        #region fields

        private SQLBulkCopyTest _sqlBulkCopyTest;

        #endregion fields


        #region properties
        #endregion properties


        #region constructors

        public SQLBulkCopyMenu()
        {
            _sqlBulkCopyTest = new SQLBulkCopyTest();
        }


        #endregion constructors


        #region public methods

        public void RunSQLBulkCopyMenu()
        {
            Console.Clear();
            printBulkCopyMenu();

            do
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        RunTestDBConnection();
                        break;

                    case "2":
                        RunBasicBulkCopy();
                        break;

                    case "3":
                        RunBasicBulkCopyWithIdentity();
                        break;

                    case "4":
                        RunBulkCopyWithTransaction();
                        break;

                    case "5":
                        RunBulkCopyWithBatchSizes();
                        break;

                    case "6":
                        RunBulkCopyWithNotifications();
                        break;

                    case "7":
                        RunBulkCopyWithColumnMappings();
                        break;

                    case "8":
                        RunBulkCopyWithMultipleTables();
                        break;

                    case "0":
                        // go back to previous menu
                        return;

                    default:
                        return;

                }
                Console.WriteLine(string.Empty);
                printBulkCopyMenu();
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }

        #endregion public methods


        #region private methods

        private void RunTestDBConnection()
        {
            Console.WriteLine("RunTestDBConnection Started");

            Console.WriteLine($" Are we connected? {_sqlBulkCopyTest.TestSQLConnection()} ");

            Console.WriteLine("RunTestDBConnection Complete");
        }


        private void RunBasicBulkCopy()
        {
            Console.WriteLine("RunBasicBulkCopy Started");

            Console.WriteLine($" Did it work? {_sqlBulkCopyTest.PerformBasicBulkCopy()} ");

            Console.WriteLine("RunBasicBulkCopy Complete");
        }


        private void RunBasicBulkCopyWithIdentity()
        {
            Console.WriteLine("RunBasicBulkCopyWithIdentity Started");

            Console.WriteLine($" Did it work? {_sqlBulkCopyTest.PerformBasicBulkCopyWithIdentity()} ");

            Console.WriteLine("RunBasicBulkCopyWithIdentity Complete");
        }


        private void RunBulkCopyWithTransaction()
        {
            Console.WriteLine("RunBulkCopyWithTransaction Started");

            Console.WriteLine($" Did it work? {_sqlBulkCopyTest.PerformBulkCopyWithTransaction()} ");

            Console.WriteLine("RunBulkCopyWithTransaction Complete");
        }

        private void RunBulkCopyWithBatchSizes()
        {
            Console.WriteLine("RunBulkCopyWithBatchSizes Started");

            Console.WriteLine($" Did it work? {_sqlBulkCopyTest.PerformBulkCopyWithBatchSizes()} ");

            Console.WriteLine("RunBulkCopyWithBatchSizes Complete");
        }


        private void RunBulkCopyWithNotifications()
        {
            Console.WriteLine("RunBulkCopyWithNotifications Started");

            Console.WriteLine($" Did it work? {_sqlBulkCopyTest.PerformBulkCopyWithNotifications()} ");

            Console.WriteLine("RunBulkCopyWithNotifications Complete");
        }


        private void RunBulkCopyWithColumnMappings()
        {
            Console.WriteLine("RunBulkCopyWithNotifications Started");

            Console.WriteLine($" Did it work? {_sqlBulkCopyTest.PerformBulkCopyWithColumnMappings()} ");

            Console.WriteLine("RunBulkCopyWithNotifications Complete");
        }

        private void RunBulkCopyWithMultipleTables()
        {
            Console.WriteLine("RunBulkCopyWithMultipleTables Started");

            Console.WriteLine($" Did it work? {_sqlBulkCopyTest.PerformBulkCopyMultipleTables()} ");

            Console.WriteLine("RunBulkCopyWithMultipleTables Complete");
        }



        private void printBulkCopyMenu()
        {
            Console.WriteLine("Bulk Copy Menu:");
            Console.WriteLine("----------------------");
            Console.WriteLine("1) Test DB Connection");
            Console.WriteLine("2) Run Basic Bulk Copy");
            Console.WriteLine("3) Run Basic Bulk Copy with identity");
            Console.WriteLine("4) Bulk Copy with transactions");
            Console.WriteLine("5) Bulk Copy with batch size");
            Console.WriteLine("6) Bulk Copy with notifications");
            Console.WriteLine("7) Bulk Copy with Column Mappings");
            Console.WriteLine("8) Bulk Copy with Multiple Tables");

            Console.WriteLine("0) Back Home");
        }

        #endregion private methods
    }
}
