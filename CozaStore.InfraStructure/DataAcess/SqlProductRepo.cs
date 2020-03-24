﻿using CozaStore.Core.Entities;
using CozaStore.Core.Enums;
using CozaStore.Core.IRepo;
using CozaStore.Core.ViewModels;
using CozaStore.InfraStructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CozaStore.InfraStructure.DataAcess
{

    public class SqlProductRepo : IProductRepo
    {
        private readonly ApplicationDbContext db;
        //private readonly IWebHostEnvironment hostingEnvironment;

        public SqlProductRepo(ApplicationDbContext db/*, IWebHostEnvironment hostingEnvironment*/)
        {
            this.db = db;
            //this.hostingEnvironment = hostingEnvironment;
        }

        public void AddProduct(CreateProductVM model)
        {
            //string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Uploads");
            //string uniqFileName = Guid.NewGuid().ToString() + "_" + model.photo.FileName;

            //string filePath = Path.Combine(uploadsFolder, uniqFileName);

            //model.photo.CopyTo(new FileStream(filePath, FileMode.Create));

            Product pro = new Product
            {
                Name = model.Name,
                Price = model.Price,
                //Image = uniqFileName,
                Type = model.Type,
                Category = model.Category


            };

            db.Products.Add(pro);
            db.SaveChanges();
        }

        public void Delete(Product pro)
        {
            if (pro != null)
            {
                db.Remove(pro);
                db.SaveChanges();
            }

        }

        public IEnumerable<Product> GetAllProducts()
        {
            IEnumerable<Product> productsList = db.Products.ToList();
            return productsList;
        }

        public Product GetProductByID(int id)
        {
            Product pro = db.Products.Find(id);
            return pro;
        }


        public void Update(Product proToUpdate)
        {
            Product pro = db.Products.Find(proToUpdate.Id);

            pro.Name = proToUpdate.Name;
            pro.Price = proToUpdate.Price;
            pro.Category = proToUpdate.Category;
            pro.Type = proToUpdate.Type;
            db.SaveChanges();
        }

        public IEnumerable<Product> GetWomenProducts()
        {
            IEnumerable<Product> WomenCollections = db.Products.Where(p => p.Category == Category.Women).ToList();
            return WomenCollections;
        }

        public IEnumerable<Product> GetMenProducts()
        {
            IEnumerable<Product> MenCollections = db.Products.Where(p => p.Category == Category.Men).ToList();
            return MenCollections;
        }

        public IEnumerable<Product> GetMenBags()
        {
            IEnumerable<Product> BagCollections = db.Products.Where(p => p.Type == Core.Enums.Type.Bag && p.Category == Category.Men).ToList();
            return BagCollections;
        }

        public IEnumerable<Product> GetMenWatches()
        {
            IEnumerable<Product> WatchesCollections = db.Products.Where(p => p.Type == Core.Enums.Type.Watches && p.Category == Category.Men).ToList();
            return WatchesCollections;
        }

        public IEnumerable<Product> GetMenShoes()
        {
            IEnumerable<Product> ShoesCollections = db.Products.Where(p => p.Type == Core.Enums.Type.Shoes && p.Category == Category.Men).ToList();
            return ShoesCollections;
        }
        public IEnumerable<Product> GetWomenWatches()
        {
            IEnumerable<Product> WatchesCollections = db.Products.Where(p => p.Type == Core.Enums.Type.Watches && p.Category == Category.Women).ToList();
            return WatchesCollections;
        }
        public IEnumerable<Product> GetWomenBags()
        {
            IEnumerable<Product> BagCollections = db.Products.Where(p => p.Type == Core.Enums.Type.Bag && p.Category == Category.Women).ToList();
            return BagCollections;
        }
        public IEnumerable<Product> GetWomenShoes()
        {
            IEnumerable<Product> ShoesCollections = db.Products.Where(p => p.Type == Core.Enums.Type.Shoes && p.Category == Category.Women).ToList();
            return ShoesCollections;
        }
    }
}
