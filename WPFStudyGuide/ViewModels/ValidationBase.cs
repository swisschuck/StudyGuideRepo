using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace WPFStudyGuide.ViewModels
{
    public class ValidationBase : BaseViewModel, INotifyDataErrorInfo
    {
        #region fields

        private Dictionary<string, List<string>> _errorsDictionary = new Dictionary<string, List<string>>();

        #endregion fields


        #region properties

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged = delegate { };

        public bool HasErrors
        {
            get
            {
                return _errorsDictionary.Count > 0;
            }
        }

        #endregion properties


        #region constructors

        public ValidationBase()
        {

        }

        #endregion constructors


        #region public methods

        public System.Collections.IEnumerable GetErrors(string propertyName)
        {
            if (_errorsDictionary.ContainsKey(propertyName))
            {
                return _errorsDictionary[propertyName];
            }
            else
            {
                return null;
            }
        }

        protected override void SetProperty<T>(ref T member, T val, [CallerMemberName] string propertyName = null)
        {
            base.SetProperty<T>(ref member, val, propertyName);
            ValidateProperty(propertyName, val);
        }

        #endregion public methods


        #region private methods

        private void ValidateProperty<T>(string propertyName, T value)
        {
            // ValidationContext
            //  - Is a member of the DataAnnotations library
            //  - can be pointed to a given object, say what member or property is to be validated then call a method to validate that object

            var results = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(this);
            context.MemberName = propertyName;
            Validator.TryValidateProperty(value, context, results);

            if (results.Any())
            {
                _errorsDictionary[propertyName] = results.Select(c => c.ErrorMessage).ToList();
            }
            else
            {
                _errorsDictionary.Remove(propertyName);
            }

            ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }

        #endregion private methods
    }
}
