using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tutor.Core.Entities
{
    public class Vacancy
    {
        public int VacancyId { get; set; }
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
                   ErrorMessageResourceName = "StatusRequired")]
        [Display(Name = "Status", ResourceType = typeof(Resources.Resource_ru2))]
        public string Status { get; set; }

        [Display(Name = "Payment", ResourceType = typeof(Resources.Resource_ru2))]
        public int Payment { get; set; }

        //[Display(Name = "Education", ResourceType = typeof(Resources.Resource_ru2))]
        //public int Education { get; set; }

        [Display(Name = "Date", ResourceType = typeof(Resources.Resource_ru2))]
        public DateTime Date { get; set; }

        [Display(Name = "MinAge", ResourceType = typeof(Resources.Resource_ru2))]
        public byte MinAge { get; set; }

        [Display(Name = "MaxAge", ResourceType = typeof(Resources.Resource_ru2))]
        public byte MaxAge { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }

        public Vacancy()
        {
            Skills = new List<Skill>();
        }
        public Vacancy(Vacancy model)
        {
            this.Description = model.Description;
            this.Payment = model.Payment;
            this.Status = model.Status;
            this.Title = model.Title;
            this.UserId = model.UserId;
        }
    }
}