using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuide.Classes.Examples.Async
{
    public class CustomException : Exception
    {
        public CustomException(String message)
            : base(message)
        {

        }
    }
}
