using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public  class CartCartProductDto
    {
        public int CartID { get; set; }
        public DateTime ExpireDate { get; set; }
        public int CustomerID { get; set; }
        public int CartProductID { get; set; }
        public int VendorProductID { get; set; }
        public int Quantity { get; set; }
        
    }
}
