using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using TEAM5OCGS.Models;

namespace TEAM5OCGS.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {   
        List<string> categoryList;
        List<Book> bookList;

        //This method is called when the user first loads the page and when
        //they select a catgory, it defaults to the computer category
        public ActionResult Index(string category = "COMPUTER")
        {
            int cartCount = 0;
            categoryList = new List<string>();
            bookList = new List<Book>();

            //Get all catagories from db and store them in a view variable
            Book.SelectDistinctCategories(categoryList);
            ViewData["categories"] = categoryList;

            //Put the name of the active category in a view variable
            ViewData["listTitle"] = "Product highlights from: " + category;

            //Get a list of all the books by category from the db
            Book.SelectAllByAttr(category, "category", bookList);

            //Get the number of books in the shopping cart table and store it in a 
            //view accessiable variable
            cartCount = ShoppingCart.GetSessionCount(Session.SessionID);
            Session["cart_count"] = cartCount;
            
            //Return the list of books to the view
            return View(bookList);
        }

        //This method is called when the user enters something in the search box
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            bookList = new List<Book>();
            categoryList = new List<string>();

            //Read the data submitted in the form
            string searchTerm = form["term"];
            string category = form["category"];
            
            //Get all catagories from db and store them in a view variable
            Book.SelectDistinctCategories(categoryList);
            ViewData["categories"] = categoryList;

            //Make the searchterm a view accessible variable
            ViewData["listTitle"] = "'" + searchTerm + "' Search Results.";

            //All data is in uppercase, so make sure the search term is uppercase
            searchTerm = searchTerm.ToUpper();

            //setting category to null will force the following select statements to omit
            //category = "value" from the sql statements
            if (category == "ALL")
                category = null;

            //These select methods test to see if the search term gets any results
            //from the following four column names
            Book.SelectAllByWildAttr(bookList, searchTerm, "title", category, "category");
            if (bookList.Count >= 1)
                return View(bookList);

            Book.SelectAllByWildAttr(bookList, searchTerm, "l_name", category, "category");
            if (bookList.Count >= 1)
                return View(bookList);

            Book.SelectAllByWildAttr(bookList, searchTerm, "f_name", category, "category");
            if (bookList.Count >= 1)
                return View(bookList);

            Book.SelectAllByWildAttr(bookList, searchTerm, "isbn", category, "category");
            if (bookList.Count >= 1)
                return View(bookList);

            //if all the searches fail, return an empty list of books
            return View(bookList);
        }

        //This method is called when the user enters something in the search box on the employee statistics page
        [HttpPost]
        public ActionResult Search(FormCollection form)
        {
            bookList = new List<Book>();
            categoryList = new List<string>();

            //Read the data submitted in the form
            string searchTerm = form["term"];
            string category = form["category"];

            //Get all catagories from db and store them in a view variable
            Book.SelectDistinctCategories(categoryList);
            ViewData["categories"] = categoryList;

            //Make the searchterm a view accessible variable
            ViewData["listTitle"] = "'" + searchTerm + "' Search Results.";

            //All data is in uppercase, so make sure the search term is uppercase
            searchTerm = searchTerm.ToUpper();

            //setting category to null will force the following select statements to omit
            //category = "value" from the sql statements
            if (category == "ALL")
                category = null;

            //These select methods test to see if the search term gets any results
            //from the following four column names
            Book.SelectAllByWildAttr(bookList, searchTerm, "title", category, "category");
            if (bookList.Count >= 1)
                return View(bookList);

            Book.SelectAllByWildAttr(bookList, searchTerm, "l_name", category, "category");
            if (bookList.Count >= 1)
                return View(bookList);

            Book.SelectAllByWildAttr(bookList, searchTerm, "f_name", category, "category");
            if (bookList.Count >= 1)
                return View(bookList);

            Book.SelectAllByAttr(searchTerm, "isbn", bookList);
            if (bookList.Count >= 1)
                return View(bookList);

            //if all the searches fail, return an empty list of books
            return View(bookList);
        }

        //Ajax method to add a book to the shopping cart table
        [HttpGet]
        public JsonResult AddBook(string id)
        {
            //Increment the shopping cart count by 1
            int count = (int)Session["cart_count"];
            count++;
            Session["cart_count"] = count;

            //Insert book into shopping cart
            ShoppingCart.Insert(Session.SessionID, id);

            //Return new shopping cart count, and the isbn of the book that was added
            return Json(new { ccount = count, isbn = id }, JsonRequestBehavior.AllowGet);
        }

        //Ajax method to find a book by isbn
        [HttpGet]
        public JsonResult FindBook(string id)
        {
            //Create new book object and populate it, if a book can be found with a matching isbn
            Book book = new Book();
            book.SelectById(id);

            //Return the book, all vars will be null if the isbn wasn't found
            return Json(book, JsonRequestBehavior.AllowGet);
        }

        //Ajax method to update the quantity on hand value of the book with the specified id/isbn
        [HttpGet]
        public JsonResult UpdateBook(string id, int count)
        {
            Book.UpdateQoh(id, count);
            
            //Return bogue information, the jQuery script doesn't read this data
            return Json("Finished!", JsonRequestBehavior.AllowGet);
        }

        //Called when the user click the about tab
        public ActionResult About()
        {
            categoryList = new List<string>();

            //Get all catagories from db and store them in a view variable
            Book.SelectDistinctCategories(categoryList);
            ViewData["categories"] = categoryList;

            return View();
        }

        //Called when the user accesses the employee page
        public ActionResult Employee()
        {   
            return View();
        }

        public ActionResult OrderBooks()
        {
            //The view needs access to an object of type book to determine the types of the 
            //properties in the book object, the pages uses the Ajax book methods to 
            //populate the page
            Book book = null;

            return View(book);
        }

        public ActionResult SalesReport()
        {
            categoryList = new List<string>();
            bookList = new List<Book>();

            //Get all catagories from db and store them in a view variable
            Book.SelectDistinctCategories(categoryList);
            ViewData["categories"] = categoryList;

            return View(bookList);
        }

        [HttpPost]
        public ActionResult SalesReport(FormCollection form)
        {
            categoryList = new List<string>();
            bookList = new List<Book>();

            //Read the data submitted in the form
            string searchTerm = form["term"];
            string category = form["category"];

            //Get all catagories from db and store them in a view variable
            Book.SelectDistinctCategories(categoryList);
            ViewData["categories"] = categoryList;

            //setting category to "_" will force the following select statements to select
            //every category
            if (category == "ALL")
                category = "_";

            Book.SelectAllByWildAttr(bookList, category, "category");
            
            return View(bookList);
        }

        public ActionResult Commission()
        {
            ViewData["status"] = "";
            return View();
        }

        [HttpPost]
        public ActionResult Commission(FormCollection form)
        {
            int empId;
            string region;
            Commission tmpCom = new Commission();
            decimal rate = Convert.ToDecimal(1.99);

            if(String.IsNullOrEmpty(form["empId"]))
            {
                ViewData["status"] = "Please login with a valid employee account to use this feature.";
                return View(tmpCom);
            }

            ViewData["status"] = "Commission report for the month of: " + DateTime.Now.ToString("MMMM");
            empId = Convert.ToInt32(form["empId"]);

            region = Models.Employee.SelectRegionById(empId);
            tmpCom.GetCommission(region, rate);

            return View(tmpCom);
        }
       
        //Called when a customer clicks the account tab
        public ActionResult Customer()
        {
            categoryList = new List<string>();
            Customer tmpCustomer = new Customer();

            //Get all catagories from db and store them in a view variable
            Book.SelectDistinctCategories(categoryList);
            ViewData["categories"] = categoryList;

            //Check to see if a customer is logged in
            if (Session["custId"] != null)
            {
                //Gets a customer row from the db with the specified customer id
                tmpCustomer.SelectByAttr("customer_id", (int)Session["custId"]);
                ViewData["status"] = "Customer profile for: " + tmpCustomer.f_name;
            }
            else
            {
                ViewData["status"] = "Please login to view account profile.";
            }

            return View(tmpCustomer);
        }

        //Called when the user click the about/contact page
        public ActionResult Contact()
        {
            categoryList = new List<string>();

            //Get all catagories from db and store them in a view variable
            Book.SelectDistinctCategories(categoryList);
            ViewData["categories"] = categoryList;

            return View();
        }

        //Called when the user click the about/press page
        public ActionResult Press()
        {
            categoryList = new List<string>();

            //Get all catagories from db and store them in a view variable
            Book.SelectDistinctCategories(categoryList);
            ViewData["categories"] = categoryList;

            return View();
        }

        //Called when the user click the about/testimonials page
        public ActionResult Testimonials(FormCollection form)
        {
            ViewData["thankyou"] = ""; //initialize thank you response

            categoryList = new List<string>();

            //Get all catagories from db and store them in a view variable
            Book.SelectDistinctCategories(categoryList);
            ViewData["categories"] = categoryList;

            bool fchk = false;

            if ((form["name0"] != null) && (form["issue0"] != null))
            {
                fchk = true;
            }

            bool trial = false;
            string name = form["name0"];
            string entry = form["issue0"];

            Customer tmpCustomer = new Customer();

            //Check to see if a customer is logged in and try to insert testimonial
            if ((Session["custId"] != null) && (fchk == true))
            {
                Testimonial report = new Testimonial();
                trial = report.InsertTestimonial((int)Session["custId"], name, entry);
            }

            if (trial == true)
            {
                ViewData["thankyou"] = "Thanks for submitting! We will review your testimonial.";
                return View(); // still need to create thank you view
            }
            else
            {
                return View();
            }
        }

        List<ShoppingCart> cartList;

        public ActionResult CheckOut()
        {
            categoryList = new List<string>();
            cartList = new List<ShoppingCart>();

            Book.SelectDistinctCategories(categoryList);
            ViewData["categories"] = categoryList;

            ShoppingCart.SelectAllById(Session.SessionID, cartList);

            return View(cartList);
        }

        //Called when the user click the delete cart button on the "check out now" page
        public ActionResult DeleteCart()
        {
            //Delete all rows in the shopping cart that have the specified session id
            ShoppingCart.DeleteSession(Session.SessionID);

            //Reload the homepage
            return RedirectToAction("Index");
        }

        //Called when the user click update quantity on the "check out now" page
        public ActionResult UpdateCart(string id, int count)
        {
            ShoppingCart.UpdateCount(Session.SessionID, id, count);

            //Reload checkout page
            return RedirectToAction("CheckOut");
        }

        public ActionResult CompleteCheckOut()
        {
            int custId = (int)Session["custId"];
            Customer tmpCustomer = new Customer();

            tmpCustomer.SelectByAttr("customer_id", custId);
            return View(tmpCustomer);
        }

        public ActionResult CompleteCheckOut2(FormCollection form)
        {
            int custId = (int)Session["custId"];
            string address = form["address"];
            string city = form["city"];
            string state = form["state"];
            int zip = Convert.ToInt32(form["zip"]);

            ViewData["name"] = form["f_name"];

            Database.Proc_Checkout(Session.SessionID, custId, address, city, state, zip);
            return View();
        }

        public ActionResult ChatRequest(FormCollection form)
        {
            ViewData["Name"] = form["Name"];
            ViewData["Description"] = form["Description"];
            return View();
        }
    
        //The following actions are only used to debug the application
        public string SessionId()
        {
            return Session.SessionID;
        }

        public string CustId()
        {
            return Convert.ToString(Session["custId"]);
        }

        public string EmpId()
        {
            return Convert.ToString(Session["empId"]);
        }

        public char[] getFeed()
        {
            char[] buffer = new char[2048];
            StreamReader reader = new StreamReader("D:\recent.txt");
            reader.Read(buffer, 0, 2048);
            reader.Close();
            return buffer;
        }
    }
}
