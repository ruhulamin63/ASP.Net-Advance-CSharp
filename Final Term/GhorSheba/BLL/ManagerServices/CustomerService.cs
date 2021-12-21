using AutoMapper;
using BEL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ManagerServices
{
    public class CustomerService
    {
        public static List<CustomerModel> CustomerGetAll() //GetAll(string uty
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Customer, CustomerModel>().ReverseMap();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<CustomerModel>>(ManagerDataAccessFactory.CustomerDataAccess().GetC());

            return data;
        }

        public static void DeleteC(int id)
        {
            ManagerDataAccessFactory.CustomerDataAccess().DeleteC(id);
        }
    }
}
