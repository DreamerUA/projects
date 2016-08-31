using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor.Core;
using Tutor.Core.Entities;
namespace Tutor.Interfaces
{
   public interface IUserInfoRepository : IDisposable
    {
        UserInfo GetUserInfoByUserId(int userId);
        UserInfo GetUserInfoByLogin(string login);
        void DeleteSkillInfo(DeleteSkillModel model);
        void Create(UserInfo item);
        void Update(UserInfo item);
        void Delete(int id);
        void Save();
    }
}
