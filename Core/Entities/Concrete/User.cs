using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class User:IEntity
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; } // dob vs ekle
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Contact { get; set; }
    }
}
