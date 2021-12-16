using AutoMapper;
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
        public static List<SalaryModel> GetAll()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Salary, SalaryModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<SalaryModel>>(ManagerDataAccessFactory.SalaryDataAccess().Get());
            return data;
        }

        public static SalaryModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Salary, SalaryModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<SalaryModel>(ManagerDataAccessFactory.SalaryDataAccess().Get(id));
            return data;
        }

        public static void Add(SalaryModel n, int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<SalaryModel, Salary>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Salary>(n);
            ManagerDataAccessFactory.SalaryDataAccess().Add(data,id);
        }

        public static void Edit(SalaryModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<SalaryModel, Salary>();
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
