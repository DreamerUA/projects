using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor.Core;
using Tutor.Core.Entities;

namespace Tutor.Interfaces
{
    public interface IReviewRepository : IDisposable
    {
        IEnumerable<Review> GetReviewListByUserId(int id);
        ReviewModel GetAllCommentsByUserId(int id);
        ReviewModel GetAllCommentsByUserLogin(string login);

        void Create(Review item);
        void Update(Review item);
        void Delete(int id);
        void Save();
    }
}
