using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace LabPI.Models
{
    public class UserDbInitializer : DropCreateDatabaseAlways<UserContext>
    {
        protected override void Seed(UserContext db)
        {
            db.Roles.Add(new Role { Id = 1, Name = "admin" });
            db.Roles.Add(new Role { Id = 2, Name = "user" });
            db.Users.Add(new User
            {
                Id = 1,
                Login="SiteAdmin",
                Name ="Adddmin",
                Email = "somemail@gmail.com",
                Password = "123456",
                RoleId = 1
            });
            base.Seed(db);
        }
    }
}