using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public  class OrderedProductDto
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public int State { get; set; }
        public int OrderID { get; set; }

    }
}
