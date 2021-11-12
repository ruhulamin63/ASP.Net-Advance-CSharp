using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BEntities
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
    }
}
