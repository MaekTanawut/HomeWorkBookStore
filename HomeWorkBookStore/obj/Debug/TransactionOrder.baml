   M S B A M L   `   `   `  ����L  HHomeWorkBookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:HomeWorkBookStoreHomeWorkBookStore  5   	   (    "HomeWorkBookStore.TransactionOrder   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:HomeWorkBookStore     5   	     � Title$  TransactionOrder��5   	   $	��450��6"   $	��800��6/   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgTransactions��5
      $��50,101,50,41q�6V      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   HeaderStringFormat$ Tran_ID��6%      Header$ Tran_ID��6B      Width5  /System.Windows.Controls.DataGridLengthConverter$	 116 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6_   �� *TranID+  5      $ Customer_Name��6%   $ Customer_Name��6H   $	 116 6_    6k   �� *CustomerName+  5      -   5        dataGridTextColumn��$
 ISBN��5   A   $	 116 6h    6O   �� *Isbn+6h     5      $ Title��6%   $ Title��6@   $	 116 6O    6[   �� *Title+  5      $ Quatity��6%   $ Quatity��6B   $	 116 6S    6_   �� *	Quatity+  5      $ Total_Price��6%   $ Total_Price��6F   $	 116 6[    6g   �� *
TotalPrice+5      �� 5   
   -   5         ��Name$ 	btnSearch��5      $��Search��6$   $
��Left=�65   $��
500,45,0,0q�6P   $	��Top=�6d   $��20��6|   $��57��6�   6�   �� 5   
   -   5        	 ��Name$	 	txtSearch��5      $
��Left=�6%   $��
354,47,0,0q�6@   
 �� TextWrapping$

 Wrap=�6T   $	��Top=�6h   $	��120��6�   �� 5   
   -   5         ��Name$ 	cbxSearch��5      $
��Left=�6&   $��
246,45,0,0q�6A   $	��Top=�6U   $��78��6m    �� SelectedIndex$ 0��6x   .@�5      �� $��ทั้งหมด��6   �� 5      $��TransactionsID ��6   �� 5      $��CustomerName��6   �� 5      $
��ISBN��6   5      5      5      