using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Team9aWebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Team9aWebApp.Models;

namespace Team9aWebApp.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly ILogger<PurchaseController> _logger;
        private CustValidation cv;

        public PurchaseController(ILogger<PurchaseController> logger, CustValidation cv)
        {
            _logger = logger;
            this.cv = cv;
        }


        public IActionResult Index()
        {
            string username = HttpContext.Session.GetString("username");
            if (username == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                List<PurchasedProduct> purchasedProducts = cv.UserPurProd(username);

                

                List<PurchasedProduct> sortedlist = new List<PurchasedProduct>();

                foreach (PurchasedProduct pp in purchasedProducts)
                {
                    sortedlist.Add(pp);
                }

                List<string> prodNameList = new List<string>();
                List<string> actCodeList = new List<string>();
                List<DateTime> dateList = new List<DateTime>();
                List<string> imageList = new List<string>();
                List<string> descList = new List<string>();

                for (int i = 0; i < sortedlist.Count(); i++)
                {
                    if (i == 0)
                    {
                        prodNameList.Add(sortedlist[i].ProductName);
                        actCodeList.Add(sortedlist[i].ActivationCode);
                        dateList.Add(sortedlist[i].PurchaseDate.Date);
                        imageList.Add(sortedlist[i].Image);
                        descList.Add(sortedlist[i].Description);
                    }
                    else
                    {
                        int status = 0;
                        for (int j = 0; j < prodNameList.Count(); j++)
                        {
                            if (sortedlist[i].PurchaseDate.Date == dateList[j] && sortedlist[i].ProductName == prodNameList[j])
                            {
                                actCodeList[j] += "," + sortedlist[i].ActivationCode;
                                status = 1;
                                break;
                            }
                        }
                        if (status == 0)
                        {
                            prodNameList.Add(sortedlist[i].ProductName);
                            actCodeList.Add(sortedlist[i].ActivationCode);
                            dateList.Add(sortedlist[i].PurchaseDate.Date);
                            imageList.Add(sortedlist[i].Image);
                            descList.Add(sortedlist[i].Description);
                        }
                    }
                }

                ViewBag.prodName = prodNameList;
                ViewBag.actCode = actCodeList;
                ViewBag.date = dateList;
                ViewBag.image = imageList;
                ViewBag.desc = descList;
                ViewData["session"] = username;
                ViewData["CartQty"] = (cv.GetQtyInSessionCart(username)).ToString();

                return View();
            }
        }
    }
}
