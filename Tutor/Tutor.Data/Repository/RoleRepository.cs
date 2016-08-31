using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor.Core;
using Tutor.Core.Entities;
using Tutor.Interfaces;

namespace Tutor.Data.Repository
{
    public class RoleRepository : IRoleRepository
    {
        DataContext db;
        public RoleRepository()
        {
            db = new DataContext();
        }

        public void Update(Role item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public Role GetRoleById(int id)
        {
            return db.Roles.Find(id);
        }
        public void Create(Role item)
        {
            db.Roles.Add(item);
        }

        public void Delete(int id)
        {
            Role role = db.Roles.Find(id);

            if (role != null)
            {
                db.Roles.Remove(role);
            }
        }

        public void Save()
        {
            db.SaveChanges();
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
        // ~RoleRepository() {
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
