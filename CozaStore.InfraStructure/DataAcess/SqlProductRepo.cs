using CozaStore.Core.Entities;
using CozaStore.Core.Enums;
using CozaStore.Core.IRepo;
using CozaStore.Core.ViewModels;
using CozaStore.InfraStructure.Data;
using CozaStore.Services.Util;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace CozaStore.InfraStructure.DataAcess
{

    public class SqlProductRepo : IProductRepo
    {
        private readonly ApplicationDbContext db;
        private readonly IWebHostEnvironment hostingEnvironment;

        public SqlProductRepo(ApplicationDbContext db, IWebHostEnvironment hostingEnvironment)
        {
            this.db = db;
            this.hostingEnvironment = hostingEnvironment;
        }

        public void AddProduct(CreateProductVM model)
        {
            

            string imagePath = ImageHandeler.UploadImage(model.PhotoBinary, hostingEnvironment.WebRootPath);

            Product pro = new Product
            {
                Name = model.Name,
                Price = model.Price,
                Image = imagePath,
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
                ImageHandeler.DeleteImage(pro.Image, hostingEnvironment.WebRootPath);

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


        public void Update(CreateProductVM updatedPro)
        {
            Product OldProduct = db.Products.Find(updatedPro.Id);
            //delete old image.

            if (updatedPro.PhotoBinary != null)
            {
                bool output = ImageHandeler.DeleteImage(OldProduct.Image, hostingEnvironment.WebRootPath);
                OldProduct.Image = ImageHandeler.UploadImage(updatedPro.PhotoBinary, hostingEnvironment.WebRootPath);
            }

            OldProduct.Name = updatedPro.Name;
            OldProduct.Price = updatedPro.Price;
            OldProduct.Category = updatedPro.Category;
            OldProduct.Type = updatedPro.Type;
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
