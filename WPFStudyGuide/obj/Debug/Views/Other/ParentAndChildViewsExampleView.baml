   M S B A M L   `   `   `  ����H  DWPFStudyGuide, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:WPFStudyGuide.Views.OtherWPFStudyGuide.Views.Other  5      O,clr-namespace:WPFStudyGuide.ViewModels.OtherWPFStudyGuide.ViewModels.Other  5	      >    8WPFStudyGuide.Views.Other.ParentAndChildViewsExampleView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:WPFStudyGuide.Views.Other     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Ninteractivity:http://schemas.microsoft.com/expression/2010/interactivity  5      h dMicrosoft.Expression.Interactions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Linteractions9http://schemas.microsoft.com/expression/2010/interactions  5      =
viewModels,clr-namespace:WPFStudyGuide.ViewModels.Other  5	      .  (System.Windows.Interactivity.Interaction    Triggers  5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6%   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      >  8Microsoft.Expression.Interactivity.Core.CallMethodAction     
MethodName$ LoadCustomers��6E      TargetObject 6,   �� 6E   5      .��5      �  � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��    BaseHeaderTitle#��[  65   $��0��6^   ��6   �� *ViewHeaderTitle+6^   � 5   
   .+�5      �� $��Add Customer��6   $
��Left=�6S   ��6,   �� *AddCustomerCommand+6S   5      &   System.Windows.Controls.DataGrid  5   
      AutoGenerateColumns .     CanUserAddRows .  $��1��6h   ��6   �� *	Customers+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       -   5        firstNameColumn��,  &System.Windows.Controls.DataGridColumn	   Header$	 
First Name��5    \   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6p   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6>   �� *	FirstName+6p   4
  .System.Windows.Controls.DataGridTemplateColumn
  5!      $

 Auto 6)    
  CellTemplate 5"      �� 5#      .R�5$      �� $��Place Order��6%   $��5q�5'   %   ��5%   %   �� *DataContext.PlaceOrderCommand+ �� RelativeSource ��  �� AncestorType"  ��5&   %   �� 5'   %   5(      5*      
  5+      $

 Auto 6)    5,      �� 5-      .R�5.      �� $��Edit Customer��6%   $��5q�51   %   ��5/   %   �� *!DataContext.EditCustomerCommand+ �� "  ��50   %   �� 51   %   52      54      
  55      $

 Auto 6)    56      �� 57      .R�58      �� $��Delete Customer��6%   $��5q�5;   %   ��59   %   �� *#!DataContext.DeleteCustomerCommand+ �� "  ��5:   %   �� 5;   %   5<      5>      5@      5A      5B      