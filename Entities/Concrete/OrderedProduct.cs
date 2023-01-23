using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class OrderedProduct:IEntity
    {
        public int OrderedProductID { get; set; }
        public int VendorProductID { get; set; }
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public int State { get; set; }

    }
}
