using BEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL;

namespace BLL
{
    public class NewsCategoryService
    {
        public static List<NewsCategoryModel> GetAll()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<News_category, NewsCategoryModel>());
            var mapper = new Mapper(config);
            /*var data = mapper.Map<List<CustomerModel>>(CustomerRepository.GetAll());*/
            var data = mapper.Map<List<NewsCategoryModel>>(DataAccessFactory.NewsCategoryDataAccess().Get());

            return data;
        }

        public static List<string> GetNames()
        {
            /*var data = (from e in NewsCategoryRepository.GetAll()
                        select e.name).ToList();
            var data = NewsCategoryRepository.GetAll().Select(e => e.name).ToList();*/

            var data = DataAccessFactory.NewsCategoryDataAccess().Get().Select(e => e.name).ToList();

            return data;
        }
    }
}
