using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuide.Classes.Examples.Generics
{
    public class HighLevelGenericsExamples
    {
        #region fields

        private List<string> _listOfStrings;

        #endregion fields


        #region properties
        #endregion properties


        #region constructors
        #endregion constructors


        #region public methods

        public void RunGenerics()
        {
            Console.Clear();
            printGenericsMenu();

            switch (Console.ReadLine())
            {
                case "1":
                    RunGenericDotNetLists();
                    break;

                case "2":
                    RunQueueGenerics();
                    break;

                case "3":
                    RunStackGenerics();
                    break;

                case "4":
                    RunHashSetGenerics();
                    break;

                case "5":
                    RunLinkedListGenerics();
                    break;

                case "6":
                    RunDictionaryGenerics();
                    break;

                case "7":
                    RunBasicGenericClass();
                    break;

                case "8":
                    RunGenericClassWithConstraints();
                    return;

                case "9":
                    RunGenericsOtherExamples();
                    return;

                case "0":
                    // go back to previous menu
                    return;

                default:
                    return;

            }

            printGenericsMenu();
            Console.ReadLine();
        }
        #endregion public methods


        #region private methods

        private void RunGenericsOtherExamples()
        {
            Console.WriteLine("Using Interfaces as a parameter - List");
            Console.WriteLine("-----------------------------------------------------");

            EmailUtilitiesExample emailUtilitiesExample = new EmailUtilitiesExample();
            List<VendorExample> vendorsList = new List<VendorExample>();

            for (int index = 0; index < 4; index++)
            {
                VendorExample vendorExample = new VendorExample(String.Format("some vendor name{0}", index.ToString()));
                vendorsList.Add(vendorExample);
            }

            emailUtilitiesExample.SendVendorsEmail(vendorsList);

            Console.WriteLine("");
            Console.WriteLine("");
            //=======================================================================================
            //=======================================================================================
            Console.WriteLine("Using Interfaces as a parameter - Array");
            Console.WriteLine("-----------------------------------------------------");


            VendorExample[] vendorsArray = new VendorExample[3];

            for (int index = 0; index < vendorsArray.Length; index++)
            {
                VendorExample vendorExample = new VendorExample(String.Format("some vendor name{0}", index.ToString()));
                vendorsArray[index] = vendorExample;
            }

            emailUtilitiesExample.SendVendorsEmail(vendorsArray);

            Console.WriteLine("");
            Console.WriteLine("");
            //=======================================================================================
            //=======================================================================================
            Console.WriteLine("Using Interfaces as a return type - List");
            Console.WriteLine("-----------------------------------------------------");

            DataBaseUtilitiesExample dataBaseUtilitiesExample = new DataBaseUtilitiesExample();
            List<VendorExample> blah = dataBaseUtilitiesExample.GetVendors<List<VendorExample>>(new List<VendorExample>()).ToList();

            foreach (VendorExample ex in blah)
            {
                Console.WriteLine(String.Format("vendor list: {0}", ex.VendorName));
            }
            Console.WriteLine("");
            Console.WriteLine("");


            Console.WriteLine("Using Interfaces as a return type - Array");
            Console.WriteLine("-----------------------------------------------------");

            VendorExample[] blah2 = dataBaseUtilitiesExample.GetVendors<VendorExample[]>(new VendorExample[1]).ToArray();

            foreach (VendorExample ex in blah2)
            {
                Console.WriteLine(String.Format("vendor list: {0}", ex.VendorName));
            }
            Console.WriteLine("");
            Console.WriteLine("");
            //=======================================================================================
            //=======================================================================================
            Console.WriteLine("Using Yield as a return type");
            Console.WriteLine("-----------------------------------------------------");

            foreach (VendorExample ex in dataBaseUtilitiesExample.GetVendorsWithIterator())
            {
                Console.WriteLine(String.Format("vendor list: {0}", ex.VendorName));
            }
        }


        private void RunGenericClassWithConstraints()
        {
            GenericClassWithConstraints<int> genericClassWithConstraints = new GenericClassWithConstraints<int>(1);

            Console.WriteLine(genericClassWithConstraints.RunSqlStatement<string, string>("someQueryHere", "myTableName"));
        }


        private void RunBasicGenericClass()
        {
            Console.WriteLine("Creating a new instance of the GenericClass using int");
            Console.WriteLine("-----------------------------------------------------");

            GenericClass<int> intGenericClass = new GenericClass<int>(5, "blah");

            Console.WriteLine(String.Format("GenericResult: {0}", intGenericClass.GenericResult));
            Console.WriteLine(String.Format("Message: {0}", intGenericClass.Message));
            Console.WriteLine(String.Format("GetResult(): {0}", intGenericClass.GetResult<int>()));
            Console.WriteLine("");
            Console.WriteLine("");



            Console.WriteLine("Creating a new instance of the GenericClass using bool");
            Console.WriteLine("------------------------------------------------------");

            GenericClass<bool> boolGenericClass = new GenericClass<bool>(true, "blah2");

            Console.WriteLine(String.Format("GenericResult: {0}", boolGenericClass.GenericResult));
            Console.WriteLine(String.Format("Message: {0}", boolGenericClass.Message));
            Console.WriteLine(String.Format("GetResult(): {0}", boolGenericClass.GetResult<bool>()));
            Console.WriteLine("");
            Console.WriteLine("");



            Console.WriteLine("Creating a new instance of the GenericClass using string");
            Console.WriteLine("--------------------------------------------------------");

            GenericClass<string> stringGenericClass = new GenericClass<string>("stuff", "blah3");

            Console.WriteLine(String.Format("GenericResult: {0}", stringGenericClass.GenericResult));
            Console.WriteLine(String.Format("Message: {0}", stringGenericClass.Message));
            Console.WriteLine(String.Format("GetResult(): {0}", stringGenericClass.GetResult<string>()));
            Console.WriteLine("");
            Console.WriteLine("");



            Console.WriteLine("Invalid GetResult");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine(String.Format("intGenericClass GetResult(): {0}", intGenericClass.GetResult<string>()));
            Console.WriteLine("");
            Console.WriteLine("");
        }

        private void RunDictionaryGenerics()
        {
            Dictionary<string, GeneralExampleClass> myDic = new Dictionary<string, GeneralExampleClass>();

            for (int index = 0; index < 6; index++)
            {
                myDic.Add(String.Format("Charlie{0}", index), new GeneralExampleClass()
                {
                    MyPublicProperty = String.Format("This is a {0} employee", index % 2 == 0 ? "good" : "bad")
                });
            }

            foreach (KeyValuePair<string, GeneralExampleClass> kvp in myDic)
            {
                Console.WriteLine(String.Format("key: {0}  value: {1}", kvp.Key, kvp.Value.MyPublicProperty));
            }

            Console.WriteLine("");
            Console.WriteLine("Now lets get an item from the Dictionary by key:");
            Console.WriteLine("-------------------------------");
            Console.WriteLine(String.Format("Get Key Charlie2 from Dictionary: {0}", myDic["Charlie2"].MyPublicProperty));
            Console.WriteLine("");
            Console.WriteLine("");
        }

        private void RunLinkedListGenerics()
        {
            // This generic type allows fast inserts and removes. It implements a classic linked list. Each object is separately allocated.
            // In the LinkedList, certain operations do not require the whole collection to be copied. But in many common cases LinkedList hinders performance.
            LinkedList<int> myLinkedList = new LinkedList<int>();

            myLinkedList.AddFirst(1);
            Console.WriteLine(String.Format("Added {0} as the first item", 1));

            myLinkedList.AddFirst(2);
            Console.WriteLine(String.Format("Added {0} as the first item", 2));

            myLinkedList.AddFirst(3);
            Console.WriteLine(String.Format("Added {0} as the first item", 3));

            myLinkedList.AddLast(5);
            Console.WriteLine(String.Format("Added {0} as the last item", 5));

            foreach (int myNum in myLinkedList)
            {
                Console.WriteLine(String.Format("Item in LinkedList: {0}", myNum));
            }

            Console.WriteLine(String.Format("Last Item in LinkedList: {0}", myLinkedList.Last()));
            Console.WriteLine(String.Format("Previous to Last Item in LinkedList: {0}", myLinkedList.Last.Previous.Value));
        }

        private void RunHashSetGenerics()
        {
            // A HashSet provides high-performance set operations. A set is a collection that contains no duplicate elements, 
            // and whose elements are in no particular order. This can be really useful for many things but object hash sets are
            // a little funky in that the hash is using a memory location to the object so you can add multiple objects that contain the
            // the same values but we cannot add the same exact object twice...this is not demoed below.

            HashSet<int> myHashSet = new HashSet<int>();

            myHashSet.Add(1);
            Console.WriteLine(String.Format("Item to HashSet: {0}", 1.ToString()));

            myHashSet.Add(2);
            Console.WriteLine(String.Format("Item to HashSet: {0}", 2.ToString()));

            myHashSet.Add(3);
            Console.WriteLine(String.Format("Item to HashSet: {0}", 3.ToString()));

            Console.WriteLine("");
            Console.WriteLine("Now lets see whats in the hash:");
            Console.WriteLine("-------------------------------");

            foreach (int myNum in myHashSet)
            {
                Console.WriteLine(String.Format("Item in Hash: {0}", myNum));
            }

            Console.WriteLine("");
            myHashSet.Add(3);
            Console.WriteLine(String.Format("Try to add {0} to HashSet again: ", 3.ToString()));


            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");

            foreach (int myNum in myHashSet)
            {
                Console.WriteLine(String.Format("Item in Hash: {0}", myNum));
            }

        }

        private void RunStackGenerics()
        {
            // A Stack generic type represents a Last-in, first-out (LIFO) collection of objects.

            Stack<GeneralExampleClass> myStack = new Stack<GeneralExampleClass>();

            // here we are adding objects to the Queue list the only way you can via the Enqueue method.
            GeneralExampleClass blah1 = new GeneralExampleClass() { MyPublicProperty = "blah 1" };
            myStack.Push(blah1);
            Console.WriteLine("Added Stack Item: blah 1");

            myStack.Push(new GeneralExampleClass() { MyPublicProperty = "blah 3" });
            Console.WriteLine("Added Stack Item: blah 3");

            myStack.Push(new GeneralExampleClass() { MyPublicProperty = "blah 5" });
            Console.WriteLine("Added Stack Item: blah 5");

            myStack.Push(new GeneralExampleClass() { MyPublicProperty = "blah 2" });
            Console.WriteLine("Added Stack Item: blah 2");






            Console.WriteLine("Stack Items:");
            Console.WriteLine("-----------------");
            Console.WriteLine("");

            while (myStack.Count > 0)
            {
                GeneralExampleClass generalExampleClass = myStack.Pop();
                Console.WriteLine(String.Format("Popped Stack Item: {0}", generalExampleClass.MyPublicProperty));
            }

            if (myStack.Count == 0)
            {
                Console.WriteLine("Stack is empty!");
            }

            Console.WriteLine("");
            Console.WriteLine("");

        }

        private void RunQueueGenerics()
        {
            // A Queue generic type represents a first-in, first-out (FIFO) collection of objects.

            Queue<GeneralExampleClass> myQueue = new Queue<GeneralExampleClass>();

            // here we are adding objects to the Queue list the only way you can via the Enqueue method.
            GeneralExampleClass blah1 = new GeneralExampleClass() { MyPublicProperty = "blah 1" };
            myQueue.Enqueue(blah1);
            Console.WriteLine("Added Queue Item: blah 1");

            myQueue.Enqueue(new GeneralExampleClass() { MyPublicProperty = "blah 3" });
            Console.WriteLine("Added Queue Item: blah 3");

            myQueue.Enqueue(new GeneralExampleClass() { MyPublicProperty = "blah 5" });
            Console.WriteLine("Added Queue Item: blah 5");

            myQueue.Enqueue(new GeneralExampleClass() { MyPublicProperty = "blah 2" });
            Console.WriteLine("Added Queue Item: blah 2");


            // we can peak a queue item to look at the next item inside
            Console.WriteLine("Peak Queue Items:");
            Console.WriteLine(String.Format("Peak Item: {0}", myQueue.Peek().MyPublicProperty));
            Console.WriteLine("");

            // we can also do a contains on queues
            Console.WriteLine("Queue Contains:");
            Console.WriteLine(
                                String.Format("Does Queue Contain blah 1? {0}",
                                              myQueue.Contains(blah1) ? "True" : "False"
                              ));
            Console.WriteLine("");



            Console.WriteLine("Queue Items:");
            Console.WriteLine("-----------------");
            Console.WriteLine("");

            while (myQueue.Count > 0)
            {
                GeneralExampleClass generalExampleClass = myQueue.Dequeue();
                Console.WriteLine(String.Format("Dequeued Item: {0}", generalExampleClass.MyPublicProperty));
            }

            if (myQueue.Count == 0)
            {
                Console.WriteLine("Queue is empty!");
            }

            Console.WriteLine("");
            Console.WriteLine("");

        }

        private void RunGenericDotNetLists()
        {
            // A List is a .net generic collection type

            if (_listOfStrings == null)
            {
                _listOfStrings = new List<string>();
            }

            var stringList = _listOfStrings;

            for (int index = 0; index < 6; index++)
            {
                stringList.Add(String.Format("string {0}", index));
            }


            foreach (string listItem in stringList)
            {
                Console.WriteLine(String.Format("List Item: {0}", listItem));
            }

            // we could also add items to the list in the intialization of the list
            List<string> someList = new List<string>() { "blue", "green", "red", "yellow" };
        }

        private void printGenericsMenu()
        {
            Console.WriteLine("Generics:");
            Console.WriteLine("----------------------");
            Console.WriteLine("1) General .Net List");
            Console.WriteLine("2) Queue Generics");
            Console.WriteLine("3) Stack Generics");
            Console.WriteLine("4) Hashset Generics");
            Console.WriteLine("5) LinkedList Generics");
            Console.WriteLine("6) Dictionary Generics");
            Console.WriteLine("7) Generic Class");
            Console.WriteLine("8) Generic Class with constraints");
            Console.WriteLine("9) Generics and Interfaces examples");
            Console.WriteLine("0) Back Home");
        }


        #endregion private methods
    }
}
