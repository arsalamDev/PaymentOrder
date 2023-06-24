using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentOrder.Core.Domain.Abstract
{
    public interface ICrudRepository<T>
    {
        bool Insert(T value);
        List<T> Get();
        bool Update(T value);
        bool Delete(int Id);
    }
}
