using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tutor.Core.Entities;
using Tutor.Core;
using Tutor.Interfaces;
using Tutor.Data;
using Tutor.Data.Repository;
using Tutor.Web.Util;

namespace Tutor.Controllers
{
    public class ReviewController : Controller
    {
        IUserRepository userRepo;
        IReviewRepository reviewRepo;
        public ReviewController(IReviewRepository r, IUserRepository u)
        {
            userRepo = u;
            reviewRepo = r;
        }
        // GET: Review
        public ActionResult Index( int id)
        {
            return View(id);
        }

        [HttpPost]
        public ActionResult NewComment(NewCommentModel model)
        {
            if (ModelState.IsValid)
            {
                reviewRepo.Create(new Review
                {
                    SenderId = userRepo.GetUserByLogin(model.SenderLogin).UserId,
                    UserId = model.UserId,
                    Message = model.Message,
                    Mark = model.Mark,
                    Date = model.Date
                });
                reviewRepo.Save();
            }
            return RedirectToAction("UserPage", "Account",new { Id = model.UserId });
        }
    }
}