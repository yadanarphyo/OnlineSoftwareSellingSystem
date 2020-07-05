using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Team9aWebApp.Models;

namespace Team9aWebApp.DB
{
    public class WebAppContext : DbContext
    {
        protected IConfiguration configuration;
        public WebAppContext(DbContextOptions<WebAppContext> options)
            : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PurchasedProduct> PurchasedProducts { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    }
}
