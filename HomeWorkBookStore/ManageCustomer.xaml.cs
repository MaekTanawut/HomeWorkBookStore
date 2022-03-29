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
    /// Interaction logic for ManageCustomer.xaml
    /// </summary>
    public partial class ManageCustomer : Window
    {
        string headerCustomer = "";
        public ManageCustomer()  
        {
            InitializeComponent();
            NotEditData("");
            SelectData(cbxSearch.SelectedIndex, txtSearch.Text.Trim());
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            SelectData(cbxSearch.SelectedIndex, txtSearch.Text.Trim());
        }

        private void dgCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CustomerList selectCustomer = (CustomerList)dgCustomer.SelectedValue;
            if (selectCustomer != null)
            {
                txtId.Text = selectCustomer.IdCustomer;
                txtName.Text = selectCustomer.CustomerNaeme;
                txtAddress.Text = selectCustomer.Address;
                txtEmail.Text = selectCustomer.Email;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            headerCustomer = "CustomerDetail : Add";
            gbBookDetail.Header = headerCustomer;
            NotEditData(headerCustomer);
            ClearTextBlock(headerCustomer);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (txtId.Text.Trim() == "")
            {
                MessageBox.Show("กรุณาเลือกหนังสือ", "ยืนยัน", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                headerCustomer = "CustomerDetail : Edit";
                gbBookDetail.Header = headerCustomer;
                NotEditData(headerCustomer);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (txtId.Text.Trim() == "")
            {
                MessageBox.Show("กรูณเลือกข้อมูลที่จะทำการลบ", "แจ้งเตือน", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (MessageBox.Show("ยืนยันการลบลูกค้า : " + txtName.Text.Trim(), "ยืนยัน", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DataAccess.DeleteCustomer(txtId.Text.Trim());
                    MessageBox.Show("สำเร็จ");
                    ClearTextBlock("");
                    SelectData(cbxSearch.SelectedIndex, txtSearch.Text.Trim());
                    NotEditData("");
                    headerCustomer = "CustomerDetail";
                    gbBookDetail.Header = headerCustomer;
                }
                else
                {
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            headerCustomer = "CustomerDetail";
            gbBookDetail.Header = headerCustomer;
            NotEditData("");
            ClearTextBlock("");
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

            if (headerCustomer == "CustomerDetail : Add")
            {
                if (MessageBox.Show("ยืนยันการเพิ่ม", "ยืนยัน", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    headerCustomer = "CustomerDetail";
                    gbBookDetail.Header = headerCustomer;
                    DataAccess.InsertCustomer(txtName.Text.ToString().Trim(), txtAddress.Text.ToString().Trim(), txtEmail.Text.ToString().Trim());
                    MessageBox.Show("สำเร็จ");
                    ClearTextBlock("");
                    SelectData(cbxSearch.SelectedIndex, txtSearch.Text.Trim());
                    NotEditData("");
                }
                else
                {

                }
            }
            else if (headerCustomer == "CustomerDetail : Edit")
            {
                if (MessageBox.Show("ยืนยันการแก้ไข", "ยืนยัน", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DataAccess.EditCustomer(txtId.Text.ToString().Trim(), txtName.Text.ToString().Trim(), txtAddress.Text.ToString().Trim(), txtEmail.Text.ToString().Trim());
                    MessageBox.Show("สำเร็จ");
                    SelectData(cbxSearch.SelectedIndex, txtSearch.Text.Trim());
                    ClearTextBlock("");
                    NotEditData("");
                    headerCustomer = "CustomerDetail";
                    gbBookDetail.Header = headerCustomer;
                }
                else
                {
                }
            }
        }

        //method

        private void ClearTextBlock(string headerBooks)
        {
            if (headerBooks == "CustomerDetail : Add")
            {
                //txtId.Clear();
                txtId.Text = DataAccess.GetEndID().ToString().Trim();
                txtName.Clear();
                txtAddress.Clear();
                txtEmail.Clear();
            }
            else if (headerBooks == "CustomerDetail : Edit")
            {
                txtName.Clear();
                txtAddress.Clear();
                txtEmail.Clear();
            }
            else
            {
                txtId.Clear();
                txtName.Clear();
                txtAddress.Clear();
                txtEmail.Clear();
            }
        }
        
        private void SelectData(int cbxSearch,string txtSearch)
        {
            dgCustomer.Items.Clear(); // เครียร์ข้อมูล

            List<List<string>> customersList = new List<List<string>>();


            customersList = DataAccess.GetCustomer(cbxSearch, txtSearch);

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
                    dgCustomer.Items.Add(new CustomerList(customersList[rowCount][0], customersList[rowCount][1], customersList[rowCount][2], customersList[rowCount][3]));
                }
            }

        }

        private void NotEditData(string headerBooks)
        {
            if (headerBooks == "CustomerDetail : Edit")
            {
                txtId.IsReadOnly = true;
                txtName.IsReadOnly = false;
                txtAddress.IsReadOnly = false;
                txtEmail.IsReadOnly = false;

                txtId.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(100, 248, 248, 248));
                txtName.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(100, 255, 255, 255));
                txtAddress.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(100, 255, 255, 255));
                txtEmail.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(100, 255, 255, 255));

                btnSubmit.Visibility = Visibility.Visible;
                btnCancel.Visibility = Visibility.Visible;
            }
            else if (headerBooks == "CustomerDetail : Add")
            {
                txtId.IsReadOnly = true;
                txtName.IsReadOnly = false;
                txtAddress.IsReadOnly = false;
                txtEmail.IsReadOnly = false;

                txtId.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(100, 248, 248, 248));
                txtName.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(100, 255, 255, 255));
                txtAddress.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(100, 255, 255, 255));
                txtEmail.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(100, 255, 255, 255));

                btnSubmit.Visibility = Visibility.Visible;
                btnCancel.Visibility = Visibility.Visible;
            }
            else
            {
                txtId.IsReadOnly = true;
                txtName.IsReadOnly = true;
                txtAddress.IsReadOnly = true;
                txtEmail.IsReadOnly = true;

                txtId.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(100, 248, 248, 248));
                txtName.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(100, 248, 248, 248));
                txtAddress.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(100, 248, 248, 248));
                txtEmail.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(100, 248, 248, 248));

                btnSubmit.Visibility = Visibility.Collapsed;
                btnCancel.Visibility = Visibility.Collapsed;
            }

        }

    }


}
