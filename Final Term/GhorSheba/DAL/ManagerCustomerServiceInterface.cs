using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ManagerCustomerServiceInterface<T, ID>
    {
        void AddC(T e);

        List<T> GetC();

        T GetC(ID id);

        void EditC(T e);

        void DeleteC(ID id);
    }
}
