using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIStudyGuide.Services.Other
{
    public class CloudMailService : IMailService
    {
        #region fields

        //private string _mailTo = "testingCloudMailService1@gmail.com";
        //private string _mailFrom = "testingCloudMailService2@gmail.com";
        private string _mailTo = Startup.Configuration["mailSettings.mailToAddress"];
        private string _mailFrom = Startup.Configuration["mailSettings.mailFromAddress"];

        #endregion fields


        #region properties
        #endregion properties


        #region constructors
        #endregion constructors


        #region public methods

        public void Send(string subject, string message)
        {
            Debug.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with CloudMailService.");
            Debug.WriteLine($"Subject: {subject}");
            Debug.WriteLine($"Message: {message}");
        }

        #endregion public methods


        #region private methods
        #endregion private methods
    }
}
