using Business.Abstract;
using Business.Constants;
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
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        { 
            if(DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>();
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll());
        }

        public  IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            var products =_productDal.GetAll(p => p.CategoryId == id);
            return new SuccessDataResult<List<Product>>(products);
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            var products = _productDal.GetAll(p => p.UnitPrice > min
                                              && p.UnitPrice < max);
            return new SuccessDataResult<List<Product>>(products);
        }

        public IDataResult<Product> GetProductById(int productId)
        {
            Product product = _productDal.Get(p => p.ProductId == productId);
            return new SuccessDataResult<Product>(product);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            var productDtos = _productDal.GetAllDtos();
            return new SuccessDataResult<List<ProductDetailDto>>(productDtos);
        }
    }

}
