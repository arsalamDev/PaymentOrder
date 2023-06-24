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
                Count = model.Count,
                Price = model.Price,
                Discount = model.Discount,
                DiscountStartDate = model.DiscountStartDate,
                DiscountEndDate = model.DiscountEndDate,
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
                Count = entity.Count,
                Price = entity.Price,
                Discount = entity.Discount,
                DiscountStartDate = entity.DiscountStartDate,
                DiscountEndDate = entity.DiscountEndDate,
                IsModified = entity.IsModified,
                IsCreated = entity.IsCreated,
                IsDeleted = entity.IsDeleted,
            };
        }
    }
}
