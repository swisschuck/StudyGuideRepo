using Newtonsoft.Json.Linq;
using StudyGuide.Classes.Examples.Cryptography;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuide.Database.JSON
{
    class JSONDataBase
    {
        #region fields

        private string _userJsonFilePath = @"C:\Repos\StudyGuideRepo\StudyGuide\Database\JSON\Users.json";

        #endregion fields


        #region properties
        #endregion properties


        #region constructors

        public JSONDataBase()
        {

        }

        #endregion constructors


        #region public methods

        public List<User> GetAllUsers()
        {
            List<User> listOfUsersToReturn = new List<User>();

            try
            {
                if (!File.Exists(_userJsonFilePath))
                {
                    return listOfUsersToReturn;
                }

                string jsonstring = File.ReadAllText(_userJsonFilePath);

                if (String.IsNullOrEmpty(jsonstring))
                {
                    return listOfUsersToReturn;
                }

                //JArray jsonArray = 
                // https://www.c-sharpcorner.com/article/crud-operation-with-json-file-data-in-c-sharp/

            }
            catch (Exception exception)
            {

            }

            return listOfUsersToReturn;
        }

        public User GetUser(string userName)
        {
            User userToReturn = new User();


            return userToReturn;
        }

        #endregion public methods


        #region private methods
        #endregion private methods
    }
}
