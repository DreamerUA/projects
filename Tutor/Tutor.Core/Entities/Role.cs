using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tutor.Core.Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
    }
}