
using Beckend.DataLayer.Models;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beckend.Repositories
{
    public interface IUserRepository 
    {
        bool SaveUserChanges();

        public IEnumerable<User> GetAllUsers();
        public IEnumerable<User> GetAllCompleteUsers();
        public User GetUserById(int id);
        public void CreateUser(User user);
        public void UpdateUser(User user);
        public void DeleteUser(User user);
        
        public User GetUserByName(string name);
        public List<Training> GetAllUserTrainings(int id);
    }
}
