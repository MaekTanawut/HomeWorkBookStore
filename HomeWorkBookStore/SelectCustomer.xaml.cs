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
    /// Interaction logic for SelectCustomer.xaml
    /// </summary>
    public partial class SelectCustomer : Window
    {
        public static SelectCustomer instance;

        public SelectCustomer()
        {
            InitializeComponent();
            SelectData(cbxSearch.SelectedIndex, txtSearch.Text);

            instance = this;
            
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            SelectData(cbxSearch.SelectedIndex, txtSearch.Text);
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            CustomerList selectCustomer = (CustomerList)CustomersDg.SelectedValue;

            if (selectCustomer != null)
            {
                OrderBook.instance.customerName.Text = "ชื่อลูกค้า : "+selectCustomer.CustomerNaeme;
                OrderBook.instance.customerId = selectCustomer.IdCustomer;
                this.Close();
            }
            else
            {
                MessageBox.Show("กรุณาเลือกข้อมูลพนักงาน");
            }
            
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //method
        private void SelectData(int cbxIndex, string TxtSearch)
        {
            CustomersDg.Items.Clear(); // เครียร์ข้อมูล

            List<List<string>> customersList = new List<List<string>>();


            customersList = DataAccess.GetCustomer(cbxIndex, TxtSearch);

            //MessageBox.Show(booklist[0][0] + booklist[0][1] + booklist[0][2] + booklist[0][3]);
            //MessageBox.Show(booklist.Count.ToString().Trim());


            if (customersList.Count == 0)
            {
                MessageBox.Show("ไม่พบข้อมูล", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                int row = customersList.Count; // get row

                //MessageBox.Show(row.ToString().Trim());

                for (int rowCount = 0; rowCount < row; rowCount++)
                {
                    //MessageBox.Show(booklist[rowCount][0] + " " + booklist[rowCount][1] + " " + booklist[rowCount][2] + " " + booklist[rowCount][3]);
                    CustomersDg.Items.Add(new CustomerList(customersList[rowCount][0], customersList[rowCount][1], customersList[rowCount][2], customersList[rowCount][3]));
                }
            }

        }

    }
}
