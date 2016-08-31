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
    public class VacancyRepository : IVacancyRepository
    {
        DataContext db;
        public VacancyRepository()
        {
            db = new DataContext();
        }
        public void Create(Vacancy item)
        {

            db.Vacancies.Add(item);
        }

        public void Delete(int id)
        {
            Vacancy vac = db.Vacancies.Find(id);
            if (vac != null)
            {
                db.Vacancies.Remove(vac);
            }
        }
        public void DeleteSkillVacancy(DeleteSkillModel model)
        {
            Skill skill = db.Skills.Find(model.SkillId);//то что удаляем

            Vacancy vac = skill.Vacancys.FirstOrDefault(u => u.VacancyId == model.Id);// у кого удаляем
            vac.Skills.Remove(skill);
        }
        public IEnumerable<Vacancy> GetVacancyList()
        {
            return db.Vacancies.ToList();
        }

        public IEnumerable<VacancyPageModel> GetRandomVacancy(int count)
        {
            List<VacancyPageModel> list = new List<VacancyPageModel>();
            Random rand = new Random();
            Vacancy vac = new Vacancy();
            UserInfo user = new UserInfo();
            for (int i = 0; i < count; i++)
            {
                int toSkip = rand.Next(1, db.Vacancies.Count());
                vac = db.Vacancies.OrderBy(x => x.VacancyId).Skip(toSkip).Take(1).First();
                user = db.UserInfo.FirstOrDefault(u=>u.UserId==vac.UserId);
                list.Add(new VacancyPageModel { Owner = user, Vacancy=vac });
            }
            return list;
        }

        public IEnumerable<Vacancy> GetVacancyBySummary(Summary summary)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vacancy> GetVacancyByUserInfo(UserInfo info)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vacancy> GetVacancyListByLogin(string login)
        {
            return db.Vacancies.Where(v => v.UserId ==
            db.Users.FirstOrDefault(u => u.Login == login).UserId).ToList();
        }

        public IEnumerable<Vacancy> GetVacancyListByUserId(int id)
        {
            return db.Vacancies.Where(v => v.UserId == id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Vacancy item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        public Vacancy GetVacancyById(int id)
        {
            return db.Vacancies.Find(id);
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
    }
}
