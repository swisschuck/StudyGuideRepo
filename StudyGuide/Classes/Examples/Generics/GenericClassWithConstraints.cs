using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuide.Classes.Examples.Generics
{
    public class GenericClassWithConstraints<T> where T : struct
    {
        // we can have a generic class with constraints that will only allow certain types to be passed in or used with it.
        // examples:
        //------------------
        // where T : struct - use struct when the type argument must be a value type (int, char, byte, float, double, bool, etc)
        // where T : class - use the class keyword when the type argument must a reference type (class, interface, string, object)
        // where T : new() - use the new() keyword when the type must have a public parameterless constructor or default constructor
        // where T : CustomClassHere - when we use the class keyword the class passed in must be either the class named or derive from the class named,
        //                             the same holds true for interfaces.


        #region fields
        #endregion fields


        #region properties


        public int SomeNumber
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        #endregion properties


        #region constructors

        public GenericClassWithConstraints(T passedInInt)
        {
            //SomeNumber = (int)passedInInt;
        }


        #endregion constructors


        #region public methods

        public string RunSqlStatement<T, V>(string sqlQuery, V tableName)
        {
            string temp = String.Format("SELECT * FROM {0} WHERE blah != blah", tableName.ToString());

            if (typeof(V) == typeof(string))
            {
                Message = temp;
            }
            else
            {
                Message = "parameter pass in was not of type string";
            }

            return Message;
        }

        #endregion public methods


        #region private methods
        #endregion private methods
    }
}
