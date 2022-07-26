﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Leave_Management.Data
{
    public class Employee: IdentityUser
    {

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string TaxId { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateJoined { get; set; }

       // public DateTime DateCreated { get; set; }

    }
}
