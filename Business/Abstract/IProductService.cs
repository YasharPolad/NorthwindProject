using Core.Entities;
using Core.Utilities.GenericResults;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<ProductDetailDto> GetProductDetails();
        List<Product> GetAllByCategoryId(int id);
        List<Product> GetByUnitPrice(decimal min, decimal max);
        IResult Add(Product product);
        Product GetProductById(int productId);
    }
}
