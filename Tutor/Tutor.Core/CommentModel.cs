using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tutor.Core.Entities;

namespace Tutor.Core
{
    public class CommentModel
    {
        //комент
        public Review Review { get; set; }
        //кто оставил
        public User User { get; set; }

        public CommentModel()
        {

        }
        public CommentModel(Review review, User user)
        {
            this.Review = review;
            this.User = user;
        }
    }
}