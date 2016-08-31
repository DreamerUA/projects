using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Tutor.Core.Entities;

namespace Tutor.Data
{
  public  class DataContext : DbContext
    {
        public DataContext() :
        base("TutorConnection")
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public DbSet<Skill> Skills { get; set; }
        public DbSet<Summary> Summaries { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
    }

}
