   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      H DWPFStudyGuide, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:WPFStudyGuide.Enums.OtherWPFStudyGuide.Enums.Other 5      6   0WPFStudyGuide.Examples.AdvancedControls.DataGrid   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7core&clr-namespace:System;assembly=mscorlib     5      9local'clr-namespace:WPFStudyGuide.Enums.Other     5        � 	Resources  5
       
  myEnum S� 
MethodName S� 
ObjectType   System.Enum S� MethodParameters M� Type0  *WPFStudyGuide.Enums.Other.PartyAffiliation��%e   &	        S� 5   
   $ 	GetValues��6,   "  6C    5      M� 5      "  6   5      5      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��
myDataGrid��5         AlternatingRowBackground
 ��ح� �� AlternationCount$ 2��6J      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$
	 Name��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 63   �� *Name+  5      $	 Title��6%   
 64   �� *Title+4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $	 Was Relected��6)   
 6?   �� *WasRelected+4  .System.Windows.Controls.DataGridComboBoxColumn  5      $	 Party��6)      SelectedItemBinding 68   �� *Party+   ItemsSource 6^   ��  �� Source# [  5      5      5      