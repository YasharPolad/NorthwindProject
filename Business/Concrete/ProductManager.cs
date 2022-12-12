using Business.Abstract;
using Core.Entities;
using Core.Utilities.GenericResults;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            if(product.ProductName.Length < 2)
            {
                return new ErrorResult("Product name can't be less than 2 characters");
            }
            _productDal.Add(product);
            return new SuccessResult();
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice > min
                                         && p.UnitPrice < max);      
        }

        public Product GetProductById(int productId)
        {
            return _productDal.Get(p => p.ProductId == productId);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetAllDtos();
        }
    }

}
