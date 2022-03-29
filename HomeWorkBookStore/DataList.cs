using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkBookStore
{
    public class DataList
    {
    }
    public class BookList
    {
        private string isbn = "";
        private string title = "";
        private string description = "";
        private string price = "";

        public string Isbn { get => isbn; set => isbn = value; }
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public string Price { get => price; set => price = value; }

        public BookList(string isbn, string title, string description, string price)
        {
            Isbn = isbn;
            Title = title;
            Description = description;
            Price = price;

        }
    }
    public class CustomerList
    {
        private string idCustomer = "";
        private string customerNaem = "";
        private string address = "";
        private string email = "";

        public CustomerList(string idCustomer, string customerNaeme, string address, string email)
        {
            IdCustomer = idCustomer;
            CustomerNaeme = customerNaeme;
            Address = address;
            Email = email;

        }

        public string IdCustomer { get => idCustomer; set => idCustomer = value; }
        public string CustomerNaeme { get => customerNaem; set => customerNaem = value; }
        public string Address { get => address; set => address = value; }
        public string Email { get => email; set => email = value; }

    }
    public class CartList
    {
        private string isbn = "";
        private string title = "";
        private string quatity = "";
        private string price = "";

        public CartList(string isbn, string title, string quatity, string price)
        {
            Isbn = isbn;
            Title = title;
            Quatity = quatity;
            Price = price;

        }

        public string Isbn { get => isbn; set => isbn = value; }
        public string Title { get => title; set => title = value; }
        public string Quatity { get => quatity; set => quatity = value; }
        public string Price { get => price; set => price = value; }
    }
    public class TransactionsList
    {
        private string tranID = "";
        private string customerName = "";
        private string isbn = "";
        private string title = "";
        private string quatity = "";
        private string totalPrice = "";

        public TransactionsList(string tranID, string customerName, string isbn, string title, string quatity, string totalPrice)
        {
            TranID = tranID;
            CustomerName = customerName;
            Isbn = isbn;
            Title = title;
            Quatity = quatity;
            TotalPrice = totalPrice;

        }

        public string TranID { get => tranID; set => tranID = value; }
        public string CustomerName { get => customerName; set => customerName = value; }
        public string Isbn { get => isbn; set => isbn = value; }
        public string Title { get => title; set => title = value; }
        public string Quatity { get => quatity; set => quatity = value; }
        public string TotalPrice { get => totalPrice; set => totalPrice = value; }
    }

}
