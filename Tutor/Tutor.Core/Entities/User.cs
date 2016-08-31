using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Tutor.Core.Entities
{
    public class User
    {
        public int UserId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Resource_ru2),
                   ErrorMessageResourceName = "LoginRequired")]
        [Display(Name = "Login", ResourceType = typeof(Resources.Resource_ru2))]
        public string Login { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource_ru2),
                   ErrorMessageResourceName = "EmailRequired")]
        [Display(Name = "Email", ResourceType = typeof(Resources.Resource_ru2))]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The password must be at least 5 characters long.", MinimumLength = 5)]
        [Display(Name = "Password", ResourceType = typeof(Resources.Resource_ru2))]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }//???

    }
}