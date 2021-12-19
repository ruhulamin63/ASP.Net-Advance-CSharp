using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ManagerInterface<T, ID>
    {
        void Add(T e);

        List<T> Get();

        T Get(ID id);

        void Edit(T e);

        void Delete(ID id);

        T AssignServices(ID id);
        List<Booking> GetByOrderDate(DateTime order_date);
        List<Booking> GetByCustomerId(int id);
        List<Booking> GetByOrderDateCustomerId(DateTime order_date, int id);
    }
}
