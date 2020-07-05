using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Team9aWebApp.Models;
using Team9aWebApp.Services;


namespace Team9aWebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            //username found in session, redirect to Home
            if (HttpContext.Session.GetString("username") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewData["errmsg"] = TempData["errmsg"];
            return View();
        }
        public IActionResult Login([FromServices] CustValidation cv, string username, string hashPassword)
        {
                       
            //no username stored in session state, request login and validation
            if (string.IsNullOrEmpty(username))
                return View("Index");
            Customer customer = cv.GetCust(username);
            if (customer == null)
            {
                TempData["errmsg"] = "Username not found.";
                return RedirectToAction("Index");
            }
            bool pwdcheck = cv.PasswordCheck(customer, hashPassword);
            if (pwdcheck == false)
            {
                TempData["errmsg"] = "Incorrect password.";
                return RedirectToAction("Index");
            }
            //customer validated, store username in session, redirect to Home
            
            HttpContext.Session.SetString("username", username);
            HttpContext.Session.SetString("cartQty", "0");
            
            return RedirectToAction("Index", "Home");
            
        }
    }
}
