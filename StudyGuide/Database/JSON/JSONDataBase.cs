using Newtonsoft.Json;
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
        // https://www.c-sharpcorner.com/article/crud-operation-with-json-file-data-in-c-sharp/
        #region fields

        private string _userJsonFilePath = @"C:\Repos\StudyGuideRepo\StudyGuide\Database\JSON\Users.json";
        private string _rsaKeysJsonFilePath = @"C:\Repos\StudyGuideRepo\StudyGuide\Database\JSON\RSAKeys.json";
        private string _rsaPrivateKeyXMLPath = @"C:\Repos\StudyGuideRepo\StudyGuide\Database\JSON\RSA_PrivateKey.xml";
        private string _rsaPublicKeyXMLPath = @"C:\Repos\StudyGuideRepo\StudyGuide\Database\JSON\RSA_PublicKey.xml";

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
                string jsonstring = CheckForFile(_userJsonFilePath);

                if (String.IsNullOrEmpty(jsonstring))
                {
                    return listOfUsersToReturn;
                }

                listOfUsersToReturn = JsonConvert.DeserializeObject<List<User>>(jsonstring);


                return listOfUsersToReturn;

            }
            catch (Exception exception)
            {

            }

            return listOfUsersToReturn;
        }

        public User GetUser(string userName)
        {
            User userToReturn = new User();

            try
            {
                string jsonstring = CheckForFile(_userJsonFilePath);

                if (String.IsNullOrEmpty(jsonstring))
                {
                    return null;
                }

                List<User> listOfCurrentUsers = JsonConvert.DeserializeObject<List<User>>(jsonstring);

                bool userAlreadyExists = listOfCurrentUsers.Any(user => user.UserName == userName);

                if (!userAlreadyExists)
                {
                    return null;
                }

                userToReturn = listOfCurrentUsers.Where(user => user.UserName == userName).FirstOrDefault();

            }
            catch (Exception ex)
            {
                return null;
            }

            return userToReturn;
        }


        public bool AddUser(User userToAdd)
        {
            bool statusToReturn = false;

            try
            {
                string jsonstring = CheckForFile(_userJsonFilePath);

                if (String.IsNullOrEmpty(jsonstring))
                {
                    return statusToReturn;
                }

                List<User> listOfCurrentUsers = JsonConvert.DeserializeObject<List<User>>(jsonstring);

                bool userAlreadyExists = listOfCurrentUsers.Any(user => user.UserName == userToAdd.UserName);

                if (userAlreadyExists)
                {
                    return true;
                }

                listOfCurrentUsers.Add(userToAdd);

                File.WriteAllText(_userJsonFilePath, JsonConvert.SerializeObject(listOfCurrentUsers));

                statusToReturn = true;
            }
            catch (Exception ex)
            {
                return statusToReturn;
            }

            return statusToReturn;
        }

        public bool UpdateUser(User userToUpdate)
        {
            bool statusToReturn = false;

            try
            {
                string jsonstring = CheckForFile(_userJsonFilePath);

                if (String.IsNullOrEmpty(jsonstring))
                {
                    return statusToReturn;
                }

                List<User> listOfCurrentUsers = JsonConvert.DeserializeObject<List<User>>(jsonstring);

                bool userAlreadyExists = listOfCurrentUsers.Any(user => user.UserName == userToUpdate.UserName);

                if (!userAlreadyExists)
                {
                    return false;
                }

                for (int currentUserIndex = 0; currentUserIndex < listOfCurrentUsers.Count; currentUserIndex++)
                {
                    if (listOfCurrentUsers[currentUserIndex].UserName == userToUpdate.UserName)
                    {
                        listOfCurrentUsers[currentUserIndex].Password = userToUpdate.Password.Trim();
                        break;
                    }
                }

                File.WriteAllText(_userJsonFilePath, JsonConvert.SerializeObject(listOfCurrentUsers));

                statusToReturn = true;
            }
            catch (Exception ex)
            {
                return statusToReturn;
            }

            return statusToReturn;
        }


        public bool DeleteUser(User userToDelete)
        {
            bool statusToReturn = false;

            try
            {
                string jsonstring = CheckForFile(_userJsonFilePath);

                if (String.IsNullOrEmpty(jsonstring))
                {
                    return statusToReturn;
                }

                List<User> listOfCurrentUsers = JsonConvert.DeserializeObject<List<User>>(jsonstring);

                bool userAlreadyExists = listOfCurrentUsers.Any(user => user.UserName == userToDelete.UserName);

                if (!userAlreadyExists)
                {
                    return false;
                }

                for (int currentUserIndex = 0; currentUserIndex < listOfCurrentUsers.Count; currentUserIndex++)
                {
                    if (listOfCurrentUsers[currentUserIndex].UserName == userToDelete.UserName)
                    {
                        listOfCurrentUsers.RemoveAt(currentUserIndex);
                        break;
                    }
                }

                File.WriteAllText(_userJsonFilePath, JsonConvert.SerializeObject(listOfCurrentUsers));

                statusToReturn = true;
            }
            catch (Exception ex)
            {
                return statusToReturn;
            }

            return statusToReturn;
        }


        public RSAKeys GetRSAKeys()
        {
            RSAKeys rsaKeysToReturn = new RSAKeys();

            try
            {
                string privateKeyString = CheckForFile(_rsaPrivateKeyXMLPath);
                string publicKeyString = CheckForFile(_rsaPublicKeyXMLPath);

                if (String.IsNullOrEmpty(privateKeyString) || String.IsNullOrEmpty(publicKeyString))
                {
                    return null;
                }

                rsaKeysToReturn.RsaPrivateKey = privateKeyString;
                rsaKeysToReturn.RsaPublicKey = publicKeyString;

            }
            catch (Exception ex)
            {
                return null;
            }

            return rsaKeysToReturn;
        }

        public bool AddRSAKey(RSAKeys keysToAdd)
        {
            bool statusToReturn = false;

            try
            {
                string privateKeyString = CheckForFile(_rsaPrivateKeyXMLPath);
                string publicKeyString = CheckForFile(_rsaPublicKeyXMLPath);

                if (String.IsNullOrEmpty(privateKeyString) || String.IsNullOrEmpty(publicKeyString))
                {
                    return statusToReturn;
                }

                File.WriteAllText(_rsaPrivateKeyXMLPath, keysToAdd.RsaPrivateKey);
                File.WriteAllText(_rsaPublicKeyXMLPath, keysToAdd.RsaPublicKey);

                statusToReturn = true;
            }
            catch (Exception ex)
            {
                return statusToReturn;
            }

            return statusToReturn;
        }

        public bool DeleteRSAKey(RSAKeys keysToDelete)
        {
            bool statusToReturn = false;
            const string defaultXMLValues = "<RSAKeyValue></RSAKeyValue>";

            try
            {
                string privateKeyString = CheckForFile(_rsaPrivateKeyXMLPath);
                string publicKeyString = CheckForFile(_rsaPublicKeyXMLPath);

                if (String.IsNullOrEmpty(privateKeyString) || String.IsNullOrEmpty(publicKeyString))
                {
                    return statusToReturn;
                }

                File.WriteAllText(_rsaPrivateKeyXMLPath, defaultXMLValues);
                File.WriteAllText(_rsaPublicKeyXMLPath, defaultXMLValues);

                statusToReturn = true;
            }
            catch (Exception ex)
            {
                return statusToReturn;
            }

            return statusToReturn;
        }

        #endregion public methods


        #region private methods

        private string CheckForFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return null;
            }

            string fileContents = File.ReadAllText(filePath);

            if (String.IsNullOrEmpty(fileContents))
            {
                return null;
            }

            return fileContents;
        }
        #endregion private methods
    }
}
