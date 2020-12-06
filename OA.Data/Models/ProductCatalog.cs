using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Data
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
