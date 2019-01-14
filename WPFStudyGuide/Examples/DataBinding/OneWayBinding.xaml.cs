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
using WPFStudyGuide.Classes.Other;

namespace WPFStudyGuide.Examples.DataBinding
{
    /// <summary>
    /// Interaction logic for OneWayBinding.xaml
    /// </summary>
    public partial class OneWayBinding : UserControl
    {
        public OneWayBinding()
        {
            InitializeComponent();
            // this is just one of many ways to bind data to the view (one way binding)
            DataContext = Employee.GetEmployee();
        }
    }
}
