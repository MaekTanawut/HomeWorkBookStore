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
using System.Windows.Threading;

namespace HomeWorkBookStore
{
    /// <summary>
    /// Interaction logic for HomeMenu.xaml
    /// </summary>
    public partial class HomeMenu : Window
    {
        public HomeMenu()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(UpdateTimer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

            InitializeComponent();

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnManageBook_Click(object sender, RoutedEventArgs e)
        {
            ManageBook manageBook = new ManageBook();
            manageBook.Show();
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderBook orderBook = new OrderBook();
            orderBook.Show();
        }

        private void btnCustomerManage_Click(object sender, RoutedEventArgs e)
        {
            ManageCustomer ManageCustomer = new ManageCustomer();
            ManageCustomer.Show();
        }

        private void btnOrderHistory_Click(object sender, RoutedEventArgs e)
        {
            TransactionOrder transactionOrder = new TransactionOrder();
            transactionOrder.Show();
        }

        //method
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            DateTimeTxt.Text = DateTime.Now.ToString();
        }

    }
}
