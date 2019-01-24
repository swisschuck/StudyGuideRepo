using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFStudyGuide.Classes
{
    public class SimpleCustomer : INotifyPropertyChanged
    {
        #region fields

        private string _firstName;

        #endregion fields


        #region properties

        public event PropertyChangedEventHandler PropertyChanged = delegate { };


        public Guid Id { get; set; }
        public Guid? StoreId { get; set; }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    //PropertyChanged(this, new PropertyChangedEventArgs("FirstName"));
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(FirstName)));
                }
            }

        }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }


        public string FullAddress
        {
            get
            {
                return $"{Street}, {City}, {State}, {Zip}";
            }
        }

        #endregion properties


        #region constructors

        public SimpleCustomer()
        {
        }
        #endregion constructors


        #region public methods
        #endregion public methods


        #region private methods
        #endregion private methods
    }
}
