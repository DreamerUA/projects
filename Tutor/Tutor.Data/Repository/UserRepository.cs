using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor.Core.Entities;
using Tutor.Interfaces;

namespace Tutor.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        DataContext db;

        public UserRepository()
        {
            db = new DataContext(); 
        }
        public void Create(User item)
        {
            db.Users.Add(item);
        }

        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
            {
                db.Users.Remove(user);
            }
        }

        public User GetUserById(int id)
        {
            return db.Users.Find(id);
        }

        public User GetUserByLogin(string login)
        {
            User uu = db.Users.FirstOrDefault(u => u.Login == login);
            return uu;
        }

        public IEnumerable<User> GetUserList()
        {
            return db.Users.ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(User item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public User Login(string login, string pass)
        {
           return db.Users.FirstOrDefault(u => u.Login ==login && u.Password == pass);
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
        // ~UserRepository() {
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

        public User Register(string login, string email)
        {
            return db.Users.FirstOrDefault(u => u.Login == login || u.Email == email);
        }
        #endregion
    }
}
