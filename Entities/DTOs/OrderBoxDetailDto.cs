using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class OrderBoxDetailDto:IDto
    {
        public int CustomerID { get; set; }
        public int CartID { get; set; }
        public int Quantity { get; set; }
        public int VendorProductID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }

    }
}
