using System;
using WPFStudyGuide.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace WPFStudyGuide.Classes.Other
{
    public class SimpleEditableCustomer : ValidationBase
    {
        #region fields

        private Guid _id;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phone;

        #endregion fields


        #region properties

        public Guid Id
        {
            get
            {
                return _id;
            }

            set
            {
                SetProperty(ref _id, value);
            }
        }

        // the [Required] attribute of this class is directly tied to the System.ComponentModel.DataAnnotations library, which works in turn with
        // our custom ValidationBase class
        [Required]
        public string FirstName
        {
            get
            {
                return _firstName;
            }

            set
            {
                SetProperty(ref _firstName, value);
            }
        }

        [Required]
        public string LastName
        {
            get
            {
                return _lastName;
            }

            set
            {
                SetProperty(ref _lastName, value);
            }
        }

        [EmailAddress]
        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                SetProperty(ref _email, value);
            }
        }

        [Phone]
        public string Phone
        {
            get
            {
                return _phone;
            }

            set
            {
                SetProperty(ref _phone, value);
            }
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
