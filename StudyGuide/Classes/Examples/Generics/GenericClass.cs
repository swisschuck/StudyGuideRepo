using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuide.Classes.Examples.Generics
{
    public class GenericClass<T>
    {
        #region fields
        #endregion fields


        #region properties

        public T GenericResult
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

        public GenericClass()
        {

        }

        public GenericClass(T result, string message)
        {
            this.GenericResult = result;
            this.Message = message;
        }

        #endregion constructors


        #region public methods

        public T GetResult<T>()
        {

            if (typeof(T) == GenericResult.GetType())
            {
                return (T)(object)GenericResult;
            }


            return default(T);
        }


        #endregion public methods


        #region private methods
        #endregion private methods
    }
}
