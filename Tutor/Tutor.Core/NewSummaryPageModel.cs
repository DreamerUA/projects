using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor.Core.Entities;

namespace Tutor.Core
{
    public class NewSummaryPageModel
    {
        public Summary Summary { get; set; }
        public UserInfo Owner { get; set; }
        public List<VacancyPageModel> Vacancies { get; set; }
    }
}
