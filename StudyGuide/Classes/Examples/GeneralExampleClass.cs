
using StudyGuide.Classes.Delegates;
using StudyGuide.Classes.Events;
using System;
namespace StudyGuide.Classes.Examples
{
    public class GeneralExampleClass
    {
        #region general notes

        // General Notes
        // ================================================================
        // - everything defined inside a class is a "member" of that class.
        // - class members define State and Behavior.
        // - a class is a blueprint for creating objects.
        // - a class can also be used to type a variable.

        // Fields - Fields should (almost always) be kept private to a class and accessed via get and set properties.
        //        - Typical convention is to use an underscore before the name, starting with lowercase.

        // Properties - exposed fields, Properties provide a level of abstraction allowing you to change the fields while not affecting the 
        //              external way they are accessed by the things that use your class.
        //            - Typical convention is to start the property name with an uppercase.

        // Constructors - used to construct a new instance of a class.
        //              - are always named with the same name as the class.
        //              - intializes the class.
        //              - default constructor does not take any parameters.


        // Access Modifiers - provide a level of encapsulation to our classes/program
        // ===========================================================================
        // public - makes a class or member publicly available to any code outside of the class.
        // private - only useable from code inside the same class.
        // static - be accessed without creating an instance of the class containing it.
        // internal - can only be used code that is inside the same project or assembly, is used as the default if no access modifier is used.
        // protected - can only be accessed from the class itself or from a derived/inherited class.
        // virtual - is used to modify a method, property, indexer, or event declaration and allow for it to be overridden in a derived class. 


        // Types
        // ===========================================================================
        // Reference Type - are used by a reference which holds a reference (address) to the object but not the object itself. 
        //                  Because reference types represent the address of the variable rather than the data itself, assigning 
        //                  a reference variable to another doesn't copy the data. Instead it creates a second copy of the reference, 
        //                  which refers to the same location of the heap as the original value. 

        // Value Type - does not hold a memory address or pointer, are much less expensive that reference types.
        //            - many of the built-in primitives are value types (int, double, float).
        //            - are immutable or their values cannot be changed.


        // Struct Type - Struct defintions create new custom value types

        // Enum Type - short for enumeration, is a good way to create named constants.


        // Parameters
        // ===========================================================================
        // - Reference types pass a copy of the reference
        // - Value types pass a copy of the value
        // this can be changed via the ref and out keywords


        #endregion general notes


        #region fields

        private string _myPrivateField;
        private readonly string _myPrivateReadOnlyField;
        private string _name;
        private string _someOtherName;

        #endregion fields


        #region properties

        public string MyPublicProperty
        {
            // the get and set keywords are used in a Public property to control the state of a private field and
            // the access outside code has to the field
            get
            {
                return _myPrivateField;
            }
            set
            {
                _myPrivateField = value;
            }
        }


        public string MyPublicAutoImplementedProperty
        {
            // a Auto-Implemented property simply uses the get and set keywords are all thats used. 
            // The complier will create a field behind the scenes and will read and write to this field automatically
            get;
            set;
        }

        // here we are making use of the delegate type we created in Delegates.cs and are using it as a property in this class
        // so anytime we invoke this property it will execute a method that is assigned to the delegate
        public PrintMessageDelegate PrintMessageDelegate;


        public string MyName
        {
            // here we use a delegate to handle what block of code gets executed when the MyName Propety gets set
            get
            {
                return _name;
            }
            set
            {
                if (value != null)
                {
                    NameChanged(value);
                }
            }
        }

        public NameChangeDelegate NameChanged;


        public string MyOtherName
        {
            // here we use a delegate to handle what block of code gets executed when the MyName Propety gets set
            get
            {
                return _name;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.ExistingName = _someOtherName;
                    args.NewName = value;
                    NameChangedArgs(this, args);
                }
            }
        }

        public NameChangeDelegateArgs NameChangedArgs;

        #endregion properties


        #region constructors

        public GeneralExampleClass()
        {

        }

        public GeneralExampleClass(string someStringPassedIn)
        {
            // readonly fields can only be assigned a value during declaration or in the classes constructor
            _myPrivateReadOnlyField = someStringPassedIn;

            _someOtherName = someStringPassedIn;
        }

        #endregion constructors


        #region public methods
        #endregion public methods


        #region private methods
        #endregion private methods
    }
}


//#region fields
//#endregion fields


//#region properties
//#endregion properties


//#region constructors
//#endregion constructors


//#region public methods
//#endregion public methods


//#region private methods
//#endregion private methods