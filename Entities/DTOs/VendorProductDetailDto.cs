using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class VendorProductDetailDto:IDto
    {
        public int Price { get; set; }
        //public int UnitPrice { get; set; }
       // public int Quantity { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public string ProductPhoto { get; set; }
        public int UnitsInStock { get; set; }
        public int VendorID{ get; set; }

       public int VendorProductID { get; set; }
       // public int ProductID { get; set; }

    }
}
