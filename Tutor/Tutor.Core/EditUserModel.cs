using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor.Core.Entities;


namespace Tutor.Core
{
    public class EditUserModel
    {
        public UserInfo userInfo { get; set; }
        public ICollection<Skill> skillList { get; set; }

    }
}
