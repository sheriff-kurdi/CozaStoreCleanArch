using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CozaStore.Core.Entities;
using CozaStore.Core.IRepo;
using CozaStore.Core.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CozaStore.Web.Controllers
{
    public class ProductsController : Controller
    {

        private readonly IProductRepo productRepo;
        private readonly IWebHostEnvironment hostingEnvironment;

        public ProductsController(IProductRepo productRepo, IWebHostEnvironment hostingEnvironment)
        {
            this.productRepo = productRepo;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }




        public IActionResult ManageProducts()
        {
            IEnumerable<Product> model = productRepo.GetAllProducts();
            return View(model);
        }


        //Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product pro = productRepo.GetProductByID(id);

            return View(pro);
        }

        [HttpPost]
        public IActionResult Delete(Product pro)
        {

            productRepo.Delete(pro);
            return RedirectToAction("ManageProducts");
        }
        // end Delete


        //add
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View("AddProduct");
        }

        [HttpPost]
        public IActionResult AddProduct(CreateProductVM model)
        {
            //string uniqFileName = null;

            if (model.PhotoBinary != null)
            {
                productRepo.AddProduct(model);
                return RedirectToAction("AddProduct");
            }

            return RedirectToAction("ManageProducts");
        }
        //end add



        //update
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            Product pro = productRepo.GetProductByID(id);
            CreateProductVM proVM = new CreateProductVM
            {
                Id = pro.Id,
                Image = pro.Image,
                Category = pro.Category,
                Name = pro.Name,
                Price = pro.Price,
                Size = pro.Size,
                Type = pro.Type
            };
            return View(proVM);
        }

        [HttpPost]
        public IActionResult UpdateProduct(CreateProductVM UpdatedPro)
        {
            productRepo.Update(UpdatedPro);
            return RedirectToAction("ManageProducts", "products");
        }
        //end update



    }
}