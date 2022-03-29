using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HomeWorkBookStore
{
    /// <summary>
    /// Interaction logic for TransactionOrder.xaml
    /// </summary>
    public partial class TransactionOrder : Window
    {
        public TransactionOrder()
        {
            InitializeComponent();
            SelectData(cbxSearch.SelectedIndex, txtSearch.Text);
        }
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            SelectData(cbxSearch.SelectedIndex, txtSearch.Text);
        }
        private void SelectData(int searchCbx, string searchTxt)
        {
            dgTransactions.Items.Clear(); // เครียร์ข้อมูล

            List<List<string>> transactionList = new List<List<string>>();


            transactionList = DataAccess.GetTransactions(searchCbx, searchTxt);

            //MessageBox.Show(booklist[0][0] + booklist[0][1] + booklist[0][2] + booklist[0][3]);
            //MessageBox.Show(booklist.Count.ToString().Trim());


            if (transactionList.Count == 0)
            {
                MessageBox.Show("ไม่พบข้อมูล", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                int row = transactionList.Count; // get row
                //MessageBox.Show(row.ToString().Trim());
                for (int rowCount = 0; rowCount < row; rowCount++)
                {
                    //MessageBox.Show(transactionList[rowCount][0] + " " + transactionList[rowCount][1] + " " + transactionList[rowCount][2] + " " + transactionList[rowCount][3] + " " + transactionList[rowCount][4] + " " + transactionList[rowCount][5]);
                    dgTransactions.Items.Add(new TransactionsList(transactionList[rowCount][0], transactionList[rowCount][1], transactionList[rowCount][2], transactionList[rowCount][3], transactionList[rowCount][4], transactionList[rowCount][5]));
                }
            }

        }

    }
}
