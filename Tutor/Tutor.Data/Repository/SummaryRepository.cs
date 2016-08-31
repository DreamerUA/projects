using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor.Core.Entities;
using Tutor.Core;
using Tutor.Interfaces;
using System.Data.Entity;
namespace Tutor.Data.Repository
{
    public class SummaryRepository : ISummaryRepository
    {
        DataContext db;
        public SummaryRepository()
        {
            db = new DataContext();
        }
        public void Create(Summary item)
        {
            db.Summaries.Add(item);
        }
        public void DeleteSkillSummary(DeleteSkillModel model)
        {
            Skill skill = db.Skills.Find(model.SkillId);//то что удаляем

            Summary sum = skill.Summarys.FirstOrDefault(u => u.SummaryId == model.Id);// у кого удаляем
            sum.Skills.Remove(skill);
        }
        public void Delete(int id)
        {
            Summary sum = db.Summaries.Find(id);
            if (sum != null)
            {
                db.Summaries.Remove(sum);
            }
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
        // ~VacancyRepository() {
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

        public IEnumerable<Summary> GetSummaryListByLogin(string login)
        {
            return db.Summaries.Where(s => s.UserId == 
            db.Users.FirstOrDefault(u=>u.Login==login).UserId);
        }

        public IEnumerable<Summary> GetSummaryListByUserId(int id)
        {
            return db.Summaries.Where(s=> s.UserId==id);
        }

        public IEnumerable<Summary> GetSummaryListByVacancy(Vacancy vacancy)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Summary item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public Summary GetSummaryById(int id)
        {
           return db.Summaries.Find(id);
        }

        public IEnumerable<Summary> GetSummaryList()
        {
           return db.Summaries.ToList();
        }
    }
}
