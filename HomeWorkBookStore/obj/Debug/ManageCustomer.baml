   M S B A M L   `   `   `  ����L  HHomeWorkBookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:HomeWorkBookStoreHomeWorkBookStore  5   	   &     HomeWorkBookStore.ManageCustomer   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:HomeWorkBookStore     5   	     � Title$  ManageCustomer��5   	   $	��450��6    $	��800��6-   .��5	      � .+�5
   
   �� -   5         ��Name$ 	cbxSearch��5
      $
��Left=�6&   $��	56,38,0,0q�6A   $	��Top=�6T   $��78��6l    �� SelectedIndex$ 0��6w   .@�5      �� $��ทั้งหมด��6   �� 5      $��
IDCustomer��6   �� 5      $
��Name��6   5      �� 5   
   -   5         ��Name$ 	btnSearch��5      $��Search��6$   $
��Left=�65   $��
299,40,0,0q�6P   $	��Top=�6d   $��20��6|   $��57��6�   6�   �� 5   
   -   5         ��Name$ 	txtSearch��5      $
��Left=�6%   $��
154,40,0,0q�6@    �� TextWrapping$
 Wrap=�6T   $	��Top=�6h   $	��120��6�   �� 5   
   -   5         ��Name$ gbBookDetail��5      $
��Left=�6)   $	��302��6D   $��CustomerDetail��6Q   $��
442,38,0,0q�6i   $	��Top=�6}   $	��307��6�   .��5      � .+�5      �� -   5        $ txtId��5      $
��Left=�6)   $��
128,38,0,0q�6D   $
 Wrap=�6X   $	��Top=�6l   $	��120��6�   �� 5      $
��Left=�6   $��	32,38,0,0q�67   $
��Wrap=�6J   $	��Top=�6^   $��ID Customer  :��6v   �� 5      $
��Left=�6   $��	32,87,0,0q�67   $
��Wrap=�6J   $��Name  :��6^   $	��Top=�6m   �� 5      $
��Left=�6   $��
32,132,0,0q�67   $
��Wrap=�6K   $��	Address :��6_   $	��Top=�6p   �� 5      $
��Left=�6   $��
32,180,0,0q�67   $
��Wrap=�6K   $��Email :��6_   $	��Top=�6n   �� 5      -   5        $ 	btnSubmit��5      $��ยืนยัน��6,   $
��Left=�6=   $��
59,237,0,0q�6X   $	��Top=�6l   $��22��6�   $��54��6�   $y�Visible=�6�   6�   �� 5      -   5        $ 	btnCancel��5      $��ยกเลิก��6,   $
��Left=�6=   $��188,237,0,0q�6X   $	��Top=�6m   $y�Visible=�6�   $��54��6�   $��22��6�   6�   5      5      �� 5   
   -   5        $ txtName��5      $
��Left=�6#   $��576,140,0,0q�6>   $
 Wrap=�6S   $	��Top=�6g   $	��120��6   �� 5   
   -	   5        $ 
txtAddress��5      $
��Left=�6&   $��576,185,0,0q�6A   $
 Wrap=�6V   $	��Top=�6j   $	��120��6�   �� 5   
   -
   5        $ txtEmail��5      $
��Left=�6$   $��576,229,0,0q�6?   $
 Wrap=�6T   $	��Top=�6h   $	��120��6�   �� 5   
   -   5        $ btnAdd��5      $'��!เพิ่มลูกค้า��6!   $
��Left=�67   $��469,357,0,0q�6R   $	��Top=�6g   $��62��6   6�   �� 5    
   -   5        $ 	btnDelete��5       $��ลบลูกค้า��6$   $
��Left=�67   $��685,357,0,0q�6R   $	��Top=�6g   6   �� 5!   
   -   5        $ btnEdit��5!      $<��6แก้ไขรายรายละเอียด��6"   $
��Left=�6?   $��558,357,0,0q�6Z   $	��Top=�6o   $	��102��6�   6�   � 5"   
   $
��Left=�6   $	��319��6*   $��	44,78,0,0q�67   $	��Top=�6J   $	��356��6b   .+�5#      &   System.Windows.Controls.DataGrid  -   5          Name$ 
dgCustomer��5#         Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn	   HeaderStringFormat$	 
IDCustomer��6)   
   Header$
 
IDCustomer��6I      Width5  /System.Windows.Controls.DataGridLengthConverter$ 88 6|      CanUserResize .  1  +System.Windows.Controls.DataGridBoundColumn   Binding 6]   �� *
IdCustomer+6�     5&      $
	 Name��6)   $

 Name��6C    .  $ 88 6�    6Q   �� *CustomerNaeme+6�     5'      $	 Address��6)   $
 Address��6F    .  $ 88 6�    6W   �� *	Address+6�     5(      $	 Email��6)   $
 Email��6D    .  $ 87 6�    6S   �� *Email+6�   5*      5+      5-      5.      