using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Tutor.Core
{
    public class LoginModel
    {

        public string Login { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}