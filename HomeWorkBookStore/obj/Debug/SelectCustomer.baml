   M S B A M L   `   `   `  ����L  HHomeWorkBookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:HomeWorkBookStoreHomeWorkBookStore  5   	   &     HomeWorkBookStore.SelectCustomer   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:HomeWorkBookStore     5   	     � Title$  SelectCustomer��5   	   $	��450��6    $	��397��6-   .��5	      � .+�5
   
   �� -   5         ��Name$ 	cbxSearch��5
      $
��Left=�6&   $��	45,38,0,0q�6A   $	��Top=�6T   $��78��6l    �� SelectedIndex$ 0��6w   .@�5      �� $��ทั้งหมด��6   �� 5      $��
IDCustomer��6   �� 5      $
��Name��6   5      �� 5   
   -   5         ��Name$ 	txtSearch��5      $
��Left=�6%   $��
143,40,0,0q�6@    �� TextWrapping$
 Wrap=�6T   $	��Top=�6h   $	��120��6�   �� 5   
   -   5         ��Name$ 	btnSearch��5      $��Search��6$   $
��Left=�65   $��
288,40,0,0q�6P   $	��Top=�6d   $��20��6|   $��57��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ CustomersDg��5      $��21,81,20,108q�6(      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   HeaderStringFormat$ 
IDCustomer��6%   	   Header$	 
IDCustomer��6E   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 88 6x      CanUserResize .  1  +System.Windows.Controls.DataGridBoundColumn   Binding 6Y   �� *
IdCustomer+6�     5      $
 Name��6%   $
	 Name��6?    .  $
 88 6�    6M   �� *CustomerNaeme+6�     5      $ Address��6%   $	 Address��6B    .  $
 88 6�    6S   �� *	Address+6�     5      $ Email��6%   $	 Email��6@    .  $
 87 6    6O   �� *Email+6   5      �� 5   
   -   5        $ 	btnSubmit��5      $��ยืนยัน��6$   $
��Left=�65   $��28��6P   $��
77,369,0,0q�6\   $	��Top=�6p   $��81��6�    J� RenderTransformOrigin$ 0.528,0.887&�6�   6�   �� 5   
   -   5        $ 	btnCancel��5      $��ยกเลิก��6$   $
��Left=�65   $��28��6P   $��236,369,0,0q�6\   $	��Top=�6q   $��80��6�   $ 0.528,0.887&�6�   6�   5      5      