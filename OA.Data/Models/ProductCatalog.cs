using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Data.Models
{
    public class ProductCatalog
    {
        public int id { get; set; }
        public string name { get; set; }
        public string photoName { get; set; }
        public decimal price { get; set; }
        public DateTime lastUpdated { get; set; }

    }
}
