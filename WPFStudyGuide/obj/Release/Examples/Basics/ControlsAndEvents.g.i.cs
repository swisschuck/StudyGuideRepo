﻿#pragma checksum "..\..\..\..\Examples\Basics\ControlsAndEvents.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E3DC3E6C0B0BAFB735A7274D35FB1B404D2A8667"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace WPFStudyGuide.Examples.Basics {
    
    
    /// <summary>
    /// ControlsAndEvents
    /// </summary>
    public partial class ControlsAndEvents : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\..\Examples\Basics\ControlsAndEvents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FullNameTxtBox;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\Examples\Basics\ControlsAndEvents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton MaleRadio;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Examples\Basics\ControlsAndEvents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton FemaleRadio;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\Examples\Basics\ControlsAndEvents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox DesktopChkbox;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Examples\Basics\ControlsAndEvents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox LaptopChkbox;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\Examples\Basics\ControlsAndEvents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox TabletChkbox;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Examples\Basics\ControlsAndEvents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox JobComboBox;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\Examples\Basics\ControlsAndEvents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Calendar DeliveryDateCal;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\Examples\Basics\ControlsAndEvents.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WPFStudyGuide;component/examples/basics/controlsandevents.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Examples\Basics\ControlsAndEvents.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.FullNameTxtBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.MaleRadio = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 3:
            this.FemaleRadio = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 4:
            this.DesktopChkbox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 5:
            this.LaptopChkbox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            this.TabletChkbox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 7:
            this.JobComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 46 "..\..\..\..\Examples\Basics\ControlsAndEvents.xaml"
            this.JobComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.JobComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.DeliveryDateCal = ((System.Windows.Controls.Calendar)(target));
            return;
            case 9:
            this.SaveButton = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\..\Examples\Basics\ControlsAndEvents.xaml"
            this.SaveButton.Click += new System.Windows.RoutedEventHandler(this.SaveButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

