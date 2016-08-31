using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tutor.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Tutor.Core
{
    public class ReviewModel
    {
        //кого коментируют
        public User User { get; set; }
        //список коментариев его акк
        public List<CommentModel> Comments { get; set; }
        
        public ReviewModel(User user, List<CommentModel> comm)
        {
            this.User = user;
            this.Comments = comm;
        }
    }
}