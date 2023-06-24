using PaymentOrder.Core.Domain.Entities.Customers;
using PaymentOrder.Core.Domain.Entities.Employees;
using PaymentOrder.WebAdminPanel.Models.Customers;

namespace PaymentOrder.WebAdminPanel.Mapper.Customers
{
    public class CustomersMapper : BaseMapper<CustomersEntity, CustomersModel>
    {
        public override CustomersEntity Map(CustomersModel model)
        {
            return new CustomersEntity()
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                Telephone = model.Telephone,
                IsModified = model.IsModified,
                IsCreated = model.IsCreated,
                IsDeleted = model.IsDeleted,
            };
        }

        public override CustomersModel Map(CustomersEntity entity)
        {
            return new CustomersModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Surname = entity.Surname,
                Email = entity.Email,
                Telephone = entity.Telephone,
                IsModified = entity.IsModified,
                IsCreated = entity.IsCreated,
                IsDeleted = entity.IsDeleted,
            };
        }
    }
}
