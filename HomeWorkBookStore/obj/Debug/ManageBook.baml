   M S B A M L   `   `   `  ����L  HHomeWorkBookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:HomeWorkBookStoreHomeWorkBookStore  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   "    HomeWorkBookStore.ManageBook   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:HomeWorkBookStore     5   	   9System&clr-namespace:System;assembly=mscorlib     5   	     � Title$  
ManageBook��5	   	   $	��450��6   $	��800��6)   .��5
      � -   5         �Name$ booksTB��5
      .+�5   
   �� -   5         ��Name$ cbxIndex��5      $
��Left=�6%   $��	56,38,0,0q�6@   $	��Top=�6S   $��78��6k    �� SelectedIndex$ 0��6v   .@�5      �� $��ทั้งหมด��6   �� 5      $
��ISBN��6   �� 5      $��Title��6   5      �� 5   
   -   5         ��Name$ 	btnSearch��5      $��Search��6$   $
��Left=�65   $��
299,40,0,0q�6P   $	��Top=�6d   $��20��6�   $��57��6�   �� 5   
   -   5         ��Name$ 	txtSearch��5      $
��Left=�6%   $��
154,40,0,0q�6@    �� TextWrapping$
 Wrap=�6T   $	��Top=�6h   $	��120��6�   �� 5   
   -   5         ��Name$ gbBookDetail��5      $
��Left=�6)   $	��302��6D   $��
BookDetail��6Q   $��
442,38,0,0q�6e   $	��Top=�6y   $	��307��6�   .��5      � .+�5      �� -   5        $ txtIsbn��5      $
��Left=�6+   $��
128,38,0,0q�6F   $
 Wrap=�6Z   $	��Top=�6n   $	��120��6�   �� 5      $
��Left=�6   $��	32,38,0,0q�67   $
��Wrap=�6J   $	��Top=�6^   $��ISBN :��6v   �� 5      $
��Left=�6   $��	32,87,0,0q�67   $
��Wrap=�6J   $��Title :��6^   $	��Top=�6m   �� 5      $
��Left=�6   $��
32,132,0,0q�67   $
��Wrap=�6K   $��Description :��6_   $	��Top=�6t   �� 5      $
��Left=�6   $��
32,180,0,0q�67   $
��Wrap=�6K   $��Price :��6_   $	��Top=�6n   �� 5      -   5        $ 	btnSubmit��5      $��ยืนยัน��6,   $
��Left=�6=   $��
59,237,0,0q�6X   $	��Top=�6l   $��22��6�   $��54��6�   $y�Visible=�6�   6�   �� 5      -   5        $ 	btnCancel��5      $��ยกเลิก��6,   $
��Left=�6=   $��188,237,0,0q�6X   $	��Top=�6m   $y�Visible=�6�   $��54��6�   $��22��6�   5      5      �� 5   
   -	   5        $ txtTitle��5      $
��Left=�6$   $��576,140,0,0q�6?   $
 Wrap=�6T   $	��Top=�6h   $	��120��6�   �� 5   
   -
   5        $ txtDescription��5      $
��Left=�6*   $��576,185,0,0q�6E   $
 Wrap=�6Z   $	��Top=�6n   $	��120��6�   �� 5   
   -   5        $ txtPrice��5      $
��Left=�6$   $��576,229,0,0q�6?   $
 Wrap=�6T   $	��Top=�6h   $	��120��6�   �� 5    
   -   5        $ btnAdd��5       $*��$เพิ่มหนังสือ��6!   $
��Left=�68   $��469,357,0,0q�6S   $	��Top=�6h   $��62��6�   �� 5!   
   -   5        $ 	btnDelete��5!      $!��ลบหนังสือ��6$   $
��Left=�68   $��685,357,0,0q�6S   $	��Top=�6h   6�   �� 5"   
   -   5        $ btnEdit��5"      $<��6แก้ไขรายรายละเอียด��6"   $
��Left=�6?   $��558,357,0,0q�6Z   $	��Top=�6o   $	��102��6�   6�   � 5#   
   $
��Left=�6   $	��319��6*   $��	44,78,0,0q�67   $	��Top=�6J   $	��356��6b   .+�5$      &   System.Windows.Controls.DataGrid  -   5          Name$ dgBook��5$      	   Columns	 5%      0  *System.Windows.Controls.DataGridTextColumn  5&      ,  &System.Windows.Controls.DataGridColumn
   HeaderStringFormat$

 ISBN��6)      Header$
 ISBN��6C      Width5  /System.Windows.Controls.DataGridLengthConverter$ 88 6j      CanUserResize .  1  +System.Windows.Controls.DataGridBoundColumn   Binding 6Q   �� *Isbn+6u     5'      $
 Title��6)   $ Title��6D    .  $ 88 6�    6S   �� *Title+6�     5(      $
 Description��6)   $ Description��6J    .  $ 88 6�    6_   �� *Description+6�     5)      $
 Price��6)   $ Price��6D    .  $ 87 6�    6S   �� *Price+6�   5+      5,      5.      5/      