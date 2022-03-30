using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PointOfSales.Models
{
    public class ProductInfo
    {
        public int ProductId { get; set; }
        public string ProductNumber { get; set; }
        public string ProductName { get; set; }
        public string ProductLocation { get; set; }
        public int StockQuantity { get; set; }
        public string CatId { get; set; }
        public string SubCatId { get; set; }
    }
}