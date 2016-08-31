using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor.Core;
using Tutor.Core.Entities;
using Tutor.Interfaces;
using System.Data.Entity;

namespace Tutor.Data.Repository
{
   public class ReviewRepository : IReviewRepository
    {
        DataContext db;
        public ReviewRepository()
        {
            db = new DataContext();
        }
        public void Create(Review item)
        {
            db.Reviews.Add(item);
        }

        public void Delete(int id)
        {
            Review rev = db.Reviews.Find(id);
            if (rev != null)
            {
                db.Reviews.Remove(rev);
            }
        }

        public ReviewModel GetAllCommentsByUserId(int id)
        {
            List<CommentModel> list = new List<CommentModel>();
            var comments = db.Reviews.Where(i => i.UserId == id).ToList();
            foreach (var t in comments)
            {
                list.Add(new CommentModel(t, db.Users.Find(t.SenderId)));///////////////////////
            }
            return new ReviewModel(db.Users.Find(id), list);
        }

        //нужно избавиться от него
        public ReviewModel GetAllCommentsByUserLogin(string login)
        {
            return GetAllCommentsByUserId(db.Users.FirstOrDefault(u => u.Login == login).UserId);
        }

        //не нужен
        public IEnumerable<Review> GetReviewListByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Review item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ReviewRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
