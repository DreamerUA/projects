using System;
using System.ComponentModel.DataAnnotations;

namespace Tutor.Core.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public int SenderId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource_ru2),
                   ErrorMessageResourceName = "DateRequired")]
        [Display(Name = "Date", ResourceType = typeof(Resources.Resource_ru2))]
        public DateTime Date { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource_ru2),
                   ErrorMessageResourceName = "MessageRequired")]
        [Display(Name = "Message", ResourceType = typeof(Resources.Resource_ru2))]
        public string Message { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource_ru2),
                   ErrorMessageResourceName = "MarkRequired")]
        [Display(Name = "Mark", ResourceType = typeof(Resources.Resource_ru2))]
        public byte Mark { get; set; }
    }
}