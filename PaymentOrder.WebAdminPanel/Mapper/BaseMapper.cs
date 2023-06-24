using PaymentOrder.Core.Domain.Entities;
using PaymentOrder.WebAdminPanel.Models;

namespace PaymentOrder.WebAdminPanel.Mapper
{
    public abstract class BaseMapper<TEntity, TModel> where TEntity : BaseEntity where TModel : BaseModel
    {
        public abstract TEntity Map(TModel model);
        public abstract TModel Map(TEntity entity);
    }
}
