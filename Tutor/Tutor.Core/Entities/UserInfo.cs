
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tutor.Core.Entities
{
    public class UserInfo
    {

        public UserInfo(UserInfo model)
        {
            this.UserId = model.UserId;
            this.FirstName = model.FirstName;
            this.LastName = model.LastName;
            this.DateOfBirth = model.DateOfBirth;
            this.Country = model.Country;
            this.City = model.City;
            this.Phone = model.Phone;
            this.About = model.About;
            this.ImagePath = model.ImagePath;
            this.Education = model.Education;
        }
        public UserInfo()
        {
            Skills = new List<Skill>();
        }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource_ru2),
                   ErrorMessageResourceName = "ImagePathRequired")]
        [Display(Name = "ImagePath", ResourceType = typeof(Resources.Resource_ru2))]
        public string ImagePath { get; set; }
        public int UserInfoId { get; set; }
        public int UserId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource_ru2),
                   ErrorMessageResourceName = "FirstNameRequired")]
        [Display(Name = "FirstName", ResourceType = typeof(Resources.Resource_ru2))]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource_ru2),
                   ErrorMessageResourceName = "LastNameRequired")]
        [Display(Name = "LastName", ResourceType = typeof(Resources.Resource_ru2))]
        public string  LastName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource_ru2),
                   ErrorMessageResourceName = "GenderRequired")]
        [Display(Name = "Gender", ResourceType = typeof(Resources.Resource_ru2))]
        public string Gender { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource_ru2),
                   ErrorMessageResourceName = "DateOfBirthRequired")]
        [Display(Name = "DateOfBirth", ResourceType = typeof(Resources.Resource_ru2))]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource_ru2),
                   ErrorMessageResourceName = "EducationRequired")]
        [Display(Name = "Education", ResourceType = typeof(Resources.Resource_ru2))]
        public string Education { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource_ru2),
                   ErrorMessageResourceName = "CountryRequired")]
        [Display(Name = "Country", ResourceType = typeof(Resources.Resource_ru2))]
        public string Country { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource_ru2),
                   ErrorMessageResourceName = "CityRequired")]
        [Display(Name = "City", ResourceType = typeof(Resources.Resource_ru2))]
        public string City { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource_ru2),
                   ErrorMessageResourceName = "PhoneRequired")]
        [Display(Name = "Phone", ResourceType = typeof(Resources.Resource_ru2))]
        public string Phone { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource_ru2),
                   ErrorMessageResourceName = "AboutRequired")]
        [Display(Name = "About", ResourceType = typeof(Resources.Resource_ru2))]
        public string  About { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
    }   
}