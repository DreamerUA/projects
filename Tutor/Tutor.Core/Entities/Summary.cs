
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tutor.Core.Entities
{
    public class Summary
    {
        public int SummaryId { get; set; }

        public int UserId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource_ru2),
                   ErrorMessageResourceName = "TitleRequired")]
        [Display(Name = "Title", ResourceType = typeof(Resources.Resource_ru2))]
        public string Title { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource_ru2),
                   ErrorMessageResourceName = "DescriptionRequired")]
        [Display(Name = "Description", ResourceType = typeof(Resources.Resource_ru2))]
        public string Description { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource_ru2),
                   ErrorMessageResourceName = "DateRequired")]
        [Display(Name = "Date", ResourceType = typeof(Resources.Resource_ru2))]
        public DateTime Date { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
        public Summary()
        {
            Skills = new List<Skill>();
        }
        public Summary(Summary model)
        {
            this.Title = model.Title;
            this.Description = model.Description;
            this.UserId = model.UserId;
        }
    }
}