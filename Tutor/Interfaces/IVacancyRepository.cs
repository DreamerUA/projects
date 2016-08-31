using System;
using System.Collections.Generic;
using Tutor.Core;
using Tutor.Core.Entities;

namespace Tutor.Interfaces
{
   public interface IVacancyRepository : IDisposable
    {
        IEnumerable<Vacancy> GetVacancyListByUserId(int id);
        IEnumerable<Vacancy> GetVacancyListByLogin(string login);
        IEnumerable<VacancyPageModel> GetRandomVacancy(int count);
        IEnumerable<Vacancy> GetVacancyBySummary(Summary summary);
        IEnumerable<Vacancy> GetVacancyByUserInfo(UserInfo info);
        IEnumerable<Vacancy> GetVacancyList();
        Vacancy GetVacancyById(int id);
        void DeleteSkillVacancy(DeleteSkillModel model);

        void Create(Vacancy item);
        void Update(Vacancy item);
        void Delete(int id);
        void Save();
    }
}
