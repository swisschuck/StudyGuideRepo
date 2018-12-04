
using StudyGuide.Classes.Delegates;
using StudyGuide.Classes.Events;
using System;
namespace StudyGuide.Classes.Examples
{
    // Events
    //---------------------------------------------
    // - Allows a class to send notifications to other classes or objects.
    // - A publisher raises the event.
    // - One or more subscribers process the event.


    // Delegates
    //---------------------------------------------
    // - A delegate is a type just like int, string, decimal, etc that references methods


    public class EventsAndDelegates
    {

        #region fields
        #endregion fields


        #region properties
        #endregion properties


        #region constructors
        #endregion constructors


        #region public methods

        public static void InvokeDelegate()
        {
            PrintMessageDelegate printMessageDelegate = new PrintMessageDelegate(PrintMessageMethodInEventsAndDelegatesClass);
            printMessageDelegate("IT WORKED!");
        }

        public static void InvokeDelegate2()
        {
            GeneralExampleClass generalExampleClass = new GeneralExampleClass();

            // by using the += we can concatinate event delegates to the NameChanged Property over and over so that each method tied to the 
            // delegate added is fired when the MyName Property changes. Its a way to add many methods to one property being used by a delegate.
            // each one of these are considered to be subscriptions to the event that is actually a delegate.
            generalExampleClass.NameChanged += new NameChangeDelegate(DoSomthingWhenNamedChanged);
            generalExampleClass.MyName = "some name";

            generalExampleClass.NameChanged += new NameChangeDelegate(DoSomthingWhenNamedChanged2);
            generalExampleClass.MyName = "some name2";

            // the C# compilier is smart enough to find the correct method without invoking a new NameChangedDelegate object
            generalExampleClass.NameChanged += DoSomthingWhenNamedChanged3;
            generalExampleClass.MyName = "some name3";
        }

        public static void InvokeDelegate3()
        {
            GeneralExampleClass generalExampleClass = new GeneralExampleClass("starting Name");
            generalExampleClass.NameChangedArgs += new NameChangeDelegateArgs(DoSomthingWhenEventFires);
            generalExampleClass.MyOtherName = "charlie";
            generalExampleClass.MyOtherName = "chuckles";
        }

        #endregion public methods


        #region private methods

        private static void PrintMessageMethodInEventsAndDelegatesClass(string message)
        {
            Console.WriteLine(String.Format("Message to print from the delegated method: {0}", message));
        }

        private static void DoSomthingWhenNamedChanged(string name)
        {
            Console.WriteLine(String.Format("The MyName Property was set to '{0}' in a method", name));
        }

        private static void DoSomthingWhenNamedChanged2(string name)
        {
            Console.WriteLine(String.Format("The MyName Property was set to '{0}' in some other method", name));
        }

        private static void DoSomthingWhenNamedChanged3(string name)
        {
            Console.WriteLine(String.Format("The MyName Property was set to '{0}' in yet another method", name));
        }

        private static void DoSomthingWhenEventFires(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine(String.Format("The MyOtherName Property was changed from '{0}' to '{1}'", args.ExistingName, args.NewName));
        }

        #endregion private methods
    }
}
