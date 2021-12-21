using AutoMapper;
using BEL;
using BEL.ManagerModel;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ManagerServices
{
    public class SalaryService
    {
        public static List<SalariesModel> GetAll()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Salary, SalariesModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<SalariesModel>>(ManagerDataAccessFactory.SalaryDataAccess().Get());
            return data;
        }

        public static SalariesModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Salary, SalariesModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<SalariesModel>(ManagerDataAccessFactory.SalaryDataAccess().Get(id));
            return data;
        }

        public static void Add(int id, SalariesModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<SalariesModel, Salary>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Salary>(n);
            ManagerDataAccessFactory.SalaryDataAccess().Add(id,data);
        }

        public static void Edit(SalariesModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<SalariesModel, Salary>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Salary>(n);
            ManagerDataAccessFactory.SalaryDataAccess().Edit(data);
        }
        public static void Delete(int id)
        {
            ManagerDataAccessFactory.SalaryDataAccess().Delete(id);
        }
    }
}
