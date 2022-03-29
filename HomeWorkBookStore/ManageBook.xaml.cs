using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for ManageBook.xaml
    /// </summary>
    public partial class ManageBook : Window
    {
        string headerBooks = "";

        public ManageBook()
        {
            InitializeComponent();
            NotEditData("");
            SelectData(cbxIndex.SelectedIndex,txtSearch.Text.Trim());

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            SelectData(cbxIndex.SelectedIndex, txtSearch.Text.Trim());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            headerBooks = "BookDetail : Add";
            gbBookDetail.Header = headerBooks;
            NotEditData(headerBooks);
            ClearTextBlock(headerBooks);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (txtIsbn.Text.Trim() == "")
            {
                MessageBox.Show("กรุณาเลือกหนังสือ", "ยืนยัน", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                headerBooks = "BookDetail : Edit";
                gbBookDetail.Header = headerBooks;
                NotEditData(headerBooks);
                txtIsbn.IsReadOnly = true;
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (txtIsbn.Text.Trim() == "")
            {
                MessageBox.Show("กรูณเลือกข้อมูลที่จะทำการลบ", "แจ้งเตือน", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (MessageBox.Show("ยืนยันการลบหนังสือ : " + txtTitle.Text.Trim(), "ยืนยัน", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DataAccess.DeleteBook(txtIsbn.Text.Trim());
                    MessageBox.Show("สำเร็จ");
                    ClearTextBlock("");
                    SelectData(cbxIndex.SelectedIndex, txtSearch.Text.Trim());
                    NotEditData("");
                    headerBooks = "BookDetail";
                    gbBookDetail.Header = headerBooks;
                }
                else
                {
                }
            }

        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (headerBooks == "BookDetail : Add")
            {
                if (CheckDataTypePrice(txtPrice.Text.Trim()))
                {
                    if (DataAccess.CheckIsbn(txtIsbn.Text))
                    {
                        if (MessageBox.Show("ยืนยันการเพิ่ม", "ยืนยัน", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            headerBooks = "BookDetail";
                            gbBookDetail.Header = headerBooks;
                            DataAccess.InsertBook(txtIsbn.Text.ToString().Trim(), txtTitle.Text.ToString().Trim(), txtDescription.Text.ToString().Trim(), txtPrice.Text.ToString().Trim());
                            MessageBox.Show("สำเร็จ");
                            ClearTextBlock("");
                            SelectData(cbxIndex.SelectedIndex, txtSearch.Text.Trim());
                            NotEditData("");

                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        MessageBox.Show("ISBN ซ้ำกรุณากรอก ISBN ใหม่");
                    }
                }
                else
                {
                    MessageBox.Show("กรุณากรอกราคาเป็นตัวเลข");
                }
            }
            else if (headerBooks == "BookDetail : Edit")
            {
                if (CheckDataTypePrice(txtPrice.Text.Trim()))
                {
                    if (MessageBox.Show("ยืนยันการแก้ไข", "ยืนยัน", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        DataAccess.EditBook(txtIsbn.Text.ToString().Trim(), txtTitle.Text.ToString().Trim(), txtDescription.Text.ToString().Trim(), txtPrice.Text.ToString().Trim());
                        MessageBox.Show("สำเร็จ");
                        SelectData(cbxIndex.SelectedIndex, txtSearch.Text.Trim());
                        ClearTextBlock("");
                        NotEditData("");
                        headerBooks = "BookDetail";
                        gbBookDetail.Header = headerBooks;
                    }
                    else
                    {
                    }
                }
                else
                {
                    MessageBox.Show("กรุณากรอกราคาเป็นตัวเลข");
                }

            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            btnSubmit.Visibility = Visibility.Collapsed;
            btnCancel.Visibility = Visibility.Collapsed;
            headerBooks = "BookDetail";
            gbBookDetail.Header = headerBooks;
            NotEditData("");
            ClearTextBlock("");
        }

        private void dgBook_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BookList selectBook = (BookList)dgBook.SelectedValue;
            if (selectBook != null)
            {
                txtIsbn.Text = selectBook.Isbn;
                txtTitle.Text = selectBook.Title;
                txtDescription.Text = selectBook.Description;
                txtPrice.Text = selectBook.Price;
            }
        }

        //method

        private void ClearTextBlock(string headerBooks)
        {
            if (headerBooks == "BookDetail : Add")
            {
                txtIsbn.Clear();
                txtTitle.Clear();
                txtDescription.Clear();
                txtPrice.Clear();
            }
            else if (headerBooks == "BookDetail : Edit")
            {
                txtTitle.Clear();
                txtDescription.Clear();
                txtPrice.Clear();
            }
            else
            {
                txtIsbn.Clear();
                txtTitle.Clear();
                txtDescription.Clear();
                txtPrice.Clear();
            }
        }

        private void SelectData(int cbxIndex, string txtSearch)
        {
            dgBook.Items.Clear(); // เครียร์ข้อมูล

            List<List<string>> booklist = new List<List<string>>();


            booklist = DataAccess.GetBooks(cbxIndex, txtSearch);

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

        private void NotEditData(string headerBooks)
        {
            if (headerBooks == "BookDetail : Edit")
            {
                txtIsbn.IsReadOnly = true;
                txtTitle.IsReadOnly = false;
                txtDescription.IsReadOnly = false;
                txtPrice.IsReadOnly = false;

                txtIsbn.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(100, 248, 248, 248));
                txtTitle.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(100, 255, 255, 255));
                txtDescription.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(100, 255, 255, 255));
                txtPrice.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(100, 255, 255, 255));

                btnSubmit.Visibility = Visibility.Visible;
                btnCancel.Visibility = Visibility.Visible;
            }
            else if (headerBooks == "BookDetail : Add")
            {
                txtIsbn.IsReadOnly = false;
                txtTitle.IsReadOnly = false;
                txtDescription.IsReadOnly = false;
                txtPrice.IsReadOnly = false;

                txtIsbn.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(100, 255, 255, 255));
                txtTitle.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(100, 255, 255, 255));
                txtDescription.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(100, 255, 255, 255));
                txtPrice.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(100, 255, 255, 255));

                btnSubmit.Visibility = Visibility.Visible;
                btnCancel.Visibility = Visibility.Visible;
            }
            else
            {
                txtIsbn.IsReadOnly = true;
                txtTitle.IsReadOnly = true;
                txtDescription.IsReadOnly = true;
                txtPrice.IsReadOnly = true;

                txtIsbn.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(100, 248, 248, 248));
                txtTitle.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(100, 248, 248, 248));
                txtDescription.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(100, 248, 248, 248));
                txtPrice.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(100, 248, 248, 248));

                btnSubmit.Visibility = Visibility.Collapsed;
                btnCancel.Visibility = Visibility.Collapsed;
            }

        }

        private bool CheckDataTypePrice(string price)
        {
            float number;
            bool result = float.TryParse(price, out number);
            return result;
        }

    }
}
