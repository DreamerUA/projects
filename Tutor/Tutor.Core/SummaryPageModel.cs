using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor.Core.Entities;

namespace Tutor.Core
{
   public class SummaryPageModel
    {
        public Summary Summary { get; set; }
        public UserInfo Owner { get; set; }
    }
}
