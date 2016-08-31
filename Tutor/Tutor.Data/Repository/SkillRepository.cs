using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor.Core.Entities;
using Tutor.Interfaces;

namespace Tutor.Data.Repository
{
    public class SkillRepository : ISkillRepository
    {
        DataContext db;
        public SkillRepository()
        {
            db = new DataContext();
        }
        public void Create(Skill item)
        {
            db.Skills.Add(item);
        }

        public void Delete(int id)
        {
            Skill skill = db.Skills.Find(id);
            db.Skills.Remove(skill);
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
        // ~SkillRepository() {
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
        public Skill GetSkillByName(string name)
        {
            return db.Skills.FirstOrDefault(s => s.Name == name);
        }

        public Skill GetSkillById(int id)
        {
            return db.Skills.Find(id);
        }

        public ICollection<Skill> GetList()
        {
            return db.Skills.ToList();
        }

        public ICollection<string> FindByName(string name)
        {
            return db.Skills.Where(s => s.Name.StartsWith(name))
                .Select(i=>i.Name).Distinct().ToList();
        }
    }
}
