using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor.Core.Entities;
using Tutor.Core;

namespace Tutor.Interfaces
{
    public interface ISkillRepository : IDisposable
    {
        Skill GetSkillByName(string name);
        Skill GetSkillById(int id);
        ICollection<string> FindByName(string name);
        ICollection<Skill> GetList();
        void Create(Skill item);
        void Delete(int id);
        void Save();
    }
}
