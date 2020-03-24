using CozaStore.Core.Entities;
using CozaStore.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CozaStore.Core.IRepo
{
    public interface IProductRepo
    {
        void AddProduct(CreateProductVM product);
        Product GetProductByID(int id);
        IEnumerable<Product> GetAllProducts();
        void Delete(Product pro);
        void Update(Product proToUpdate);
        IEnumerable<Product> GetWomenProducts();
        IEnumerable<Product> GetMenProducts();
        IEnumerable<Product> GetMenBags();
        IEnumerable<Product> GetMenWatches();
        IEnumerable<Product> GetMenShoes();
        IEnumerable<Product> GetWomenWatches();
        IEnumerable<Product> GetWomenBags();
        IEnumerable<Product> GetWomenShoes();

    }
}
