using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor.Core.Entities;

namespace Tutor.Core
{
  public  class EditVacancyModel
    {
        public Vacancy Vacancy { get; set; }
        public ICollection<Skill> Skills { get; set; }
    }
}
