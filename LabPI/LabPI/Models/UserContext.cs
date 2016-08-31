﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LabPI.Models
{
    public class UserContext : DbContext
    {
        public UserContext() :
            base("DefaultConnectionPI2")
        { }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}