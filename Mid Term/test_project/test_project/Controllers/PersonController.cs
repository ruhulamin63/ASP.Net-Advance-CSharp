using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace test_project.Controllers
{
    public class PersonController : ApiController
    {
       public List<string> Get()
       {
            List<string> names = new List<string>();

            names.Add("Ruhul");
            names.Add("Amin");

            return names;
       }

        public string Get(int id)
        {
            return "Name " + id;
        }

        public string Post()
        {
            return "Posted";
        }

        public string Put()
        {
            return "Put";
        }

        public string Delete()
        {
            return "Deleted"; 
        }
    }
}
