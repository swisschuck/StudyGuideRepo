using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFStudyGuide.Classes.Other
{
    public class EmployeeExample
    {
        #region fields

        private string _yearsOfService;
        private string _address;
        private DateTime _startDate;

        #endregion fields


        #region properties

        public string Name { get; set; }
        public string Title { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public string YearsOfService
        {
            get { return _yearsOfService; }
            set
            {
                _yearsOfService = value;
                OnPropertyChanged();
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged();
            }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                OnPropertyChanged();
            }
        }

        #endregion properties


        #region constructors

        public EmployeeExample()
        {

        }

        #endregion constructors


        #region public methods

        public static EmployeeExample GetEmployee()
        {
            EmployeeExample employee = new EmployeeExample()
            {
                Name = "Bob",
                Title = "Developer"
            };

            return employee;
        }


        public static ObservableCollection<EmployeeExample> GetEmployees()
        {
            ObservableCollection<EmployeeExample> employees = new ObservableCollection<EmployeeExample>();

            employees.Add(new EmployeeExample() { Name = "Sue", Title = "CEO", YearsOfService = "2 years", Address = "123 fake street" });
            employees.Add(new EmployeeExample() { Name = "Cole", Title = "QA", YearsOfService = "1 years", Address = "500 fake street" });
            employees.Add(new EmployeeExample() { Name = "Frank", Title = "PO", YearsOfService = "5 years", Address = "420 fake dr" });
            employees.Add(new EmployeeExample() { Name = "Harry", Title = "Janitor", YearsOfService = "3 years", Address = "600 not real drive" });
            employees.Add(new EmployeeExample() { Name = "Kristin", Title = "SM", YearsOfService = "4 years", Address = "800 fake street" });

            return employees;
        }

        #endregion public methods


        #region private methods

        private void OnPropertyChanged([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }

        #endregion private methods
    }
}
