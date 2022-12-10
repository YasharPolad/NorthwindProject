using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;


namespace DataAccess.Abstract
{


    public interface IProductDal : IEntityRepository<Product>
    {
        List<ProductDetailDto> GetAllDtos(Expression<Func<Product,bool>> expression = null);   
    }
}
