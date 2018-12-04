using StudyGuide.Classes.Examples.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuide.Classes.Examples.LINQ
{
    public class LINQExamples
    {
        // LINQ NOTES
        // ===================================================================================
        // LINQ = Language INtegrated Query, a way to express queries against a data source directly from a .NET language
        //
        // LINQ Providers:
        //      - LINQ to Objects - in memory objects that make use of the IEnumeralbe interface
        //      - LINQ to SQL - works with SQL server databases
        //      - LINQ to Entities - works wih the Entity Framework
        //      - LINQ to XML - works with any XML document
        //      - we can make our own provider
        //      - plus many, many more
        //
        // 2 Different ways to express a LINQ query:
        //      - Query Syntax = will use a form similiar to a SQL query (from v in vendors where v.name.contains ...) using alias's, filters, ordering, and selecting
        //      - Method Syntax = will use the .net IEnumeralbe LINQ extension methods (vendors.Where(v => v.name.contains()...)
        //      - behind the scenes the Query syntax calls the Method syntax extensions


        #region fields
        #endregion fields


        #region properties
        #endregion properties


        #region constructors
        #endregion constructors


        #region public methods

        public void RunLinqMenu()
        {
            Console.Clear();
            printLINQMenu();

            switch (Console.ReadLine())
            {
                case "1":
                    RunLinqUsingQuerySyntax();
                    break;

                case "2":
                    RunLinqUsingMethodSyntax();
                    break;

                case "3":
                    break;

                case "4":
                    break;

                case "5":
                    break;

                case "6":
                    break;

                case "7":
                    break;

                case "8":
                    return;

                case "9":
                    return;

                case "0":
                    // go back to previous menu
                    return;

                default:
                    return;

            }

            printLINQMenu();
            Console.ReadLine();
        }


        #endregion public methods


        #region private methods

        private void RunLinqUsingQuerySyntax()
        {
            DataBaseUtilitiesExample dataBaseUtilitiesExample = new DataBaseUtilitiesExample(10);

            Console.WriteLine("");
            Console.WriteLine("LINQ using Query Syntax");
            Console.WriteLine("----------------------");

            var vendorsQuery = from v in dataBaseUtilitiesExample.ListOfVendors
                               where v.VendorID == 2
                               select v;


            PrintCollection(vendorsQuery.ToList());

            Console.WriteLine("");
            Console.WriteLine("");

        }


        private void RunLinqUsingMethodSyntax()
        {
            DataBaseUtilitiesExample dataBaseUtilitiesExample = new DataBaseUtilitiesExample(10);

            Console.WriteLine("");
            Console.WriteLine("LINQ using Method Syntax");
            Console.WriteLine("----------------------");

            var vendorsQuery = dataBaseUtilitiesExample.ListOfVendors
                                .Where(v => v.VendorID == 7 || v.VendorID == 2)
                                .OrderByDescending(v => v.VendorName);


            PrintCollection(vendorsQuery.ToList());


            Console.WriteLine("");
            Console.WriteLine("");

        }


        private void printLINQMenu()
        {
            Console.WriteLine("LINQ:");
            Console.WriteLine("----------------------");
            Console.WriteLine("1) LINQ Query Syntax");
            Console.WriteLine("2) LINQ Method Syntax");
            Console.WriteLine("0) Back Home");
        }

        private void PrintCollection(List<VendorExample> vendorsQuery)
        {
            foreach (VendorExample vx in vendorsQuery)
            {
                Console.WriteLine(String.Format("Vendor Name: {0}", vx.VendorName));
                Console.WriteLine(String.Format("Vendor ID: {0}", vx.VendorID.ToString()));
                Console.WriteLine(String.Format("Vendor Email: {0}", vx.VendorEmail));
            }
        }

        #endregion private methods
    }
}
