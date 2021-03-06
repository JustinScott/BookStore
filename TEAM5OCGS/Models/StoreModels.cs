﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using System.Data;
using System.ComponentModel;
using System.Data.OleDb;

namespace TEAM5OCGS.Models
{

    public class Database
    {        
        public static string server_service_name = "oracle2";
        public static string server_user = "TEAM5OCGS";
        public static string server_pass = "TEAM5OCGS#";        
        
        private OleDbConnection oracleConn;
        public OleDbDataReader reader;
        
        public void Open()
        {
            oracleConn = new OleDbConnection();
            oracleConn.ConnectionString = "Provider=\'OraOLEDB.Oracle.1\'; User ID=" + server_user + ";Password=" + server_pass + ";Data Source=" + server_service_name + ";Extended Properties='';Persist Security Info=False";
            oracleConn.Open();
        }

        public OleDbDataReader Read(string strAccessSelect)
        {
            OleDbCommand cmd = new OleDbCommand(strAccessSelect, oracleConn);
            reader = cmd.ExecuteReader();
            return reader;
        }

        public void Close()
        {
            oracleConn.Close();
        }

        public static void Proc_Checkout(string sid, int cid, string street, string city, string state, int zip)
        {
            Database db = new Database();
            OleDbDataReader reader;
            
            db.Open();
            reader = db.Read("BEGIN checkout('" + sid + "'," + cid + ",'" + street + "','" + city + "','" + state + "'," + zip + "); END;");            
            db.Close();
        }
    }
        
    public class Employee
    {
        public int id { get; set; }
        public string l_name { get; set; }
        public string f_name { get; set; }
        public string login_name { get; set; }
        public string login_pass { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public decimal commission { get; set; }
        public string region { get; set; }
        public string email { get; set; }

        public static int ValidateUser(string userName, string password)
        {
            int empId = -1; //default error value
            Database db = new Database();
            OleDbDataReader reader;

            db.Open();
            reader = db.Read("select employee_id from employee where user_name = '" + userName + "' AND password = '" + password + "'");
            
            if (reader.Read())
                empId = Convert.ToInt32(reader.GetValue(0));
           
            db.Close();
            return empId;
        }

        public static string SelectRegionById(int empId)
        {
            string tmpString = ""; //default error value
            Database db = new Database();
            OleDbDataReader reader;

            db.Open();
            reader = db.Read("select region from employee where employee_id = '" + empId + "'");
            
            if (reader.Read())
                tmpString = reader.GetString(0).Trim();
            
            db.Close();
            return tmpString;
        }
    }

    public class Customer
    {
        public int id { get; set; }

        [DisplayName("Last Name")]
        public string l_name { get; set; }

        [DisplayName("First Name")]
        public string f_name { get; set; }

        [DisplayName("Address")]
        public string address { get; set; }

        [DisplayName("City")]
        public string city { get; set; }

        [DisplayName("State")]
        public string state { get; set; }

        [DisplayName("Zip Code")]
        public int zip { get; set; }

        [DisplayName("Region")]
        public string region { get; set; }

        [DisplayName("Email Address")]
        public string email { get; set; }

        [DisplayName("Login Name")]
        public string login_name { get; set; }

        [DisplayName("Login Password")]
        public string login_pass { get; set; }

        public static int CreateNewUser(string userName, string password, string email, string f_name, string l_name, string address, string city, string state, int zip, string region)
        {
            int custId = -1; //default error value
            Database db = new Database();
            OleDbDataReader reader;

            db.Open();
            reader = db.Read("select customer_id from customer where user_name ='" + userName + "'");
            
            if (reader.HasRows) //user_name already taken, return error
            {
                db.Close();
                custId = -2;
                return custId;
            }

            //insert new customer tuple
            reader = db.Read("insert into customer values (customer_seq,nextval,'" + l_name + "','" + f_name + "','" + address + "','" + city + "','" + state + "'," + zip + ",'" + region + "','" + userName + "','" + password + "','" + email + "')");

            //select it back out to figure out the customer_id, user_names are DISTINCT
            reader = db.Read("select customer_id from customer where user_name ='" + userName + "'");
                        
            if (reader.Read())
                custId = Convert.ToInt32(reader.GetValue(0));
            
            db.Close();
            return custId;
        }
        
        public static int ValidateUser(string userName, string password)
        {
            int custId = -1; //default error value
            Database db = new Database();
            OleDbDataReader reader;

            db.Open();
            reader = db.Read("select customer_id from customer where user_name = '" + userName + "' AND password = '" + password + "'");
            
            if (reader.Read())
                custId = Convert.ToInt32(reader.GetValue(0));
            
            db.Close();
            return custId;
        }
        
        public static void SelectAllByAttr(string id, string attribute, List<Customer> custList)
        {
            Database db = new Database();
            OleDbDataReader reader;

            db.Open();
            reader = db.Read("select * from customer where " + attribute + " = '" + id + "'");
            
            if (reader.Read())
            {
                Customer tmpCustomer = new Customer();
                
                tmpCustomer.id = Convert.ToInt32(reader.GetValue(0));
                tmpCustomer.l_name = reader.GetString(1).Trim();
                tmpCustomer.f_name = reader.GetString(2).Trim();
                tmpCustomer.address = reader.GetString(3).Trim();
                tmpCustomer.city = reader.GetString(4).Trim();
                tmpCustomer.state = reader.GetString(5).Trim();
                tmpCustomer.zip = Convert.ToInt32(reader.GetValue(6));
                tmpCustomer.region = reader.GetString(7).Trim();
                tmpCustomer.email = reader.GetString(8).Trim();
                tmpCustomer.login_name = reader.GetString(9).Trim();
                tmpCustomer.login_pass = reader.GetString(10).Trim();

                custList.Add(tmpCustomer);
            }

            db.Close();
        }

        public void SelectByAttr(string attribute, int id)
        {
            Database db = new Database();
            OleDbDataReader reader;

            db.Open();
            reader = db.Read("select * from customer where " + attribute + " = '" + id + "'");
            
            if (reader.Read())
            {
                id = Convert.ToInt32(reader.GetValue(0));
                l_name = reader.GetString(1).Trim();
                f_name = reader.GetString(2).Trim();
                address = reader.GetString(3).Trim();
                city = reader.GetString(4).Trim();
                state = reader.GetString(5).Trim();
                zip = Convert.ToInt32(reader.GetValue(6));
                region = reader.GetString(7).Trim();
                email = reader.GetString(10);
                //login_name = reader.GetString(9).Trim();
                //login_pass = reader.GetString(10).Trim();
            }

            db.Close();
        }
    }

    public class Book
    {
        [DisplayName("ISBN")]
        public string isbn { get; set; }

        [DisplayName("Title")]
        public string title { get; set; }

        [DisplayName("Quantity On Hand")]
        public int qoh { get; set; }

        [DisplayName("Retail Price")]
        public string retailPrice { get; set; }

        [DisplayName("Wholesale Price")]
        public string wholesalePrice { get; set; }

        [DisplayName("Category")]
        public string category { get; set; }

        [DisplayName("AuthorId")]
        public int authorId { get; set; }

        [DisplayName("PublisherId")]
        public int publisherId { get; set; }

        [DisplayName("Publication Date")]
        public DateTime publicationDate { get; set; }

        [DisplayName("Picture File Location")]
        public string filename { get; set; }

        [DisplayName("Product Description")]
        public string description { get; set; }

        [DisplayName("Author Last Name")]
        public string l_name { get; set; }

        [DisplayName("Author First Name")]
        public string f_name { get; set; }

        [DisplayName("Percent Profit")]
        public string percentProfit { get; set; }
        
        public void SelectById(string id)
        {
            Database db = new Database();
            OleDbDataReader reader;

            db.Open();
            reader = db.Read("select * from book_view where isbn = " + id);
            
            if (reader.Read())
            {
                isbn = reader.GetString(0).Trim();
                title = reader.GetString(1).Trim();
                l_name = reader.GetString(2).Trim();
                f_name = reader.GetString(3).Trim();
                qoh = Convert.ToInt32(reader.GetValue(4));
                retailPrice = String.Format("{0:F}", reader.GetValue(5));
                category = reader.GetString(6).Trim();
                filename = reader.GetString(7).Trim();
                description = reader.GetString(8).Trim();
                wholesalePrice = String.Format("{0:F}", reader.GetValue(9));
                percentProfit = String.Format("{0:F}", reader.GetValue(10));
            }

            db.Close();
        }

        public static void SelectAllByAttr(string id, string attribute, List<Book> bookList)
        {
            Database db = new Database();
            OleDbDataReader reader;

            db.Open();
            reader = db.Read("select * from book_view where " + attribute + " = '" + id + "'");
            
            while (reader.Read())
            {
                Book tmpBook = new Book();
                tmpBook.isbn = reader.GetString(0).Trim();
                tmpBook.title = reader.GetString(1).Trim();
                tmpBook.l_name = reader.GetString(2).Trim();
                tmpBook.f_name = reader.GetString(3).Trim();
                tmpBook.qoh = Convert.ToInt32(reader.GetValue(4));
                tmpBook.retailPrice = String.Format("{0:F}", reader.GetValue(5));
                tmpBook.category = reader.GetString(6).Trim();
                tmpBook.filename = reader.GetString(7).Trim();
                tmpBook.description = reader.GetString(8).Trim();

                bookList.Add(tmpBook);
            }

            db.Close();
        }

        //This function populates a list Book objects from the db that have the specified column name/value
        //the second set of name/value is optional and defaults to null
        public static void SelectAllByWildAttr(List<Book> bookList, string wildcard, string attribute, string wildcard2 = null, string attribute2 = null)
        {
            Database db = new Database();
            OleDbDataReader reader;
            
            db.Open();
            
            if(wildcard2 == null)
                reader = db.Read("select * from book_view where " + attribute + " like '%" + wildcard + "%'");
            else
                reader = db.Read("select * from book_view where " + attribute + " like '%" + wildcard + "%' AND " + attribute2 + " like '%" + wildcard2 + "%'");
                        
            while (reader.Read())
            {
                Book tmpBook = new Book();
                tmpBook.isbn = reader.GetString(0).Trim();
                tmpBook.title = reader.GetString(1).Trim();
                tmpBook.l_name = reader.GetString(2).Trim();
                tmpBook.f_name = reader.GetString(3).Trim();
                tmpBook.qoh = Convert.ToInt32(reader.GetValue(4));
                tmpBook.retailPrice = String.Format("{0:F}", reader.GetValue(5));
                tmpBook.category = reader.GetString(6).Trim();
                tmpBook.filename = reader.GetString(7).Trim();
                tmpBook.description = reader.GetString(8).Trim();
                tmpBook.wholesalePrice = String.Format("{0:F}", reader.GetValue(9));
                tmpBook.percentProfit = String.Format("{0:F}", reader.GetValue(10));

                bookList.Add(tmpBook);
            }

            db.Close();
        }

        public static void SelectDistinctCategories(List<string> categoryList)
        {
            Database db = new Database();
            OleDbDataReader reader;

            db.Open();
            reader = db.Read("select distinct category from book_view");
            
            while (reader.Read())
                categoryList.Add(reader.GetString(0).Trim());
            
            db.Close();
        }

        public static bool UpdateQoh(string id, int count)
        {
            int rows;
            Database db = new Database();
            OleDbDataReader reader;

            db.Open();
            reader = db.Read("update book set q_o_h = " + count + " where isbn = '" + id + "'");
            rows = reader.RecordsAffected;
            db.Close();

            if (rows > 0)
                return true;

            return false;
        }
    }

    public class ShoppingCart
    {
        public string sessionId { get; set; }
        public string isbn { get; set; }
        public int quantity { get; set; }
        public Book book { get; set; }

        public static void SelectAllById(string id, List<ShoppingCart> idList)
        {
            Database db = new Database();
            OleDbDataReader reader;

            db.Open();
            reader = db.Read("select * from shopping_cart where session_id = '" + id + "'");
            
            while (reader.Read())
            {
                ShoppingCart tmpCart = new ShoppingCart();
                List<Book> tmpBookList = new List<Book>();

                tmpCart.sessionId = reader.GetString(0).Trim();
                tmpCart.isbn = reader.GetString(1).Trim();
                tmpCart.quantity = Convert.ToInt32(reader.GetValue(2));

                Book.SelectAllByAttr(tmpCart.isbn, "isbn", tmpBookList);
                tmpCart.book = tmpBookList.ElementAt(0);

                idList.Add(tmpCart);
            }

            db.Close();
        }

        public static void Insert(string session_id, string book_id)
        {
            int quantity = 1; //default value if book isn't already in cart
            Database db = new Database();
            OleDbDataReader reader;

            db.Open();
            reader = db.Read("select quantity from shopping_cart where session_id = '" + session_id + "' AND isbn = '" + book_id + "'");
                        
            if (reader.Read()) //book|session already in cart
            {
                //get count, add one to it
                quantity = Convert.ToInt32(reader.GetValue(0)) + 1;
                reader = db.Read("update shopping_cart set quantity = " + quantity + " where session_id = '" + session_id + "' AND isbn = '" + book_id + "'");                
            }
            else
                reader = db.Read("insert into shopping_cart values ('" + session_id + "','" + book_id + "','" + quantity + "')");                
            
            db.Close();
        }

        public static void DeleteSession(string session_id)
        {
            Database db = new Database();
            OleDbDataReader reader;

            db.Open();
            reader = db.Read("delete from shopping_cart where session_id = '" + session_id + "'");
            db.Close();
        }

        public static int GetSessionCount(string session_id)
        {
            int count = 0;
            Database db = new Database();
            OleDbDataReader reader;

            db.Open();
            reader = db.Read("select sum(quantity) from shopping_cart where session_id = '" + session_id + "'");
            if (reader.Read())
            {
                if (reader.GetValue(0) is DBNull)
                    count = 0;
                else
                    count = Convert.ToInt32(reader.GetValue(0));
            }

            db.Close();
            return count;
        }

        //Used by the checkout procedure. Updates the quantity value of the book. If count is zero it deletes
        //the book from the shopping cart.
        public static void UpdateCount(string session_id, string isbn, int count)
        {
            Database db = new Database();
            OleDbDataReader reader;

            db.Open();
            if (count == 0)
                reader = db.Read("delete from shopping_cart where session_id = '" + session_id + "' AND isbn = '" + isbn + "'");
            else
                reader = db.Read("update shopping_cart set quantity = '" + count + "' where session_id = '" + session_id + "' AND isbn = '" + isbn + "'");
        }
    }

    public class Commission
    {
        public string rate { get; set; }
        public string region { get; set; }
        public string total { get; set; }
        public string orderCount { get; set; }
        
        public string GetCommission(string x_region, decimal x_rate)
        {
            rate = Convert.ToString(x_rate);
            region = x_region;

            Database db = new Database();
            OleDbDataReader reader;

            db.Open();
            reader = db.Read("select calc_commission('" + region + "'," + rate + ") from dual");
            
            if (reader.Read())
                total = String.Format("{0:F}", reader.GetValue(0));
            
            db.Close();
            return total;
        }
    }

    public class Testimonial
    {
        public bool InsertTestimonial(int customer_id, string name, string entry)
        {
            Database db = new Database();
            OleDbDataReader reader;

            db.Open();
            reader = db.Read("insert into testimonials values (tests_seq.nextval, '" + customer_id + "' , '" + name + "' , '" + entry + "')");
            db.Close();            
            return (true);
        }
    }
}