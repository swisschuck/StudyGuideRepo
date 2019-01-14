﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFStudyGuide.Classes.Other
{
    public static class ViewModelLocator
    {
        public static bool GetAutoWireViewModel(DependencyObject obj)
        {
            return (bool)obj.GetValue(AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoWireViewModelProperty, value);
        }

        public static readonly DependencyProperty AutoWireViewModelProperty =
            DependencyProperty.RegisterAttached("AutoWireViewModel",
            typeof(bool), typeof(ViewModelLocator),
            new PropertyMetadata(false, AutoWireViewModelChanged));

        private static void AutoWireViewModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // if we are running in the designer, do nothing.
            if (DesignerProperties.GetIsInDesignMode(d))
            {
                return;
            }
            try
            {
                // in order for this to work as its coded here, the view and view model need to be in the same namespace/folder
                var viewType = d.GetType();
                var viewTypeName = viewType.FullName;
                var viewModelTypeName = viewType + "Model";
                var viewModelType = Type.GetType(viewModelTypeName);
                var viewModel = Activator.CreateInstance(viewModelType);
                ((FrameworkElement)d).DataContext = viewModel;
            }
            catch(Exception ex)
            {
                string message = String.Format("Oops: {0}", ex.Message);
            }

        }
    }
}
