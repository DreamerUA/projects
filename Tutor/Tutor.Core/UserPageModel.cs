using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor.Core.Entities;
namespace Tutor.Core
{
   public class UserPageModel
    {
        public UserInfo info { get; set; }
        public ReviewModel comments { get; set; }
        public User user { get; set; }
        public ICollection<SummaryPageModel> Summaries { get; set; }
    }
}
