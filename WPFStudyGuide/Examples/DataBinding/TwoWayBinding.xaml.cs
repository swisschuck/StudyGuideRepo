﻿using System;
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
    /// Interaction logic for TwoWayBinding.xaml
    /// </summary>
    public partial class TwoWayBinding : UserControl
    {
        #region fields

        private EmployeeExample employee;
        #endregion fields


        #region properties
        #endregion properties


        #region constructors
        public TwoWayBinding()
        {
            InitializeComponent();

            employee = new EmployeeExample()
            {
                Name = "Bobbie",
                Title = "QA",
                Address = "123 fake street",
                YearsOfService = "5 years"
            };

            DataContext = employee;
        }

        #endregion constructors


        #region public methods
        #endregion public methods


        #region private methods
        #endregion private methods


        #region events
        #endregion events
    }
}
