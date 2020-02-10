using StudyGuide.Classes.Examples;
using StudyGuide.Classes.Examples.Async;
using StudyGuide.Classes.Examples.Cryptography;
using StudyGuide.Classes.Examples.Generics;
using StudyGuide.Classes.Examples.InterviewQuestions;
using StudyGuide.Classes.Examples.LINQ;
using StudyGuide.Classes.Examples.SQLBulkCopy;
using System;
using System.Collections.Generic;

namespace StudyGuide
{
    class Program
    {
        static void Main(string[] args)
        {
            // test
            PrintMenu();

            do
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        RunDelegateExample();
                        break;

                    case "2":
                        RunPolymorphismExample();
                        break;

                    case "3":
                        RunInheritanceExample();
                        break;

                    case "4":

                        RunAbstractClassesExample();
                        break;

                    case "5":
                        RunInterfacesExample();
                        break;

                    case "6":
                        RunGenericsExample();
                        break;

                    case "7":
                        RunLINQExample();
                        break;

                    case "8":
                        RunAsyncExample();
                        break;

                    case "9":
                        RunCryptographyExample();
                        break;

                    case "10":
                        RunInterviewQuestionsExample();
                        break;

                    case "11":
                        RunSQLBulkCopyMenu();
                        break;

                    default:
                        Console.WriteLine("Sorry that option is not valid");
                        Console.WriteLine("");
                        Console.WriteLine("");
                        break;
                }

                PrintMenu();
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        private static void PrintMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("------ Main Menu ------");
            Console.WriteLine("-----------------------");
            Console.WriteLine("1 - Delegates");
            Console.WriteLine("2 - Polymorphism");
            Console.WriteLine("3 - Inheritance");
            Console.WriteLine("4 - Abstract Classes");
            Console.WriteLine("5 - Interfaces");
            Console.WriteLine("6 - Generics");
            Console.WriteLine("7 - LINQ");
            Console.WriteLine("8 - ASYNC Programming");
            Console.WriteLine("9 - Cryptography");
            Console.WriteLine("10 - Interview Example Questions");
            Console.WriteLine("11 - SQL Bulk Copy");
            Console.WriteLine("12 - Dependency Injection");
            Console.WriteLine("Esc - Exit Program");
        }

        private static void RunDelegateExample()
        {
            EventsAndDelegates.InvokeDelegate();
            EventsAndDelegates.InvokeDelegate2();
            EventsAndDelegates.InvokeDelegate3();
        }

        private static void RunPolymorphismExample()
        {
            PolymorphismBase PMB = new PolymorphismBase();
            PMB.PrintMessage("base class!");
            Polymorphism PM = new Polymorphism();
            PM.PrintMessage("overridden class!");
        }

        private static void RunInheritanceExample()
        {
            InheritanceBase IB = new InheritanceBase();
            IB.PrintMessage("base class!");
            Inheritance I = new Inheritance();
            I.PrintMessage("child class!");
        }

        private static void RunAbstractClassesExample()
        {
            DerivedDogClass DDC = new DerivedDogClass("Oliver");
            DDC.FoodToEat.Add("Dog Food");
            Console.WriteLine(String.Format("Dogs Name: {0}", DDC.Name));
            Console.WriteLine(String.Format("Can Dogs fly? {0}", DDC.CanFly));
            Console.WriteLine(String.Format("1st thing fed to Dog: {0}", DDC.FirstThingFed));

            DerivedCatClass DCC = new DerivedCatClass("Rouge");
            DCC.FoodToEat.Add("Cat Food");
            Console.WriteLine(String.Format("Cats Name: {0}", DCC.Name));
            Console.WriteLine(String.Format("Can Cats fly? {0}", DCC.CanFly));
            Console.WriteLine(String.Format("1st thing fed to Cat: {0}", DCC.FirstThingFed));

            DerivedBirdClass DBC = new DerivedBirdClass("Tweety");
            //DBC.FoodToEat.Add("Bird Food");
            Console.WriteLine(String.Format("Birds Name: {0}", DBC.Name));
            Console.WriteLine(String.Format("Can Birds fly? {0}", DBC.CanFly));
            Console.WriteLine(String.Format("1st thing fed to Bird: {0}", DBC.FirstThingFed));
        }

        private static void RunInterfacesExample()
        {
            List<IVehicle> vehiclesList = new List<IVehicle>();
            vehiclesList.Add(new ImplementedCarClass("Car"));
            vehiclesList.Add(new ImplementedFrieghtTrainClass("train"));

            foreach (IVehicle vehicle in vehiclesList)
            {
                if (vehicle.GetType() == typeof(ImplementedCarClass))
                {
                    vehicle.AddItemToVehicle("charlie");
                    vehicle.AddItemToVehicle("heather");
                }
                else if (vehicle.GetType() == typeof(ImplementedFrieghtTrainClass))
                {
                    vehicle.AddItemToVehicle("fruits");
                    vehicle.AddItemToVehicle("coal");
                    vehicle.AddItemToVehicle("ore");
                }

            }

            foreach (IVehicle vehicle in vehiclesList)
            {
                Console.WriteLine(String.Format("Vehicle Type: {0}", vehicle.VehicleType));
                Console.WriteLine(String.Format("Is Used To Transport Goods? {0}", vehicle.IsUsedToTransportGoods()));
                Console.WriteLine(String.Format("First Item added: {0}", vehicle.GetFirstItemInVehicle()));

                if (vehicle.GetType() == typeof(ImplementedCarClass))
                {
                    foreach (string person in (ImplementedCarClass)vehicle)
                    {
                        Console.WriteLine(String.Format("Person in Car: {0}", person));
                    }
                }
                else if (vehicle.GetType() == typeof(ImplementedFrieghtTrainClass))
                {
                    foreach (string item in (ImplementedFrieghtTrainClass)vehicle)
                    {
                        Console.WriteLine(String.Format("Item in Train: {0}", item));
                    }
                }
            }
        }

        private static void RunGenericsExample()
        {
            HighLevelGenericsExamples highLevelGenericsExamples = new HighLevelGenericsExamples();
            highLevelGenericsExamples.RunGenerics();
        }

        private static void RunLINQExample()
        {
            LINQExamples lINQExamples = new LINQExamples();
            lINQExamples.RunLinqMenu();
        }

        private static void RunAsyncExample()
        {
            AsyncMenu2 AM = new AsyncMenu2();
            AM.RunAsyncMenu();
        }

        private static void RunCryptographyExample()
        {
            CryptographyMenu C = new CryptographyMenu();
            C.RunCryptographyMenu();
        }

        private static void RunInterviewQuestionsExample()
        {
            InterviewQuestionsMenu IQ = new InterviewQuestionsMenu();
            IQ.RunInterviewQuestionsMenu();
        }


        private static void RunSQLBulkCopyMenu()
        {
            SQLBulkCopyMenu menu = new SQLBulkCopyMenu();
            menu.RunSQLBulkCopyMenu();
        }

        private static void RunDependencyInjectionMenu()
        {
            // .net - https://www.yogihosting.com/aspnet-core-dependency-injection/
            // Ninject - https://hackernoon.com/ddd-5a1x3zl2

        }
    }
}
