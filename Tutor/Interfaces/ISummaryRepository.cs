using System;
using System.Collections.Generic;
using Tutor.Core;
using Tutor.Core.Entities;

namespace Tutor.Interfaces
{
    public interface ISummaryRepository : IDisposable
    {
        IEnumerable<Summary> GetSummaryListByUserId(int id);
        IEnumerable<Summary> GetSummaryListByLogin(string login);
        IEnumerable<Summary> GetSummaryListByVacancy(Vacancy vacancy);
        IEnumerable<Summary> GetSummaryList();
        Summary GetSummaryById(int id);
        void DeleteSkillSummary(DeleteSkillModel model);
        void Create(Summary item);
        void Update(Summary item);
        void Delete(int id);
        void Save();
    }
}
