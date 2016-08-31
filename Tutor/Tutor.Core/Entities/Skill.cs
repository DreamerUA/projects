using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tutor.Core.Entities
{
    public class Skill
    {
        public int SkillId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource_ru2),
                   ErrorMessageResourceName = "NameRequired")]
        [Display(Name = "Name", ResourceType = typeof(Resources.Resource_ru2))]
        public string Name { get; set; }
        public virtual ICollection<UserInfo> Users { get; set; }
        public virtual ICollection<Summary> Summarys { get; set; }
        public virtual ICollection<Vacancy> Vacancys { get; set; }
        public Skill()
        {
            Users = new List<UserInfo>();
        }
    }
}