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
    public class ProductService
    {
        public static List<ProductModel> GetAll()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<product, ProductModel>());
            var mapper = new Mapper(config);

            /*var data = mapper.Map<List<ProductModel>>(ProductRepository.GetAll());*/
            /*IRepository<product, int> repo = DataAccessFactory.ProductDataAccess();*/

            var data = mapper.Map<List<ProductModel>>(DataAccessFactory.ProductDataAccess().Get());

            return data;
        }

        public static List<string> GetNames()
        {
           /* var data = (from e in ProductRepository.GetAll()
                        select e.Name).ToList();*/

           /* var data = ProductRepository.GetAll().Select(e => e.Name).ToList();*/
            var data = DataAccessFactory.ProductDataAccess().Get().Select(e => e.Name).ToList();

            return data;
        }


    }
}
