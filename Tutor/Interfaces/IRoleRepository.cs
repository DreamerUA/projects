using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor.Core.Entities;

namespace Tutor.Interfaces
{
   public  interface IRoleRepository : IDisposable
    {
        Role GetRoleById(int id);
        void Create(Role item);
        void Update(Role item);
        void Delete(int id);
        void Save();
    }
}
