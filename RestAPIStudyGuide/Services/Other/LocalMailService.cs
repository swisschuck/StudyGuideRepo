using System.Diagnostics;

namespace RestAPIStudyGuide.Services.Other
{
    public class LocalMailService : IMailService
    {
        #region fields

        //private string _mailTo = "testingLocalMailService1@gmail.com";
        //private string _mailFrom = "testingLocalMailService2@gmail.com";
        private string _mailTo = Startup.Configuration["mailSettings.mailToAddress"];
        private string _mailFrom = Startup.Configuration["mailSettings.mailFromAddress"];

        #endregion fields


        #region properties

        public void Send(string subject, string message)
        {
            // send mail output to debug window
            Debug.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with LocalMailService.");
            Debug.WriteLine($"Subject: {subject}");
            Debug.WriteLine($"Message: {message}");
        }

        #endregion properties


        #region constructors
        #endregion constructors


        #region public methods
        #endregion public methods


        #region private methods
        #endregion private methods
    }
}
