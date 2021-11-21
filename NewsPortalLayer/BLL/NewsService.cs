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
    public class NewsService
    {
        public static List<NewsModel> GetAll()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<News, NewsModel>());
            var mapper = new Mapper(config);

            /*var data = mapper.Map<List<ProductModel>>(ProductRepository.GetAll());*/
            /*IRepository<product, int> repo = DataAccessFactory.ProductDataAccess();*/

            var data = mapper.Map<List<NewsModel>>(DataAccessFactory.ProductDataAccess().Get());

            return data;
        }
    }
}
