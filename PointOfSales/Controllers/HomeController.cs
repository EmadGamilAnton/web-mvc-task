using PointOfSales.Bussiness;
using PointOfSales.DAL;
using PointOfSales.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PointOfSales.Controllers
{
    public class HomeController : Controller
    {
        //dependency injection with ninject 
        /*IProductRepos productRepos;
        public HomeController(IProductRepos productRepo)
        {
            productRepos = productRepo;
        }*/
        public ActionResult Index()
        {
            using (TaskOneEntities context = new TaskOneEntities())
            {
                var model = new List<ProductInfo>();
                model = (from pc in context.Products

                         join c in context.OrderItems on pc.Id equals c.ProductId
                         join u in context.Categories on pc.CategoryId equals u.Id
                         join s in context.Stocks on pc.Id equals s.Id

                         select new ProductInfo
                         {
                             ProductId = (int)pc.Id,
                             ProductName = pc.ProductName,
                             ProductNumber = pc.ProductNumber,
                             ProductLocation = pc.ProductLocation1.Location,
                             StockQuantity = (int)s.Quantity,
                             CatId = u.Name,
                             SubCatId = u.ParentCategoryId.ToString()
                         }).ToList();
                return View(model);
            }
        }
        //search method with string keywords to search for name,number,id,quantity...
        public ActionResult Search(string keyWords)
        {
            using (TaskOneEntities context = new TaskOneEntities())
            {
                //linq search query
                var model = new List<ProductInfo>();
                model = (from pc in context.Products

                         join c in context.OrderItems on pc.Id equals c.ProductId
                         join u in context.Categories on pc.CategoryId equals u.Id
                         join s in context.Stocks on pc.Id equals s.Id

                         select new ProductInfo
                         {
                             ProductId = (int)pc.Id,
                             ProductName = pc.ProductName,
                             ProductNumber = pc.ProductNumber,
                             ProductLocation = pc.ProductLocation1.Location,
                             StockQuantity = (int)s.Quantity,
                             CatId = u.Name,
                             SubCatId = u.ParentCategoryId.ToString()
                         }).Where(p => p.ProductName.Contains(keyWords)
                                    || p.ProductLocation.Contains(keyWords)
                                    || p.ProductNumber.Contains(keyWords)
                                    || p.StockQuantity.ToString().Contains(keyWords)).ToList();
                ViewBag.keyWords = keyWords;
                return View(model);
            }
        }

        //create method to return current view
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Product());
        }
        //create with params method to send object of product to database
        [HttpPost]
        public ActionResult Create(Product product)
        {
            ProductRepo productRepo = new ProductRepo();
            productRepo.Add(product);
            return View(product);
        }
    }
}