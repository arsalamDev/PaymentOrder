using PaymentOrder.Core.Domain.Entities.Employees;
using PaymentOrder.WebAdminPanel.Models;
using PaymentOrder.WebAdminPanel.Models.Employees;
using System.Reflection;

namespace PaymentOrder.WebAdminPanel.Mapper.Employees
{
    public class EmployeeMapper : BaseMapper<EmployeesEntity, EmployeesModel>
    {
        public override EmployeesEntity Map(EmployeesModel model)
        {
            return new EmployeesEntity()
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                PasswordHash =model.PasswordHash,
                IsModified = model.IsModified,
                IsCreated = model.IsCreated,
                IsDeleted = model.IsDeleted,
            };
        }

        public override EmployeesModel Map(EmployeesEntity entity)
        {
            return new EmployeesModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Surname = entity.Surname,
                Email = entity.Email,
                PasswordHash = entity.PasswordHash,
                IsModified = entity.IsModified,
                IsCreated = entity.IsCreated,
                IsDeleted = entity.IsDeleted,
            };
        }
    }
}
