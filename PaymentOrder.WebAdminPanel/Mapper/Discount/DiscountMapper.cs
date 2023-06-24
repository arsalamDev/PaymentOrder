using PaymentOrder.Core.Domain.Entities.Discount;
using PaymentOrder.WebAdminPanel.Models.Discount;
using System.Reflection;

namespace PaymentOrder.WebAdminPanel.Mapper.Discount
{
    public class DiscountMapper : BaseMapper<DiscountEntity, DiscountModel>
    {
        public override DiscountEntity Map(DiscountModel model)
        {
            return new DiscountEntity()
            {
                Id = model.Id,
                Discount = model.Discount,
                DiscountStartDate = model.DiscountStartDate,
                DiscountEndDate = model.DiscountEndDate,
                IsModified = model.IsModified,
                IsCreated = model.IsCreated,
                IsDeleted = model.IsDeleted,
            };
        }

        public override DiscountModel Map(DiscountEntity entity)
        {
            return new DiscountModel()
            {
                Id = entity.Id,
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
