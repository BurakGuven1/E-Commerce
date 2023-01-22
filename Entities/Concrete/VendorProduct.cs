﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class VendorProduct:IEntity
    {
        public int VendorProductID { get; set; }
        public int VendorID { get; set; }
        public int ProductID { get; set; }
       
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        
    }
}
