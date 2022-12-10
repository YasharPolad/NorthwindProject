using Business.Concrete;
using Core.DataAccess.Concrete.EntityFramework;
using Core.Entities;
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
            ProductTest();
            //CategoryTest();

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
            List<ProductDetailDto> products = productManager.GetProductDetails();
            products.ForEach(p => Console.WriteLine(p.CategoryName + " " + p.ProductName));
        }
    }
}
