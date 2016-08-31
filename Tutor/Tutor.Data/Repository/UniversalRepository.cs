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
    /// <summary>
    /// The project business logic.
    /// </summary>
    public class UniversalRepository : IUniversalRepository
    {
        private DataContext db;
        public UniversalRepository(DataContext context)
        {
            this.db = context;
        }
       public ICollection<SummaryPageModel> GetRandomSummaries()
        {
            List<SummaryPageModel> list = new List<SummaryPageModel>();
            foreach (var s in db.Summaries.ToList())
            {
                list.Add(new SummaryPageModel { Summary = s, Owner = db.UserInfo.FirstOrDefault(i => i.UserId == s.UserId) });
            }
            return list.GetRange(0, 3);
        }
        public ICollection<SummaryPageModel> AutoCompleteSummary(Vacancy vacancy)
        {
            List<SummaryPageModel> list = new List<SummaryPageModel>();
            foreach (var s in db.Summaries.ToList())
            {
                list.Add(new SummaryPageModel { Summary = s, Owner = db.UserInfo.FirstOrDefault(i => i.UserId == s.UserId) });
            }
            return list.GetRange(0,3);//TODO
        }
        public ICollection<VacancyPageModel> AutoCompleteVacancy(Summary summary)
        {
            List<VacancyPageModel> list = new List<VacancyPageModel>();
            foreach (var v in db.Vacancies.ToList())
            {
                list.Add(new VacancyPageModel { Vacancy = v, Owner = db.UserInfo.FirstOrDefault(i => i.UserId == v.UserId) });
            }
            return list.GetRange(0,3);//TODO
        }
        #region Vacancy
        public ICollection<VacancyPageModel> SearchVacancy(SearchWorkModel model, int[] skills)
        {
            List<VacancyPageModel> list = new List<VacancyPageModel>();
            foreach (var v in db.Vacancies.ToList())
            {
                list.Add(new VacancyPageModel { Vacancy = v, Owner = db.UserInfo.FirstOrDefault(i => i.UserId == v.UserId) });
            }
            return list;//TODO
        }
        /// <summary>
        /// Get vacancies
        /// </summary>
        /// <returns>
        /// List
        /// </returns>
        public IEnumerable<Vacancy> GetVacancyList()
        {
            return db.Vacancies.ToList();
        }
        /// <summary>
        /// Get vacancy by Id
        /// </summary>
        /// <param name="id"> 
        /// vacancy id
        /// </param>
        /// <returns>Vacancy</returns>
        public Vacancy GetVacancyById(int id)
        {
            return db.Vacancies.Find(id);
        }
        /// <summary>
        /// Get vacancies list
        /// </summary>
        /// <param name="id">
        /// User Id
        /// </param>
        /// <returns>
        /// IEnumerable<Vacancy>
        /// </returns>
        public IEnumerable<Vacancy> GetVacancyListByUserId(int id)
        {
            return db.Vacancies.Where(v => v.UserId == id);
        }

        /// <summary>
        /// Get vacancies
        /// </summary>
        /// <param name="login">User login</param>
        /// <returns></returns>
        public IEnumerable<Vacancy> GetVacancyListByLogin(string login)
        {
            return db.Vacancies.Where(v => v.UserId ==
           db.Users.FirstOrDefault(u => u.Login == login).UserId).ToList();
        }
       
        public IEnumerable<VacancyPageModel> GetRandomVacancy(int count)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Vacancy> GetVacancyBySummary(Summary summary)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Vacancy> GetVacancyByUserInfo(UserInfo info)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create vacancy
        /// </summary>
        /// <param name="item">
        /// vacancy
        /// </param>
        public void Create(Vacancy item)
        {
            db.Vacancies.Add(item);
        }
        /// <summary>
        /// Update vacancy
        /// </summary>
        /// <param name="item">
        /// Vacancy to update
        /// </param>
        public void Update(Vacancy item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        #endregion

        #region Summary
        public ICollection<SummaryPageModel> SearchSummary(SearchModel model, int[] skills)
        {
            List<SummaryPageModel> list = new List<SummaryPageModel>();
            foreach (var s in db.Summaries.ToList())
            {
                list.Add(new SummaryPageModel { Summary = s, Owner = db.UserInfo.FirstOrDefault(i => i.UserId == s.UserId) });
            }
            return list;//TODO
        }

        /// <summary>
        /// Delete skill from sumaryy skill list
        /// </summary>
        /// <param name="model">
        /// Delete skill model
        /// </param>
        public void DeleteSkillSummary(DeleteSkillModel model)
        {
            Skill skill = db.Skills.Find(model.SkillId);//то что удаляем

            Summary sum = skill.Summarys.FirstOrDefault(u => u.SummaryId == model.Id);// у кого удаляем
            sum.Skills.Remove(skill);
        }
        /// <summary>
        /// Get summaries list
        /// </summary>
        /// <returns>
        /// IEnumerable<Summary>
        /// </returns>
        public IEnumerable<Summary> GetSummaryList()
        {
            return db.Summaries.ToList();
        }
        /// <summary>
        /// Get summaries from user
        /// </summary>
        /// <param name="id">
        /// summary id
        /// </param>
        /// <returns>
        /// IEnumerable<Summary>
        /// </returns>
        public IEnumerable<Summary> GetSummaryListByUserId(int id)
        {
            return db.Summaries.Where(s => s.UserId == id);
        }

        /// <summary>
        /// Get summaries from user
        /// </summary>
        /// <param name="login">
        /// User login
        /// </param>
        /// <returns>
        /// IEnumerable<Summary>
        /// </returns>
        public IEnumerable<Summary> GetSummaryListByLogin(string login)
        {
            return db.Summaries.Where(s => s.UserId ==
             db.Users.FirstOrDefault(u => u.Login == login).UserId);
        }
        public IEnumerable<Summary> GetSummaryListByVacancy(Vacancy vacancy)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Create summary
        /// </summary>
        /// <param name="item">
        /// Summary to create
        /// </param>
        public void Create(Summary item)
        {
            db.Summaries.Add(item);
        }
        /// <summary>
        /// Update summary
        /// </summary>
        /// <param name="item">
        /// Summary to update
        /// </param>
        public void Update(Summary item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        /// <summary>
        /// Get summary
        /// </summary>
        /// <param name="id">
        /// summary id
        /// </param>
        /// <returns>
        /// Summary
        /// </returns>
        public Summary GetSummaryById(int id)
        {
            return db.Summaries.Find(id);
        }
        #endregion

        #region UserInfo
        /// <summary>
        /// Get user info
        /// </summary>
        /// <param name="login">
        /// User login
        /// </param>
        /// <returns>
        /// UserInfo
        /// </returns>
        public UserInfo GetUserInfoByLogin(string login)
        {
            return db.UserInfo.FirstOrDefault(j =>
            j.UserId == db.Users.FirstOrDefault(i => i.Login == login).UserId);
        }
        /// <summary>
        /// Get user info
        /// </summary>
        /// <param name="userId">
        /// userId
        /// </param>
        /// <returns>
        /// UserInfo
        /// </returns>
        public UserInfo GetUserInfoByUserId(int userId)
        {
            return db.UserInfo.FirstOrDefault(i => i.UserId == userId);
        }

        /// <summary>
        /// Update user info
        /// </summary>
        /// <param name="item">
        /// Entity to update
        /// </param>
        public void Update(UserInfo item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        /// <summary>
        /// Delete skill from user skill list
        /// </summary>
        /// <param name="model">
        /// DeleteSkillModel
        /// ></param>
        public void DeleteSkillInfo(DeleteSkillModel model)
        {
            Skill skill = db.Skills.Find(model.SkillId);//то что удаляем

            UserInfo info = skill.Users.FirstOrDefault(u => u.UserId == model.Id);// у кого удаляем
            info.Skills.Remove(skill);
        }
        /// <summary>
        /// Create user info
        /// </summary>
        /// <param name="item">
        /// Item to update
        /// </param>
        public void Create(UserInfo item)
        {
            db.UserInfo.Add(item);
        }
        /// <summary>
        /// Delete user info
        /// </summary>
        /// <param name="id">
        /// User info id
        /// </param>
        public void DeleteUserInfo(int id)
        {
            UserInfo info = db.UserInfo.Find(id);
            if (info != null)
            {
                db.UserInfo.Remove(info);
            }
        }
        #endregion
        /// <summary>
        ///  Get skill
        /// </summary>
        /// <param name="id">
        /// Skill id
        /// </param>
        /// <returns>
        /// Skill
        /// </returns>
        public Skill GetSkillById(int id)
        {
            return db.Skills.Find(id);
        }

        /// <summary>
        /// Create skill
        /// </summary>
        /// <param name="item">
        /// Item to create
        /// </param>
        public void Create(Skill item)
        {
            db.Skills.Add(item);
        }
        /// <summary>
        /// Delete skill
        /// </summary>
        /// <param name="id">
        /// Skill id to delete
        /// </param>
        public void Delete(int id)
        {
            Skill skill = db.Skills.Find(id);
            db.Skills.Remove(skill);
        }
        /// <summary>
        /// Get skill
        /// </summary>
        /// <param name="name">
        /// Skill title
        /// </param>
        /// <returns>
        /// Skill
        /// </returns>
        public Skill GetSkillByName(string name)
        {
            return db.Skills.FirstOrDefault(s => s.Name == name);
        }
        /// <summary>
        /// Get skills
        /// </summary>
        /// <param name="name"> 
        /// Part of title
        /// </param>
        /// <returns>
        /// ICollection<string>
        /// </returns>
        public ICollection<string> FindByName(string name)
        {
            return db.Skills.Where(s => s.Name.StartsWith(name))
                 .Select(i => i.Name).Distinct().ToList();
        }
        /// <summary>
        /// Get skills list
        /// </summary>
        /// <returns>
        /// ICollection<string>
        /// </returns>
        public ICollection<Skill> GetList()
        {
            return db.Skills.ToList();
        }
        /// <summary>
        /// Save change
        /// </summary>
        /// <param name="b"></param>
        public void Save(bool b)
        {
            db.SaveChanges();
        }
        /// <summary>
        /// Delete skill from vacancy skill list
        /// </summary>
        /// <param name="model">
        /// Delete skill model
        /// </param>
        public void DeleteSkillVacancy(DeleteSkillModel model)
        {
            Skill skill = db.Skills.Find(model.SkillId);//то что удаляем
            Vacancy vac = skill.Vacancys.FirstOrDefault(u => u.VacancyId == model.Id);// у кого удаляем
            vac.Skills.Remove(skill);
        }
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
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
        // ~UniversalRepository() {
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

        void ISkillRepository.Save()
        {
            db.SaveChanges();
        }

        void ISummaryRepository.Save()
        {
            db.SaveChanges();
        }

        void IVacancyRepository.Save()
        {
            db.SaveChanges();
        }

        void IUserInfoRepository.Save()
        {
            db.SaveChanges();
        }
        #endregion
    }
}
