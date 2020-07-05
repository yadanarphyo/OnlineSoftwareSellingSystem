using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Team9aWebApp.Models;
using Team9aWebApp.Services;

namespace Team9aWebApp.Controllers
{
    public class CartController : Controller
    {
        private CustValidation cv;

        public CartController(CustValidation cv)
        {
            this.cv = cv;
        }
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult AssembleCart()
        {
            //logged in
            if (HttpContext.Session.GetString("username") != null)
            {
                List<Product> productsInCart = cv.GetProductsInCart(HttpContext.Session.GetString("username"));

                //empty cart
                if (productsInCart.Count == 0)
                    ViewData["Message"] = "Your cart is empty.";
                //something in cart
                else
                {
                    List<Product> distinctProductsInCart = productsInCart.GroupBy(x => x.ProductName).Select(g => g.First()).ToList<Product>();
                    var iter = from product in productsInCart
                               group product by product.ProductName
                                                    into productGroup
                               select productGroup;

                    List<int> quantity = new List<int>();
                    foreach (var grp in iter)
                        quantity.Add(grp.Count());

                    double cartTotalPrice = 0;
                    for (int i = 0; i < quantity.Count(); i++)
                    {
                        cartTotalPrice += distinctProductsInCart[i].UnitPrice * quantity[i];
                    }
                    ViewData["CartTotalPrice"] = cartTotalPrice;
                    ViewData["ProductData"] = distinctProductsInCart;
                    ViewData["ProductQty"] = quantity;
                    ViewData["username"] = HttpContext.Session.GetString("username");
                }
                return View("index");
            }

            //not logged in
            else
            {
                //empty cart
                string allItems = HttpContext.Session.GetString("tempCart");
                if (String.IsNullOrEmpty(allItems))
                {
                    ViewData["Message"] = "Your cart is empty.";
                }
                //something in cart
                else
                {
                    string[] items = allItems.Split(";");
                    List<Product> cartItems = new List<Product>();
                    foreach (string item in items)
                    {
                        Product product = cv.GetProd(item);
                        cartItems.Add(product);
                    }
                    List<Product> distinctProductsInCart = cartItems.GroupBy(x => x.ProductName).Select(g => g.First()).ToList<Product>();
                    var iter = from product in cartItems
                               group product by product.ProductName
                                                    into productGroup
                               select productGroup;
                    List<int> quantity = new List<int>();
                    foreach (var grp in iter)
                        quantity.Add(grp.Count());
                    double cartTotalPrice = 0;
                    for (int i = 0; i < quantity.Count(); i++)
                    {
                        cartTotalPrice += distinctProductsInCart[i].UnitPrice * quantity[i];
                    }
                    ViewData["CartTotalPrice"] = cartTotalPrice;
                    ViewData["ProductData"] = distinctProductsInCart;
                    ViewData["ProductQty"] = quantity;
                }

                return View("index");
            }
        }

        public IActionResult AddCartToPurchasedProduct()
        {
            string username = HttpContext.Session.GetString("username");
            if (username == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                List<ShoppingCart> cartList = cv.GetCartProducts(username);
                cv.deleteCartProd(cartList);
                return RedirectToAction("Index", "Purchase");
            }
        }

        public IActionResult UpdateQty(string cmd, string productName)
        {
            string username = HttpContext.Session.GetString("username");
            string prodId = cv.getProdId(productName);
            //for logged in users
            if (username != null)
            {
                List<ShoppingCart> carts = cv.GetCartProducts(HttpContext.Session.GetString("username"));
                if (carts != null)
                {
                    
                    ShoppingCart cart = carts.Where(x => x.ProductId == prodId).FirstOrDefault();
                    if (cmd == "minusBtn")
                    {
                        int oldQty = cart.ProductQty;
                        int newQty = oldQty - 1;
                        cv.UpdateProductQty(cart, newQty);
                    }
                    if (cmd == "plusBtn")
                    {
                        int oldQty = cart.ProductQty;
                        int newQty = oldQty + 1;
                        cv.UpdateProductQty(cart, newQty);
                    }
                    if (cmd == "removeBtn")
                    {
                        cv.RemoveCart(cart);
                    }
                }
                else
                {
                    ViewData["Message"] = "Your cart is empty.";
                }
                
            }
            //for non logged in users
            else
            {
                string tempCart = HttpContext.Session.GetString("tempCart");
                if (tempCart != null)
                {
                    string[] tempCartList = tempCart.Split(";");

                    //for minus button
                    if (cmd == "minusBtn")
                    {
                        string newTempCart = "";
                        int newQty = 0;
                        for (int i = 0; i < tempCartList.Count(); i++)
                        {
                            if (tempCartList[i] == productName)
                            {
                                tempCartList[i] = "";
                                break;
                            }
                        }
                        for (int i = 0; i < tempCartList.Count(); i++)
                        {
                            if (tempCartList[i] != "")
                            {
                                if (newTempCart == "")
                                {
                                    newTempCart = tempCartList[i];
                                }
                                else
                                {
                                    newTempCart += ";" + tempCartList[i];
                                }
                            }
                        }
                        string[] newTempCartArr = newTempCart.Split(";");
                        newQty = newTempCartArr.Count();

                        //check for zero qty
                        if (newTempCart != "")
                        {
                            string[] newTempCartArr1 = newTempCart.Split(";");
                            newQty = newTempCartArr1.Count();

                            HttpContext.Session.SetString("cartQty", newQty.ToString());
                            HttpContext.Session.SetString("tempCart", newTempCart);
                        }
                        else
                        {
                            HttpContext.Session.SetString("cartQty", "0");
                            HttpContext.Session.SetString("tempCart", newTempCart);
                        }
                    }

                    //for plus button
                    if (cmd == "plusBtn")
                    {
                        int newQty = 0;
                        string newTempCart = tempCart + ";" + productName;
                        string[] newTempCartArr = newTempCart.Split(";");
                        newQty = newTempCartArr.Count();

                        HttpContext.Session.SetString("cartQty", newQty.ToString());
                        HttpContext.Session.SetString("tempCart", newTempCart);
                    }

                    //for remove button
                    if (cmd == "removeBtn")
                    {
                        int newQty = 0;
                        string newTempCart = "";
                        for (int i = 0; i < tempCartList.Count(); i++)
                        {
                            if (tempCartList[i] == productName)
                            {
                                tempCartList[i] = "";
                            }
                        }

                        for (int i = 0; i < tempCartList.Count(); i++)
                        {
                            if (tempCartList[i] != "")
                            {
                                if (newTempCart == "")
                                {
                                    newTempCart = tempCartList[i];
                                }
                                else
                                {
                                    newTempCart += ";" + tempCartList[i];
                                }
                            }
                        }
                        //check for zero qty
                        if (newTempCart != "")
                        {
                            string[] newTempCartArr = newTempCart.Split(";");
                            newQty = newTempCartArr.Count();

                            HttpContext.Session.SetString("cartQty", newQty.ToString());
                            HttpContext.Session.SetString("tempCart", newTempCart);
                        }
                        else
                        {
                            HttpContext.Session.SetString("cartQty", "0");
                            HttpContext.Session.SetString("tempCart", newTempCart);
                        }
                    }
                }
                else
                {
                    ViewData["Message"] = "Your cart is empty.";
                }
            }

            return RedirectToAction("AssembleCart");
        }
    }
}