   M S B A M L   `   `   `  ����H  DWPFStudyGuide, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:WPFStudyGuide.Classes.OtherWPFStudyGuide.Classes.Other  5      O,clr-namespace:WPFStudyGuide.ViewModels.OtherWPFStudyGuide.ViewModels.Other  5      F    @WPFStudyGuide.Views.Other.PropertyChangeNotificationsExampleView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:WPFStudyGuide.Classes.Other     5      C
viewModels,clr-namespace:WPFStudyGuide.ViewModels.Other     5      1   +WPFStudyGuide.Classes.Other.MyMvvmBehaviors    LoadedMethodName$  LoadCustomers��5
       � DataContext 5      P   JWPFStudyGuide.ViewModels.Other.PropertyChangeNotificationsExampleViewModel  5   
    J� InputBindings 5      �� 5   
   
 �� Key$ D��6    �� 	Modifiers$
 Ctrlf�6    �� Command 6.   �� *DeleteCommand+.��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��6* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   ��    BaseHeaderTitle#��[  65   ��6   �� *ViewHeaderTitle+65   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ customerDataGrid��5         AutoGenerateColumns .  	   EnableRowVirtualization	 . 
   RowDetailsVisibilityMode$
 VisibleWhenSelected=�5!      $	��500��5#      ��5       �� *	Customers+ �� SelectedItem 5"      �� *SelectedCustomer+   Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      -   5        firstNameColumn��,  &System.Windows.Controls.DataGridColumn   Header$ 
First Name��5%   \      Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToCells 6p   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *	FirstName+6p     5&      -   5        lastNameColumn��$ 	Last Name��5&   Z   $ SizeToHeader 6m    6=   �� *
LastName+6m     5'      -   5        phoneColumn��$ Phone��5'   T   $ SizeToCells 6c    6:   �� *Phone+6c     5(      -   5        emailColumn��$ Email��5(   T   $ SizeToCells 6c    6:   �� *Email+6c     5)      -   5        streetColumn��$ Street��5)   V   $ SizeToCells 6f    6;   �� *Street+6f     5*      -   5        
cityColumn��$
 City��5*   R   $ SizeToCells 6`    69   �� *City+6`     5+      -   5        stateColumn��$ State��5+   T   $ SizeToCells 6c    6:   �� *State+6c     5,      -	   5        	zipColumn��$	 Zip��5,   P   $ SizeToCells 6]    68   �� *Zip+6]     5-      -
   5        fullAddressColumn��$ Full Address��5-   Z   $ SizeToCells 6p      
IsReadOnly .  6@   �� *Email+6�   5/      �� 51   
   $��1��6   
���  ����6!   �� *ErrorMessage+6?   �� 53   
   $��2��6   $��Delete��6   $��Center=�6w   $	��Top=�6�   $��75��6�   ��6/   �� *DeleteCommand+{�6Q   �� *IsDeleteEnabled+6�   �� 54   
   $��3��6   $��Change Customer��6   $��Center=�6b   $	��Top=�6   $	��200��6�   ��68   �� *ChangeCustomerCommand+6�   56      57      