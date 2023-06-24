using PaymentOrder.Core.Domain.Abstract.Products;
using PaymentOrder.WebAdminPanel.Models.Products;
using System.Reflection;
using System.Text.RegularExpressions;

namespace PaymentOrder.WebAdminPanel.Mapper.Products
{
    public class ProductsMapper : BaseMapper<ProductsEntity, ProductsModel>
    {
        public override ProductsEntity Map(ProductsModel model)
        {
            return new ProductsEntity()
            {
                Id = model.Id,
                Name = model.Name,
                ProductCode = model.ProductCode,
                Count = model.Count,
                Price = model.Price,
                IdDiscount = model.IdDiscount,
                IsModified = model.IsModified,
                IsCreated = model.IsCreated,
                IsDeleted = model.IsDeleted,
            };
        }

        public override ProductsModel Map(ProductsEntity entity)
        {
            return new ProductsModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                ProductCode = entity.ProductCode,
                Count = entity.Count,
                Price = entity.Price,
                IdDiscount = entity.IdDiscount,
                IsModified = entity.IsModified,
                IsCreated = entity.IsCreated,
                IsDeleted = entity.IsDeleted,
            };
        }
    }
}
