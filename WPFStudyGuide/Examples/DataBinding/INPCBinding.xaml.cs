using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFStudyGuide.Classes;

namespace WPFStudyGuide.Examples.DataBinding
{
    /// <summary>
    /// Interaction logic for INPCBinding.xaml
    /// </summary>
    public partial class INPCBinding : UserControl
    {
        #region fields

        private Employee employee;
        #endregion fields


        #region properties
        #endregion properties


        #region constructors
        public INPCBinding()
        {
            InitializeComponent();

            employee = new Employee()
            {
                Name = "Bobbie",
                Title = "QA"
            };

            DataContext = employee;
        }

        #endregion constructors


        #region public methods
        #endregion public methods


        #region private methods
        #endregion private methods


        #region events
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            // INPC binding
            employee.Address = "123 fake street";
            employee.YearsOfService = "5 years";
        }

        #endregion events
    }
}
