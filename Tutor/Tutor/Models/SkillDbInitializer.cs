using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Tutor.Core.Entities;
using Tutor.Data;

namespace Tutor.Web.Models
{
    public class SkillDbInitializer : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            Skill s1 = new Skill { SkillId = 1, Name = "Skill1" };
            Skill s2 = new Skill { SkillId = 2, Name = "Skill2" };
            Skill s3 = new Skill { SkillId = 3, Name = "Skill3" };
            Skill s4 = new Skill { SkillId = 4, Name = "Skill4" };

            context.Skills.Add(s1);
            context.Skills.Add(s2);
            context.Skills.Add(s3);
            context.Skills.Add(s4);

            User u1 = new User
            {
                UserId = 1,
                Login = "User1",
                Email = "qwe@dsa.ew",
                Password = "123",
                RoleId = 2
            };
            UserInfo c2 = new UserInfo
            {
                UserInfoId = 9999,
                About = "qwe",
                UserId = 1,
                Phone = "123456",
                City = "qwewq",
                Country = "wdae",
                DateOfBirth = DateTime.Now.AddDays(-5),
                FirstName = "qwewe",
                LastName = "rrrrrrrrr",
                Skills = new List<Skill>() { s1, s2, s3, s4 }
            };
            context.Users.Add(u1);
            context.UserInfo.Add(c2);

            base.Seed(context);
        }
    }
}