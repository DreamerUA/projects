using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor.Core.Entities;

namespace Tutor.Interfaces
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetUserList();
        User GetUserById(int id);
        User GetUserByLogin(string login);
        User Login(string login, string pass);
        User Register(string login, string email);

        void Create(User item);
        void Update(User item);
        void Delete(int id);
        void Save();
    }
}
