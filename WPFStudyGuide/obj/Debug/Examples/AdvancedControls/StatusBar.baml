   M S B A M L   `   `   `  ����  WPFStudyGuide7    1WPFStudyGuide.Examples.AdvancedControls.StatusBar   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      � .+�5	   
   �� -   5        $��	statusBar��5	      $��Bottom=�6%   
�������.@�5
      �� .��5      �� $��Downloading File��6   5      �� 5      .��5      � -   5        $��progressBar��5   6   $	��100��6   $��20��6*     � Triggers  5      :� 5       :� RoutedEvent$ ProgressBar.Loaded��6'   .[�5      �� .��5   "   �� .��5   &   W�  �� 
TargetName$ progressBar��66    �� TargetProperty$ Value�5   6    W� From$ 0X�5   6   	 W� To$	 100X�5   6    g� Duration$ 0:0:10D�5   6   5   #   5      5      5      5      5      �� 5    
   �� 5"   
   .��5#      �� Online6    5$      �� 5%   
   $��Right=�6   .��5&      �� -   5        $
��Help��5&   $   $
��Help��6   60   5'      5(      5)      