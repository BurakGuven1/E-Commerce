using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Cart:IEntity
    {
        public int CartID { get; set; }
        public DateTime ExpireDate { get; set; }
        public int CustomerID { get; set; }
        public int CVC { get; set; }
        public string CreditCartNo { get; set; }
    }
}
