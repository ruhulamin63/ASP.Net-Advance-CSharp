using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepository<T, ID>
    {
        bool Add(T e);

        List<T> Get();

        T Get(ID id);

        bool Edit(T e);

        bool Delete(ID id);

        List<Booking> GetByOrderDate(DateTime order_date);
        List<Booking> GetByCustomerId(int id);
        List<Booking> GetByOrderDateCustomerId(DateTime order_date, int id);
    }
}
