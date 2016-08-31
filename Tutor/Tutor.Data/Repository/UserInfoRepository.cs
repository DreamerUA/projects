using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor.Core.Entities;
using Tutor.Core;
using Tutor.Interfaces;

namespace Tutor.Data.Repository
{
    public class UserInfoRepository : IUserInfoRepository
    {
        DataContext db;
        public UserInfoRepository()
        {
            db = new DataContext();
        }
        public void Create(UserInfo item)
        {
            db.UserInfo.Add(item);
        }
        //Delete from db
        public void Delete(int id)
        {
            UserInfo info = db.UserInfo.Find(id);
            if (info != null)
            {
                db.UserInfo.Remove(info);
            }
        }
        //Delete skill from user list
        public void DeleteSkillInfo(DeleteSkillModel model)
        {
            Skill skill = db.Skills.Find(model.SkillId);//то что удаляем

            UserInfo info = skill.Users.FirstOrDefault(u=> u.UserId == model.Id);// у кого удаляем
            info.Skills.Remove(skill);
        }

        public UserInfo GetUserInfoByLogin(string login)
        {
            return db.UserInfo.FirstOrDefault(j =>
            j.UserId == db.Users.FirstOrDefault(i => i.Login == login).UserId);
        }

        public UserInfo GetUserInfoByUserId(int userId)
        {
            return db.UserInfo.FirstOrDefault(i => i.UserId == userId);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(UserInfo item)
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
        // ~UserInfoRepository() {
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
