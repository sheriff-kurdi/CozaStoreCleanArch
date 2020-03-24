﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CozaStore.Core.Entities;
using CozaStore.Core.IRepo;
using CozaStore.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CozaStore.Web.Controllers
{
    public class ProductsController : Controller
    {

        private readonly IProductRepo productRepo;

        public ProductsController(IProductRepo productRepo)
        {
            this.productRepo = productRepo;
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

            if (model.photo != null)
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
            return View(pro);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product UpdatedPro)
        {
            productRepo.Update(UpdatedPro);
            return RedirectToAction("ManageProducts", "products");
        }
        //end update



    }
}