   M S B A M L   `   `   `  ����H  DWPFStudyGuide, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:WPFStudyGuide.Views.OtherWPFStudyGuide.Views.Other  5      C&clr-namespace:WPFStudyGuide.ConvertersWPFStudyGuide.Converters  5      I)clr-namespace:WPFStudyGuide.Classes.OtherWPFStudyGuide.Classes.Other  5      3    -WPFStudyGuide.Views.Other.AddEditCustomerView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:WPFStudyGuide.Views.Other     5      =
converters&clr-namespace:WPFStudyGuide.Converters     5      ;Other)clr-namespace:WPFStudyGuide.Classes.Other     5        � 	Resources  5      D   >WPFStudyGuide.Converters.NegatableBooleanToVisibilityConverter   VisibilityConverter  NegateVisibilityConverter   Negate �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value �� Self	 �� RelativeSource
 �� Path��%  &	        &	      '�� -       5   
   6;     5   
    . 6]   �� 5   
   " ��6    5      P� 5       �@=�HasError . . �5      ��  �@�ToolTip 60   �� #	 Z $2
 ,(Validation.Errors).CurrentItem.ErrorContent�5      5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5!   
   ��   BaseHeaderTitle#��[ 65   $��0��6^   ��6   �� *ViewHeaderTitle+6^   � 5#   
   -   5         �Name$ grid1��5#      $
��Left=�5$      $��	10,10,0,0q�6*   $��1��6=   $	��Top=�6J    � DataContext 5#      �� *
Customer+ � ColumnDefinitions 5%      �� 5&      $
��Auto �6#   �� 5'      $
��Auto �6#    5)      �� 5*      $
��Auto �6    �� 5+      $
��Auto �6    �� 5,      $
��Auto �6    �� 5-      $
��Auto �6    .+�50      �� $��First Name:��6   $��0��6*   $
��Left=�6:   $��3q�6U   $��0��6`   $��Center=�6m   �� 51      -   5         ��Name$ firstNameTextBox��51      $��1��60   $
��Left=�6@   $��23��6[   $��3q�6g   $��0��6r   $��Center=�52   S   $	��120��6n   ��6   �� *	FirstName+" �� ValidatesOnNotifyDataErrors . 6n   �� 54      $��
Last Name:��6   $��0��6)   $
��Left=�69   $��3q�6T   $��1��6_   $��Center=�6l   �� 55      -   5        $ lastNameTextBox��55      $��1��6/   $
��Left=�6?   $��23��6Z   $��3q�6f   $��1��6q   $��Center=�56   R   $	��120��6m   ��6   �� *
LastName+ . 6m   �� 58      $��Email:��6   $��0��6%   $
��Left=�65   $��3q�6P   $��2��6[   $��Center=�6h   �� 59      -   5        $ emailTextBox��59      $��1��6,   $
��Left=�6<   $��23��6W   $��3q�6c   $��2��6n   $��Center=�5:   O   $	��120��6j   ��6   �� *Email+ . 6j   �� 5<      $��Phone:��6   $��0��6%   $
��Left=�65   $��3q�6P   $��3��6[   $��Center=�6h   �� 5=      -   5        $ phoneTextBox��5=      $��1��6,   $
��Left=�6<   $��23��6W   $��3q�6c   $��3��6n   $��Center=�5>   O   $	��120��6j    �� 	MaxLength$ 10��6v   ��6   �� *Phone+ . 6v   5?      � 5@   
   $��2��6   .+�5A      �� $
��Save��6   $
��Left=�5B      $��25,5,0,0q�60   $	��Top=�6B   $��75��6Z   ��5A   $   �� *SaveCommand+y�6D   �� *
EditMode+ �� 	Converter# [  5B   Z   �� 5D      $	��Add��6   $
��Left=�5E      $��25,5,0,0q�60   $	��Top=�6B   $��75��6Z   ��5D   #   �� *SaveCommand+y�6C   �� *
EditMode+# [ 5E   Z   �� 5G      $��Cancel��6   $
��Left=�5H      $��	150,5,0,0q�60   $	��Top=�6C   $��75��6[   ��5G   &   �� *CancelCommand+5H   [   5I      � 5J   
   $��3��6   .+�5K      �� ��6   �� *StatusMessage+5L      5M      5N      