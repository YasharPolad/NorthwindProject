using Business.Concrete;
using Core.DataAccess.Concrete.EntityFramework;
using Core.Entities;
using Core.Utilities.GenericResults;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProductTest();
            //CategoryTest();
            AddTest();

        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
            foreach (Category category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryId + " " + category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            //InMemoryProductDal inMemoryProductDal = new InMemoryProductDal();
            ProductManager productManager = new ProductManager(new EFProductDal());
            IDataResult<List<ProductDetailDto>> productsResult = productManager.GetProductDetails();
            if(productsResult.IsSuccess)
            {
                var products = productsResult.Data;
                products.ForEach(p => Console.WriteLine(p.CategoryName + " " + p.ProductName));
            }
            else
            {
                Console.WriteLine(productsResult.Message);
            }
        }

        private static void AddTest()
        {
            ProductManager productManager = new ProductManager(new EFProductDal());
            productManager.Add(new Product { ProductName = "Cup", CategoryId = 1, UnitPrice = 200, UnitsInStock = 4});
        }
    }
}
