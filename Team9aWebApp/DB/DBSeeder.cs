using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Team9aWebApp.Models;

namespace Team9aWebApp.DB
{
    public class DBSeeder
    {
        public DBSeeder(WebAppContext dbcontext)
        {
            //Seed customers
            Customer cust1 = new Customer();
            cust1.Id = "1";
            cust1.Username = "adam";
            //cust1.Password = "adam";
            cust1.Password = Utils.Crypto.Sha256("adam"); //saving hash password
            cust1.FirstName = "Adam";
            cust1.LastName = "Chong";
            dbcontext.Add(cust1);

            Customer cust2 = new Customer();
            cust2.Id = "2";
            cust2.Username = "bella";
            cust2.Password = Utils.Crypto.Sha256("bella"); 
            cust2.FirstName = "Bella";
            cust2.LastName = "Ling";
            dbcontext.Add(cust2);

            //Seed products
            Product prod1 = new Product();
            prod1.Id = Guid.NewGuid().ToString();
            prod1.ProductName = "Office Home and Student 2019";
            prod1.ProductDescription = "Microsoft Office, or simply Office, is a family of client software, server software, and services developed by Microsoft.";
            prod1.Image = "officehomestudent2019.jpg";
            prod1.UnitPrice = 229d;
            dbcontext.Add(prod1);

            Product prod2 = new Product();
            prod2.Id = Guid.NewGuid().ToString();
            prod2.ProductName = "Adobe CS6 Design and Web Design";
            prod2.ProductDescription = "Take your designs further with Adobe® Creative Suite® 6 Design & Web Premium software.";
            prod2.Image = "adobecs6.jpg";
            prod2.UnitPrice = 399d;
            dbcontext.Add(prod2);

            Product prod3 = new Product();
            prod3.Id = Guid.NewGuid().ToString();
            prod3.ProductName = "Adobe PhotoShop";
            prod3.ProductDescription = "Adobe Photoshop is a raster graphics editor developed and published by Adobe Inc. for Windows and macOS.";
            prod3.Image = "adobephotoshop.jpg";
            prod3.UnitPrice = 129d;
            dbcontext.Add(prod3);

            Product prod4 = new Product();
            prod4.Id = Guid.NewGuid().ToString();
            prod4.ProductName = "MATLAB Simulink";
            prod4.ProductDescription = "Simulink is a MATLAB-based graphical programming environment for modeling, simulating and analyzing multidomain dynamical systems.";
            prod4.Image = "matlab.jpg";
            prod4.UnitPrice = 119d;
            dbcontext.Add(prod4);

            Product prod5 = new Product();
            prod5.Id = Guid.NewGuid().ToString();
            prod5.ProductName = "Autodesk AUTOCAD";
            prod5.ProductDescription = "AutoCAD is a commercial computer-aided design and drafting software application.";
            prod5.Image = "autocad.jpg";
            prod5.UnitPrice = 279d;
            dbcontext.Add(prod5);

            Product prod6 = new Product();
            prod6.Id = Guid.NewGuid().ToString();
            prod6.ProductName = "Aspen HYSYS";
            prod6.ProductDescription = "Aspen HYSYS is a chemical process simulator used to mathematically model chemical processes, from unit operations to full chemical plants and refineries.";
            prod6.Image = "aspenhysys.jpg";
            prod6.UnitPrice = 139d;
            dbcontext.Add(prod6);

            Product prod7 = new Product();
            prod7.Id = Guid.NewGuid().ToString();
            prod7.ProductName = "Microsoft Visual Studio";
            prod7.ProductDescription = "Microsoft Visual Studio is an integrated development environment from Microsoft. It is used to develop computer programs, as well as websites, web apps, web services and mobile apps.";
            prod7.Image = "microsoftvisualstudio.jpg";
            prod7.UnitPrice = 299d;
            dbcontext.Add(prod7);

            Product prod8 = new Product();
            prod8.Id = Guid.NewGuid().ToString();
            prod8.ProductName = "Norton AntiVirus";
            prod8.ProductDescription = "Norton AntiVirus is an anti-virus or anti-malware software product, developed and distributed by Symantec Corporation since 1991 as part of its Norton family of computer security products.";
            prod8.Image = "norton.png";
            prod8.UnitPrice = 69d;
            dbcontext.Add(prod8);

            Product prod9 = new Product();
            prod9.Id = Guid.NewGuid().ToString();
            prod9.ProductName = "Microsoft Windows 10 Pro Edition";
            prod9.ProductDescription = "Windows 10 is a series of operating systems produced by Microsoft and released as part of its Windows NT family of operating systems. It is the successor to Windows 8.1.";
            prod9.Image = "microsoftwindows10.jpg";
            prod9.UnitPrice = 159d;
            dbcontext.Add(prod9);

            dbcontext.SaveChanges();
        }
    }
}
