using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using test_project.Models.EntityFramwork;
using test_project.Models.ViewModel;
using AutoMapper;

namespace test_project.Controllers
{
    public class ProductController : ApiController
    {
        [Route("api/product/names")]
        [HttpGet]
        public List<string> PNames()
        {
            ProductEntities db = new ProductEntities();

            var data = (from e in db.products
                        select e.Name).ToList();

            return data;
        } 
        
        [Route("api/product/names/{id}")]
        [HttpGet]
        public string PNames(int id)
        {
            ProductEntities db = new ProductEntities();

            var data = (from e in db.products
                        where e.Id == id
                        select e.Name).FirstOrDefault();

            return data;
        }

        public List<ProductModel> Get()
        {
            ProductEntities db = new ProductEntities();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<product, ProductModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<ProductModel>>(db.products.ToList());

            return data;

            /*var data = new List<ProductModel>();
            foreach (var e in db.products)
            {
                var p = new ProductModel()
                {
                    Id = e.Id,
                };
                data.Add(p);

                data.Add(new ProductModel() { Id = e.Id, Name = e.Name, Qty = e.Qty, Price = e.Price, Description = e.Description });
            }
            return data;*/
        }

        public void Post(ProductModel p)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductModel, product>());
            var mapper = new Mapper(config);
            var data = mapper.Map<product>(p);

            ProductEntities db = new ProductEntities();
            db.products.Add(data);
            db.SaveChanges();
        }
    }
}
