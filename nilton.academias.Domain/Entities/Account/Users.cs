﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nilton.academias.Domain.Entities.Account
{
    public class Users
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; }
    }
}
