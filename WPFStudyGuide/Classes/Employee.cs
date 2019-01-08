using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFStudyGuide.Classes
{
    public class Employee : INotifyPropertyChanged
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

        public Employee()
        {

        }

        #endregion constructors


        #region public methods

        public static Employee GetEmployee()
        {
            Employee employee = new Employee()
            {
                Name = "Bob",
                Title = "Developer"
            };

            return employee;
        }


        public static ObservableCollection<Employee> GetEmployees()
        {
            ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

            employees.Add(new Employee() { Name = "Sue", Title = "CEO", YearsOfService = "2 years", Address = "123 fake street" });
            employees.Add(new Employee() { Name = "Cole", Title = "QA", YearsOfService = "1 years", Address = "500 fake street" });
            employees.Add(new Employee() { Name = "Frank", Title = "PO", YearsOfService = "5 years", Address = "420 fake dr" });
            employees.Add(new Employee() { Name = "Harry", Title = "Janitor", YearsOfService = "3 years", Address = "600 not real drive" });
            employees.Add(new Employee() { Name = "Kristin", Title = "SM", YearsOfService = "4 years", Address = "800 fake street" });

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
