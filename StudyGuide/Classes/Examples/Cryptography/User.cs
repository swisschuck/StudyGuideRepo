using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuide.Classes.Examples.Cryptography
{
    public class User
    {
        #region fields

        private string _userName;
        private string _password;
        private bool _crudFailed;

        #endregion fields


        #region properties

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        [JsonIgnore]
        public bool CrudFailed
        {
            get { return _crudFailed; }
            set { _crudFailed = value; }
        }

        #endregion properties


        #region constructors

        public User()
        {

        }

        public User(string userName, string password)
        {
            _userName = userName;
            _password = password;
        }

        #endregion constructors


        #region public methods

        public string ConvertThisToJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }
        #endregion public methods


        #region private methods
        #endregion private methods
    }
}
