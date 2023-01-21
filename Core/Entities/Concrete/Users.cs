﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Entities;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class Users:IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Contact { get; set; }

        public ICollection<UserOperationClaim> OperationClaims { get; set; }
    }
}
