using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor.Core.Entities;
using Tutor.Core;

namespace Tutor.Interfaces
{
    public interface IUniversalRepository : ISkillRepository, IUserInfoRepository, ISummaryRepository, IVacancyRepository
    {
        // void Create(Skill item);
        // void Delete(int id);
        ICollection<SummaryPageModel> GetRandomSummaries();
        void Save(bool b);
        ICollection<VacancyPageModel> SearchVacancy(SearchWorkModel model, int[] skills);
        ICollection<SummaryPageModel> SearchSummary(SearchModel model, int[] skills);
        ICollection<SummaryPageModel> AutoCompleteSummary(Vacancy vacancy);
        ICollection<VacancyPageModel> AutoCompleteVacancy(Summary summary);

        // void Create(UserInfo item);
        // void DeleteUserInfo(int id);
        // void DeleteSkill(DeleteSkillModel model);
        // UserInfo GetUserInfoByLogin(string login);
        // UserInfo GetUserInfoByUserId(int userId);
        //Skill GetSkillById(int id);
        //void Update(UserInfo item);
    }
}
