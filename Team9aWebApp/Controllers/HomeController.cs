using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Team9aWebApp.Models;
using Team9aWebApp.Services;

namespace Team9aWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private CustValidation cv;

        public HomeController(ILogger<HomeController> logger, CustValidation cv)
        {
            _logger = logger;
            this.cv = cv;
        }

        public IActionResult Index(string id)
        {
            //initiate session for not logged in users
            if (HttpContext.Session.GetString("tempCart") == null)
            {
                HttpContext.Session.SetString("tempCart", "");
            }
            //search view
            if (!String.IsNullOrEmpty(id))
            {
                string searchString = id.ToLower();
               
                List<Product> productsNew = new List<Product>();

                var products = cv.Listofproduct();
                var products2 = products.Where(p => p.ProductName.ToLower().Contains(searchString) || p.ProductDescription.ToLower().Contains(searchString));
                
                foreach (Product product in products2)
                    productsNew.Add(product);
                ViewData["ProductData"] = productsNew;
                ViewData["session"] = HttpContext.Session.GetString("username");
                string username1 = (string)ViewData["session"];
                
                Customer customer1 = cv.GetCust(username1);
                if (customer1 != null)
                {
                    ViewData["CartQty"] = (cv.GetQtyInSessionCart(username1)).ToString();
                    ViewData["customername"] = customer1.FirstName;
                    return View();
                }
                ViewData["CartQty"] = HttpContext.Session.GetString("cartQty");
                return View();

            }
            ViewData["session"] = HttpContext.Session.GetString("username");
            string username = (string)ViewData["session"];
            Customer customer = cv.GetCust(username);
            
            if (customer != null)
            {

                ViewData["customername"] = customer.FirstName;
                ViewData["ProductData"] = cv.Listofproduct();

                string tempCart = HttpContext.Session.GetString("tempCart");

                if (tempCart != "")
                {
                    string[] tempProductList = tempCart.Split(";");
                    List<Product> products = new List<Product>();
                    foreach (string tempProd in tempProductList)
                    {
                        Product product = cv.GetProd(tempProd);
                        products.Add(product);
                    }

                    foreach (Product p in products)
                    {
                        ShoppingCart cart1 = cv.GetCart(username, p.ProductName);
                        if (cart1 == null)
                        {
                            cv.CreateCart(username, p.ProductName);
                        }
                        else
                        {
                            cv.IncreaseProductQty(cart1);
                        }
                    }
                }
                HttpContext.Session.Remove("tempCart");
                ViewData["CartQty"] = (cv.GetQtyInSessionCart(username)).ToString();
                return View();
            }
            ViewData["ProductData"] = cv.Listofproduct();
            ViewData["CartQty"] = HttpContext.Session.GetString("cartQty");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AddToCart(string productName) //set AddToCart button name in view to productName; id which is the actual product name will bind here
        {
            //logged in
            if (HttpContext.Session.GetString("username") != null)
            {
                //search if there are existing cart with this product
                ShoppingCart cart = cv.GetCart(HttpContext.Session.GetString("username"), productName);

                //if no cart with product found, create cart
                if (cart == null)
                {
                    cv.CreateCart(HttpContext.Session.GetString("username"), productName);
                }
                //cart with product found, update product quantity
                else
                {
                    cv.IncreaseProductQty(cart);
                }
            }
            //not logged in
            else
            {
                //first click
                if (HttpContext.Session.GetString("tempCart") == "")
                {
                    HttpContext.Session.SetString("tempCart", productName);
                    HttpContext.Session.SetString("cartQty", "1");
                }
                //second click onwards
                else
                {
                    string productNames = HttpContext.Session.GetString("tempCart") + ";" + productName;
                    
                    int cartQty = Convert.ToInt32(HttpContext.Session.GetString("cartQty"));
                    cartQty++;
                    HttpContext.Session.SetString("cartQty", cartQty.ToString());

                    HttpContext.Session.SetString("tempCart", productNames);
                }       
            }
            return RedirectToAction("Index");
        }
    }
}
