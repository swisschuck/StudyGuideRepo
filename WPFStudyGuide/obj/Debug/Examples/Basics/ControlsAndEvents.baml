   M S B A M L   `   `   `  ����  WPFStudyGuide5    /WPFStudyGuide.Examples.Basics.ControlsAndEvents   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      �   � RowDefinitions  5	   
   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6   .+�5   
   �� $��	Full Name��6   $��Right=�6%   $��Bottom=�6A   $��5q�6\   �� 5   
   -   5        $��FullNameTxtBox��5      $��1��6(   $	��250��68   $��20��6D   $
��Left=�6P   $��Bottom=�6k   $��5q�6�   �� 5   
   $	��Sex��6   $��Right=�6   $��5q�6;   $��1��6F   �� 5   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��1��6;   $��Stretch=�6K   $��Stretch=�6g   .+�5      	� -   5        $��	MaleRadio��5       	� 	GroupName$ SexRadioGroup��6+   $
��Male��6E    d� 	IsChecked$
 TrueY�6T   $��5q�6e   	� 5       -   5        $��FemaleRadio��5       $ SexRadioGroup��6-   $��Female��6G   $ FalseY�6X   $��5q�6j   5!      �� 5$   
   $��
Do you own��6   $��Right=�6&   $��Bottom=�6B   $��5q�6]   $��2��6h   �� 5%   
   $ 
Horizontal=�6   $��2��6.   $��1��6;   $��Bottom=�6K   $
��Left=�6f   .+�5&      �� -   5        $��DesktopChkbox��5&      $��Desktop��6,   $��5q�6>   �� 5'      -   5        $��LaptopChkbox��5'      $��Laptop��6+   $��5q�6<   �� 5(      -   5        $��TabletChkbox��5(      $��Tablet��6+   $��5q�6<   5)      �� 5,   
   $��	Job Title��6   $��Right=�6%   $��Bottom=�6A   $��5q�6\   $��3��6g   �� 5-   
   -   5        $��JobComboBox��5-      $��3��6&   $��1��63   $
��Left=�6C   $��Bottom=�6^   $��5q�6y    �� SelectedIndex$ 0��6�   .@�5/      �� $��
Programmer��6   �� 50      $��QA��6   �� 51      $��PO��6   �� 52      $��Scrum Master��6   �� 53      $��	Architect��6   �� 54      $,��&That douche nobody likes in the office��6   55      �� 58   
   $��Promised Delivery Date��6   $��Right=�62   $��Center=�6N   $��5q�6i   $��4��6t   &   System.Windows.Controls.Calendar  59   
   -   5        $��DeliveryDateCal��59      $��4��6*   $��1��67   $��5q�6G   $
��Left=�6R   �� 5<   
   -	   5        $��
SaveButton��5<      $
��Save��6#   $��5��62   $��5q�6?   $��Right=�6J   6f   5=      5>      