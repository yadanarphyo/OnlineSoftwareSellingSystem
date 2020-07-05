using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;
using Team9aWebApp.DB;
using Team9aWebApp.Models;

namespace Team9aWebApp.Services
{
    public class CustValidation
    {
        protected WebAppContext dbcontext;

        public CustValidation(WebAppContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public Customer GetCust(string username)
        {
            Customer customer = dbcontext.Customers.Where(x => x.Username == username).FirstOrDefault();

            return customer;
        }
        public bool PasswordCheck(Customer customer, string hashPassword)
        {
            return (customer.Password == hashPassword);
        }
        public ShoppingCart GetCart(string username, string productName)
        {
            string custId = GetCust(username).Id;
            string prodId = GetProd(productName).Id;
            ShoppingCart cart = dbcontext.ShoppingCarts.Where(x => x.CustomerId == custId && x.ProductId == prodId).FirstOrDefault();
            return cart;
        }
        public void CreateCart(string username, string productName)
        {
            string custId = GetCust(username).Id;
            string prodId = GetProd(productName).Id;
            ShoppingCart cart = new ShoppingCart();
            cart.Id = Guid.NewGuid().ToString();
            cart.CustomerId = custId;
            cart.ProductId = prodId;
            cart.ProductQty = 1;
            dbcontext.Add(cart);
            dbcontext.SaveChanges();
        }
        public void RemoveCart(ShoppingCart cart)
        {
            dbcontext.ShoppingCarts.Remove(cart);
            dbcontext.SaveChanges();
        }
        public void IncreaseProductQty(ShoppingCart cart)
        {
            cart.ProductQty++;
            dbcontext.SaveChanges();
        }
        public void UpdateProductQty(ShoppingCart cart, int newQty)
        {
            cart.ProductQty = newQty;
            dbcontext.SaveChanges();
        }
        public List<Product> GetProductsInCart(string username)
        {
            List<ShoppingCart> carts = GetCartProducts(username);
            List<Product> productsInCart = new List<Product>();
            foreach (ShoppingCart cart in carts)
            {
                for (int i = 0; i < cart.ProductQty; i++)
                    productsInCart.Add(cart.Product);
            }
           
            return productsInCart;
        }
        public int GetQtyInSessionCart(string username)
        {
            string custId = GetCust(username).Id;
            List<ShoppingCart> carts = dbcontext.ShoppingCarts.Where(x => x.CustomerId == custId).ToList();
            int qty = 0;
            foreach (ShoppingCart cart in carts)
            {
                qty += cart.ProductQty;
            }
            return qty;
        }
        public Product GetProd(string productName)
        {
            Product product = dbcontext.Products.Where(x => x.ProductName == productName).FirstOrDefault();
            return product;
        }

        public List<Product> Listofproduct()
        {
            List<Product> products = dbcontext.Products.ToList();

            foreach (Product product in products)
            {
                new Product
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    Image = product.Image,
                    UnitPrice = product.UnitPrice
                };
            }

            return products;
        }

        public List<PurchasedProduct> UserPurProd(string username)
        {
            List<PurchasedProduct> purchasedProducts = dbcontext.PurchasedProducts
                                                    .Where(x => x.Customer.Username == username)
                                                    .ToList();

            return purchasedProducts;
        }

        public List<ShoppingCart> GetCartProducts(string username)
        {
            Customer customer = GetCust(username);
            List<ShoppingCart> prodIdList = dbcontext.ShoppingCarts.Where(x => x.CustomerId == customer.Id).ToList();
            return prodIdList;
        }

        public void addCartToPurProd(string custId, string prodId)
        {
            Product product = dbcontext.Products.Where(x => x.Id == prodId).FirstOrDefault();
            PurchasedProduct pp = new PurchasedProduct();
            pp.Id = Guid.NewGuid().ToString();
            pp.ProductName = product.ProductName;
            pp.ActivationCode = Guid.NewGuid().ToString();
            pp.CustomerId = custId;
            pp.Image = product.Image;
            pp.Description = product.ProductDescription;
            pp.PurchaseDate = DateTime.Now;
            dbcontext.Add(pp);
            dbcontext.SaveChanges();
        }

        public void deleteCartProd(List<ShoppingCart> cartList)
        {
            using (IDbContextTransaction transact = dbcontext.Database.BeginTransaction())
            {
                try
                {
                    foreach (ShoppingCart cart in cartList)
                    {
                        if (cart.ProductQty == 1)
                        {
                            addCartToPurProd(cart.CustomerId, cart.ProductId);
                        }
                        else
                        {
                            for (int i = 0; i < cart.ProductQty; i++)
                            {
                                addCartToPurProd(cart.CustomerId, cart.ProductId);
                            }
                        }
                    }
                    foreach (ShoppingCart cart1 in cartList)
                    {
                        dbcontext.ShoppingCarts.Remove(cart1);
                    }
                    dbcontext.SaveChanges();

                    transact.Commit();

                }
                catch (Exception)
                {
                    transact.Rollback();
                }
            }
        }

        public string getProdId(string prodName)
        {
            string prodId = dbcontext.Products.Where(x => x.ProductName == prodName).Select(x => x.Id).FirstOrDefault();
            return prodId;
        }
    }   
}
