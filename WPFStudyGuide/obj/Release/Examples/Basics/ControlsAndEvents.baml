   M S B A M L   `   `   `  ����   WPFStudyGuide5    /WPFStudyGuide.Examples.Basics.ControlsAndEvents   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .���   � RowDefinitions  �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $��* ��� $��2* �.+��� $��	Full Name��$��Right=�$��Bottom=�$��5q��� -   $��FullNameTxtBox��$��1��$	��250��$��20��$
��Left=�$��Bottom=�$��5q��� $	��Sex��$��Right=�$��5q�$��1����  �� Orientation$ 
Horizontal=�$��1��$��1��$��Stretch=�$��Stretch=�.+�	� -   $��	MaleRadio�� 	� 	GroupName$ SexRadioGroup��$
��Male�� d� 	IsChecked$
 TrueY�$��5q�	� -   $��FemaleRadio��$ SexRadioGroup��$��Female��$ FalseY�$��5q��� $��
Do you own��$��Right=�$��Bottom=�$��5q�$��2���� $ 
Horizontal=�$��2��$��1��$��Bottom=�$
��Left=�.+��� -   $��DesktopChkbox��$��Desktop��$��5q��� -   $��LaptopChkbox��$��Laptop��$��5q��� -   $��TabletChkbox��$��Tablet��$��5q��� $��	Job Title��$��Right=�$��Bottom=�$��5q�$��3���� -   $��JobComboBox��$��3��$��1��$
��Left=�$��Bottom=�$��5q� �� SelectedIndex$ 0��.@��� $��
Programmer���� $��QA���� $��PO���� $��Scrum Master���� $��	Architect���� $,��&That douche nobody likes in the office���� $��Promised Delivery Date��$��Right=�$��Center=�$��5q�$��4��&   System.Windows.Controls.Calendar  -   $��DeliveryDateCal��$��4��$��1��$��5q�$
��Left=��� -	   $��
SaveButton��$
��Save��$��5��$��5q�$��Right=�