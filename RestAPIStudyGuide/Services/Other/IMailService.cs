using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIStudyGuide.Services.Other
{
    public interface IMailService
    {
        void Send(string subject, string message);
    }
}
