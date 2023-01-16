using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Image:IEntity
    {
        public int id { get; set; }
        public string imagePath { get; set; }
        public DateTime createDate { get; set; }
        public int productId { get; set; }
    }
}
