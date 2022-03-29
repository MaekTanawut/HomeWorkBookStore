using Microsoft.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkBookStore
{
    internal class DataAccess
    {

        ArrayList arrayList;

        //------------------ Login ---------------------------
        public static bool CheckLogin(string userName, string password)
        {
            using (var connection = new SqliteConnection("Data Source=BookStore.db")) //เชื่อม DB
            {

                string userNameTb = "";
                string passwordTb = "";

                var loginCommand = connection.CreateCommand(); // สร้าง CommandText 

                loginCommand.CommandText = @"SELECT * FROM Employee WHERE emp_username = @userName and emp_password = @password"; //ใส่ sql statement
                loginCommand.Parameters.AddWithValue("@userName", userName); //ใส่ Parameters 1
                loginCommand.Parameters.AddWithValue("@password", password); //ใส่ Parameters 2

                Console.WriteLine(loginCommand.CommandText);

                connection.Open(); // เปิด DB
                SqliteDataReader query = loginCommand.ExecuteReader(); // Execute sql statement แล้วใส่ในตัวแปรชื่อ query

                if (query.Read()) // ใช้ loop while
                {
                    userNameTb = query.GetValue(1).ToString().Trim();
                    passwordTb = query.GetValue(2).ToString().Trim();
                }
                else
                {
                    userNameTb = "";
                    passwordTb = "";
                }
                connection.Close();

                if (userName == userNameTb && password == passwordTb)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        //------------------ ManageBook ---------------------------
        public static List<List<string>> GetBooks(int cbxIndex, string textSearch)
        {
            using (var connection = new SqliteConnection("Data Source=BookStore.db")) //เชื่อม DB
            {
                List<List<string>> booklist = new List<List<string>>(); //เก็บ Book
                var searchBooksCommand = connection.CreateCommand(); // สร้าง CommandText 


                if (cbxIndex == 1)
                {
                    searchBooksCommand.CommandText = @"SELECT * FROM Books WHERE ISBN LIKE '%' || @textSearch || '%' "; //ใส่ sql statement
                    searchBooksCommand.Parameters.AddWithValue("@textSearch", textSearch); //ใส่ Parameters 1
                    //Console.WriteLine(searchBooksCommand.CommandText);
                }
                else if (cbxIndex == 2)
                {
                    searchBooksCommand.CommandText = @"SELECT * FROM Books WHERE Title LIKE '%' || @textSearch || '%' "; //ใส่ sql statement
                    searchBooksCommand.Parameters.AddWithValue("@textSearch", textSearch); //ใส่ Parameters 1
                    //Console.WriteLine(searchBooksCommand.CommandText);
                }
                else
                {
                    searchBooksCommand.CommandText = @"SELECT * FROM Books"; //ใส่ sql statement
                    Console.WriteLine(searchBooksCommand.CommandText);
                }

                //Console.WriteLine(searchBooksCommand.CommandText);
                connection.Open(); // เปิด DB
                SqliteDataReader query = searchBooksCommand.ExecuteReader(); // Execute sql statement แล้วใส่ในตัวแปรชื่อ query
                int cloumSum = query.FieldCount; // แถว
                int rowCount = 0; // แถว
                //Console.WriteLine(cloumSum.ToString().Trim());
                //Console.WriteLine(rowCount.ToString().Trim());
                while (query.Read()) // loop row
                {
                    List<string> book = new List<string>(); // สร้าง list ด้านใน
                    //Console.WriteLine("RowCount : " + rowCount.ToString().Trim()); // Rownum
                    //Console.WriteLine("-----------------------------------------------");
                    for (int i = 0; i < cloumSum; i++)  //loop cloum
                    {
                        book.Add(query.GetString(i).Trim());  // add cloum
                        //Console.WriteLine("Cloum : " + i.ToString().Trim()); // Rownum
                    }
                    rowCount++; // count row
                    booklist.Add(book); // add ไปยัง Booklist
                }
                connection.Close(); // ปิด sqlite
                return booklist; // ส่งค่ากลับไป
            }
        }

        public static void InsertBook(string isbn, string title, string description, string price)
        {
            using (var connection = new SqliteConnection("Data Source=BookStore.db")) //เชื่อม DB
            {

                var insertBookCommand = connection.CreateCommand(); // สร้าง CommandText 
                insertBookCommand.CommandText = @"INSERT INTO Books (ISBN, Title, Description, Price) VALUES  (@isbn, @title, @description, @price)"; //ใส่ sql statement

                insertBookCommand.Parameters.AddWithValue("@isbn", isbn); //ใส่ Parameters 1
                insertBookCommand.Parameters.AddWithValue("@title", title); //ใส่ Parameters 2
                insertBookCommand.Parameters.AddWithValue("@description", description); //ใส่ Parameters 3
                insertBookCommand.Parameters.AddWithValue("@price", float.Parse(price)); //ใส่ Parameters 4

                connection.Open(); // เปิด DB
                SqliteDataReader query = insertBookCommand.ExecuteReader(); // Execute sql statement แล้วใส่ในตัวแปรชื่อ query
                connection.Close();
            }
        }

        public static void DeleteBook(string isbn)
        {
            using (var connection = new SqliteConnection("Data Source=BookStore.db")) //เชื่อม DB
            {
                var deleteBookCommand = connection.CreateCommand(); // สร้าง CommandText 
                deleteBookCommand.CommandText = @"DELETE FROM books WHERE ISBN = @isbn"; //ใส่ sql statement
                deleteBookCommand.Parameters.AddWithValue("@isbn", isbn); //ใส่ Parameters 1
                //Console.WriteLine(deleteCommand.CommandText.ToString().Trim());
                connection.Open(); // เปิด DB
                SqliteDataReader query = deleteBookCommand.ExecuteReader(); // Execute sql statement แล้วใส่ในตัวแปรชื่อ query
                connection.Close();
            }

        }

        public static void EditBook(string isbn, string title, string description, string price)
        {

            using (var connection = new SqliteConnection("Data Source=BookStore.db")) //เชื่อม DB
            {
                var editBookCommand = connection.CreateCommand(); // สร้าง CommandText 
                editBookCommand.CommandText = @"
                UPDATE Books
                SET Title= @title , Description= @description , Price= @price
                WHERE ISBN = @isbn
                "; //ใส่ sql statement
                editBookCommand.Parameters.AddWithValue("@isbn", isbn); //ใส่ Parameters 1
                editBookCommand.Parameters.AddWithValue("@title", title); //ใส่ Parameters 1
                editBookCommand.Parameters.AddWithValue("@description", description); //ใส่ Parameters 1
                editBookCommand.Parameters.AddWithValue("@price", float.Parse(price)); //ใส่ Parameters 1
                //Console.WriteLine(editBookCommand.CommandText.ToString().Trim());
                connection.Open(); // เปิด DB
                SqliteDataReader query = editBookCommand.ExecuteReader(); // Execute sql statement แล้วใส่ในตัวแปรชื่อ query
                connection.Close();
            }

        }

        public static bool CheckIsbn(string isbn)
        {
            using (var connection = new SqliteConnection("Data Source=BookStore.db")) //เชื่อม DB
            {
                var checkIsbnCommand = connection.CreateCommand(); // สร้าง CommandText 
                checkIsbnCommand.CommandText = @"SELECT count(ISBN) FROM Books WHERE isbn = @isbn"; //ใส่ sql statement
                checkIsbnCommand.Parameters.AddWithValue("@isbn", isbn); //ใส่ Parameters 1
                connection.Open(); // เปิด DB
                SqliteDataReader query = checkIsbnCommand.ExecuteReader(); // Execute sql statement แล้วใส่ในตัวแปรชื่อ query

                //Console.WriteLine(isbn.Trim());
                if (query.Read())
                {
                    
                    if (query.GetInt32(0) == 0)
                    {
                        //Console.WriteLine("true in");
                        return true;
                    }
                    else
                    {
                        //Console.WriteLine("false in");
                        return false;

                    }
                }

                else
                {
                    //Console.WriteLine("false Out");
                    return false;
                }
                connection.Close();
            }
        }

        //------------------ MageCustomer ---------------------------
        public static List<List<string>> GetCustomer(int cbxIndex, string textSearch)
        {
            using (var connection = new SqliteConnection("Data Source=BookStore.db")) //เชื่อม DB
            {
                List<List<string>> booklist = new List<List<string>>(); //เก็บ Book
                var searchCustomerCommand = connection.CreateCommand(); // สร้าง CommandText 

                if (cbxIndex == 1)
                {
                    //Console.WriteLine("เข้าแล้ว : "+searchTopic.Trim()+" "+textSearch.Trim());
                    searchCustomerCommand.CommandText = @"SELECT * FROM Customers WHERE Customer_id = @textSearch "; //ใส่ sql statement
                    searchCustomerCommand.Parameters.AddWithValue("@textSearch", textSearch); //ใส่ Parameters 1
                }
                else if (cbxIndex == 2)
                {
                    //Console.WriteLine("เข้าแล้ว : "+searchTopic.Trim()+" "+textSearch.Trim());
                    searchCustomerCommand.CommandText = @"SELECT * FROM Customers WHERE Customer_Name like '%' || @textSearch || '%' "; //ใส่ sql statement
                    searchCustomerCommand.Parameters.AddWithValue("@textSearch", textSearch); //ใส่ Parameters 1
                }
                else
                {
                    searchCustomerCommand.CommandText = @"SELECT * FROM Customers"; //ใส่ sql statement
                }

                //Console.WriteLine(searchBooksCommand.CommandText);
                connection.Open(); // เปิด DB
                SqliteDataReader query = searchCustomerCommand.ExecuteReader(); // Execute sql statement แล้วใส่ในตัวแปรชื่อ query
                int cloumSum = query.FieldCount; // แถว
                int rowCount = 0; // แถว
                //Console.WriteLine(cloumSum.ToString().Trim());
                //Console.WriteLine(rowCount.ToString().Trim());
                while (query.Read()) // loop row
                {
                    List<string> book = new List<string>(); // สร้าง list ด้านใน
                    //Console.WriteLine("RowCount : " + rowCount.ToString().Trim()); // Rownum
                    //Console.WriteLine("-----------------------------------------------");
                    for (int i = 0; i < cloumSum; i++)  //loop cloum
                    {
                        book.Add(query.GetString(i).Trim());  // add cloum
                        //Console.WriteLine("Cloum : " + i.ToString().Trim()); // Rownum
                    }
                    rowCount++; // count row
                    booklist.Add(book); // add ไปยัง Booklist
                }
                connection.Close(); // ปิด sqlite
                return booklist; // ส่งค่ากลับไป
            }
        }

        public static void InsertCustomer(string cusName, string address, string email)
        {
            using (var connection = new SqliteConnection("Data Source=BookStore.db")) //เชื่อม DB
            {
                var insertCustomerCommand = connection.CreateCommand(); // สร้าง CommandText 
                insertCustomerCommand.CommandText = @"INSERT INTO Customers (Customer_Name, Address, Email) VALUES (@cusName, @address, @email)"; //ใส่ sql statement

                insertCustomerCommand.Parameters.AddWithValue("@cusName", cusName); //ใส่ Parameters 1
                insertCustomerCommand.Parameters.AddWithValue("@address", address); //ใส่ Parameters 1
                insertCustomerCommand.Parameters.AddWithValue("@email", email); //ใส่ Parameters 1

                connection.Open(); // เปิด DB
                SqliteDataReader query = insertCustomerCommand.ExecuteReader(); // Execute sql statement แล้วใส่ในตัวแปรชื่อ query
                connection.Close();
            }
        }

        public static void DeleteCustomer(string idCus)
        {
            using (var connection = new SqliteConnection("Data Source=BookStore.db")) //เชื่อม DB
            {

                var deleteCustomerCommand = connection.CreateCommand(); // สร้าง CommandText 
                deleteCustomerCommand.CommandText = @"DELETE FROM Customers WHERE Customer_id = @idCus"; //ใส่ sql statement
                deleteCustomerCommand.Parameters.AddWithValue("@idCus", idCus);
                //Console.WriteLine(deleteCommand.CommandText.ToString().Trim());
                connection.Open(); // เปิด DB
                SqliteDataReader query = deleteCustomerCommand.ExecuteReader(); // Execute sql statement แล้วใส่ในตัวแปรชื่อ query
                connection.Close();
            }

        }

        public static void EditCustomer(string idCus, string name, string address, string email)
        {

            using (var connection = new SqliteConnection("Data Source=BookStore.db")) //เชื่อม DB
            {

                var editCustomerCommand = connection.CreateCommand(); // สร้าง CommandText 
                editCustomerCommand.CommandText = @"UPDATE Customers SET Customer_Name = @name, Address = @address, Email = @email WHERE Customer_id = @idCus "; //ใส่ sql statement

                editCustomerCommand.Parameters.AddWithValue("@name", name);
                editCustomerCommand.Parameters.AddWithValue("@address", address);
                editCustomerCommand.Parameters.AddWithValue("@email", email);
                editCustomerCommand.Parameters.AddWithValue("@idCus", idCus);

                //Console.WriteLine(editBookCommand.CommandText.ToString().Trim());
                connection.Open(); // เปิด DB
                SqliteDataReader query = editCustomerCommand.ExecuteReader(); // Execute sql statement แล้วใส่ในตัวแปรชื่อ query
                connection.Close();
            }

        }

        public static int GetEndID()
        {

            using (var connection = new SqliteConnection("Data Source=BookStore.db")) //เชื่อม DB
            {
                var getEndIdCommand = connection.CreateCommand(); // สร้าง CommandText 
                //getEndIdCommand.CommandText = @"SELECT Customer_id FROM Customers ORDER by Customer_id DESC LIMIT 1;)"; //ใส่ sql statement
                getEndIdCommand.CommandText = @"select seq from sqlite_sequence where name='Customers';"; //ใส่ sql statement
                connection.Open(); // เปิด DB
                SqliteDataReader query = getEndIdCommand.ExecuteReader(); // Execute sql statement แล้วใส่ในตัวแปรชื่อ query

                if (query.Read())
                {
                    return query.GetInt32(0) + 1;
                }

                else
                {
                    return -1;
                }
                connection.Close();
            }
            

        }

        //------------------ Cart ---------------------------

        public static bool InsertOrder(string customerId, List<List<string>> orderList)
        {
            int tranId = GetTransactionId();

            using (var connection = new SqliteConnection("Data Source=BookStore.db")) //เชื่อม DB
            {

                int row = orderList.Count; // get row

                //Console.WriteLine(row.ToString().Trim());

                for (int rowCount = 0; rowCount < row; rowCount++)
                {
                    var insertOrderCommand = connection.CreateCommand(); // สร้าง CommandText 

                    connection.Open();  // เปิด DB
                    insertOrderCommand.CommandText = @"INSERT INTO Transactions('Tran_ID','ISBN','Customer_Id','Quatity','Total_Price') VALUES (@tranId ,@ISBN ,@customerId ,@Quatity ,@Total_Price)"; //ใส่ sql statement

                    insertOrderCommand.Parameters.AddWithValue("@tranId", tranId);
                    insertOrderCommand.Parameters.AddWithValue("@ISBN", orderList[rowCount][0]);
                    insertOrderCommand.Parameters.AddWithValue("@customerId", int.Parse(customerId));
                    insertOrderCommand.Parameters.AddWithValue("@Quatity", int.Parse(orderList[rowCount][1]));
                    insertOrderCommand.Parameters.AddWithValue("@Total_Price", float.Parse(orderList[rowCount][2]));

                    SqliteDataReader query = insertOrderCommand.ExecuteReader(); // Execute sql statement

                    //Console.WriteLine(orderList[rowCount][0] + " " + orderList[rowCount][1] + " " + orderList[rowCount][2] + " " + orderList[rowCount][3]);
                    connection.Close();  // ปิด DB
                }
            }
            return true;
        }

        private static int GetTransactionId()
        {
            using (var connection = new SqliteConnection("Data Source=BookStore.db")) //เชื่อม DB
            {
                var getTransactionId = connection.CreateCommand(); // สร้าง CommandText 
                getTransactionId.CommandText = @"SELECT Tran_ID FROM Transactions ORDER by Tran_ID DESC LIMIT 1;"; //ใส่ sql statement
                connection.Open(); // เปิด DB
                SqliteDataReader query = getTransactionId.ExecuteReader(); // Execute sql statement แล้วใส่ในตัวแปรชื่อ query

                if (query.Read())
                {
                    return query.GetInt32(0) + 1;
                }

                else
                {
                    return 1;
                }
                connection.Close();
            }
        }

        //-------------TransactionOrder---------------------
        public static List<List<string>> GetTransactions(int searchCbx, string textSearch)
        {
            using (var connection = new SqliteConnection("Data Source=BookStore.db")) //เชื่อม DB
            {
                List<List<string>> transactionsList = new List<List<string>>(); //เก็บ Book
                var searchTransactionsCommand = connection.CreateCommand(); // สร้าง CommandText 

                if (searchCbx == 1) // Tran_ID
                {
                    searchTransactionsCommand.CommandText = @"SELECT Transactions.Tran_ID , Customers.Customer_Name , Transactions.ISBN , Books.Title , Transactions.Quatity , Transactions.Total_Price FROM Transactions as Transactions LEFT JOIN Customers as  Customers ON Transactions.Customer_id = Customers.Customer_id LEFT JOIN Books as  Books ON Transactions.ISBN = Books.ISBN
                    WHERE Transactions.Tran_ID = @textSearch"; //ใส่ sql statement


                    searchTransactionsCommand.Parameters.AddWithValue("@textSearch", textSearch);
                }
                else if (searchCbx == 2)  // cusname
                {
                    searchTransactionsCommand.CommandText = @"SELECT Transactions.Tran_ID , Customers.Customer_Name , Transactions.ISBN , Books.Title , Transactions.Quatity , Transactions.Total_Price FROM Transactions as Transactions LEFT JOIN Customers as  Customers ON Transactions.Customer_id = Customers.Customer_id LEFT JOIN Books as  Books ON Transactions.ISBN = Books.ISBN
                    WHERE Customers.Customer_Name like '%' || @textSearch || '%'"; //ใส่ sql statement
                    searchTransactionsCommand.Parameters.AddWithValue("@textSearch", textSearch);
                }
                else if (searchCbx == 3)
                {
                    searchTransactionsCommand.CommandText = @"SELECT Transactions.Tran_ID , Customers.Customer_Name , Transactions.ISBN , Books.Title , Transactions.Quatity , Transactions.Total_Price FROM Transactions as Transactions LEFT JOIN Customers as  Customers ON Transactions.Customer_id = Customers.Customer_id LEFT JOIN Books as  Books ON Transactions.ISBN = Books.ISBN
                    WHERE Transactions.ISBN  like '%' || @textSearch || '%'"; //ใส่ sql statement
                    searchTransactionsCommand.Parameters.AddWithValue("@textSearch", textSearch);
                }
                else
                {
                    searchTransactionsCommand.CommandText = @"SELECT Transactions.Tran_ID , Customers.Customer_Name , Transactions.ISBN , Books.Title , Transactions.Quatity , Transactions.Total_Price FROM Transactions as Transactions LEFT JOIN Customers as  Customers ON Transactions.Customer_id = Customers.Customer_id LEFT JOIN Books as  Books ON Transactions.ISBN = Books.ISBN"; //ใส่ sql statement
                }
                connection.Open(); // เปิด DB
                SqliteDataReader query = searchTransactionsCommand.ExecuteReader(); // Execute sql statement แล้วใส่ในตัวแปรชื่อ query
                int cloumSum = query.FieldCount; // แถว
                int rowCount = 0; // แถว
                while (query.Read()) // loop row
                {
                    List<string> transaction = new List<string>(); // สร้าง list ด้านใน
                    for (int i = 0; i < cloumSum; i++)  //loop cloum
                    {
                        transaction.Add(query.GetString(i).Trim());  // add cloum
                    }
                    rowCount++; // count row
                    transactionsList.Add(transaction); // add ไปยัง Booklist
                }
                connection.Close(); // ปิด sqlite
                return transactionsList; // ส่งค่ากลับไป

            }
        }

    }
}
