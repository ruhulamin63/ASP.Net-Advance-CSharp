using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ManagerServiceProviderInterface<T, ID>
    {
        void AddSP(T e);

        List<T> GetSP();

        T GetSP(ID id);

        void EditSP(T e);

        void DeleteSP(ID id);

       List<T> ConfirmBookedService(ID id);

        //T AssignServices(ID id);
    }
}
