using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Team9aWebApp.Models
{
    public class PurchasedProduct
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public string ActivationCode { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string CustomerId { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }

    }
}
