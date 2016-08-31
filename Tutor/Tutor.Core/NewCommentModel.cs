using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tutor.Core
{
    public class NewCommentModel
    {
        public int UserId { get; set; }
        public string SenderLogin { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public byte Mark { get; set; }
    }
}