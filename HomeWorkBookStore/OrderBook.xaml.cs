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
    /// Interaction logic for OrderBook.xaml
    /// </summary>
    public partial class OrderBook : Window
    {
        public static OrderBook instance;
        public TextBox customerName;
        public String customerId;

        private string isbn;
        private string title;
        private float quatity;
        private float price;
        private float orderPrice;

        private float summaryPrice;

        //private int count;
        public OrderBook()
        {
            InitializeComponent();
            SelectData(cbxSearch.SelectedIndex, txtSearch.Text.Trim());

            instance = this;
            customerName = txtCustomerName;
        }

        private void btnSelectCustomer_Click(object sender, RoutedEventArgs e)
        {
            SelectCustomer selectCustomer = new SelectCustomer();
            selectCustomer.Show();
        }
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            SelectData(cbxSearch.SelectedIndex, txtSearch.Text.Trim());
        }
        private void btnAddCart_Click(object sender, RoutedEventArgs e) // ปุ่มเพิ่ม
        {
            BookList selectBook = (BookList)dgBook.SelectedValue;
            if (selectBook != null)
            {
                isbn = selectBook.Isbn;
                title = selectBook.Title;
                price = float.Parse(selectBook.Price);
                quatity = float.Parse(txtQuatity.Text);
                orderPrice = price * quatity;

                summaryPrice = summaryPrice + orderPrice;
                txtSummaryPrice.Text = summaryPrice.ToString();

                //MessageBox.Show("ISBN : " + isbn + " Title : " + title + " Price : " + price.ToString() + " Quatity : " + quatity.ToString() + " SumPrice : " + sumPrice.ToString());

                dgCart.Items.Add(new CartList(isbn, title, quatity.ToString(), orderPrice.ToString()));
                ClearVariable("AddCart");

            }
            else
            {
                MessageBox.Show("กรุณาเลือกหนังสือ", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e) // ปุ่มลบ
        {
            CartList item = (CartList)dgCart.SelectedValue;

            int index = -1;
            index = dgCart.SelectedIndex;

            if (index != -1)
            {
                dgCart.Items.RemoveAt(index);
                summaryPrice = summaryPrice - float.Parse(item.Price);
                txtSummaryPrice.Text = summaryPrice.ToString();
                dgCart.Items.Refresh();
            }
            else
            {
                MessageBox.Show("กรุณาเลือกหนังสือ", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void btnBuy_Click(object sender, RoutedEventArgs e)
        {
            List<List<string>> OrderList = new List<List<string>>();
            OrderList = GetDataGrit();

            if (customerId == null)
            {
                MessageBox.Show("กรุณาเลือกลูกค้า");
            }
            else
            {
                if (OrderList.Count == 0)
                {
                    MessageBox.Show("กรุณาเพิ่มหนังสือ", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (MessageBox.Show("ยืนยันการสั่งซื้อ", "ยืนยัน", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        bool checkStatus = DataAccess.InsertOrder(customerId.Trim(), OrderList);
                        if (checkStatus == true)
                        {
                            MessageBox.Show("สำเร็จ");
                            ClearVariable("BuyOrder");
                        }
                        else
                        {
                            MessageBox.Show("ไม่สำเร็จ");
                        }

                    }
                }
            }

        }

        //------------------------ Method ---------------------------

        private List<List<string>> GetDataGrit()
        {
            List<List<string>> OrderList = new List<List<string>>();
            int rows = dgCart.Items.Count; // จำนวน row

            for (int i = 0; i < rows; i++)
            {
                List<string> Order = new List<string>(); // แถว
                CartList item = (CartList)dgCart.Items[i]; // get แถว 

                Order.Add(item.Isbn);
                Order.Add(item.Quatity);
                Order.Add(item.Price);

                OrderList.Add(Order);

                //MessageBox.Show("Isbn : " + item.Isbn + " Title : " + item.Title + " Quatity : " + item.Quatity + " Price : " + item.Price);
            }
            return OrderList;

        }
        private void ClearVariable(string checkClear)
        {
            if (checkClear == "AddCart")
            {
                isbn = "";
                title = "";
                quatity = 0;
                price = 0;
                orderPrice = 0;
                txtQuatity.Text = "1";
            }
            else if (checkClear == "BuyOrder")
            {
                customerId = null;
                customerName.Text = "ชื่อลูกค้า : ";
                summaryPrice = 0;
                txtSummaryPrice.Text = "0";
                dgCart.Items.Clear();
            }

        }
        private void SelectData(int SearchCMB, string searchTxt)
        {
            dgBook.Items.Clear(); // เครียร์ข้อมูล
            List<List<string>> booklist = new List<List<string>>();
            booklist = DataAccess.GetBooks(SearchCMB, searchTxt);
            //MessageBox.Show(booklist[0][0] + booklist[0][1] + booklist[0][2] + booklist[0][3]);
            //MessageBox.Show(booklist.Count.ToString().Trim());
            if (booklist.Count == 0)
            {
                MessageBox.Show("ไม่พบข้อมูล", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                int row = booklist.Count; // get row
                //MessageBox.Show(row.ToString().Trim());
                for (int rowCount = 0; rowCount < row; rowCount++)
                {
                    //MessageBox.Show(booklist[rowCount][0] + " " + booklist[rowCount][1] + " " + booklist[rowCount][2] + " " + booklist[rowCount][3]);
                    dgBook.Items.Add(new BookList(booklist[rowCount][0], booklist[rowCount][1], booklist[rowCount][2], booklist[rowCount][3]));
                }
            }
        }

    }
}
