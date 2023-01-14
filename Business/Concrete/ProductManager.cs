using Business.Abstract;
using Business.Constants;
using Core.Entities;
using Core.Utilities.GenericResults;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Business.BusinessAspects.AutoFac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.BusinessRules;
using FluentValidation;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly ICategoryService _categoryService;
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        [ValidationAspect(typeof(ProductValidator))]
        [SecuredOperation("product.add,admin")]
        public IResult Add(Product product)
        {
            var check = BusinessRules.Run(CheckProductCountInCategory(product),
                CheckIfProductNameExists(product),
                CheckCategoryCount());
            if (check != null) 
            {
                return check;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        private IResult CheckProductCountInCategory(Product product)
        {
            var result = _productDal.GetAll(p => p.CategoryId == product.CategoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(Product product)
        {
            var count = _productDal.GetAll(p => p.ProductName == product.ProductName).Count;
            if (count > 0)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        private IResult CheckCategoryCount()
        {
            var count = _categoryService.GetAll().Count;
            if (count > 15)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
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
