using Beckend.DataLayer.Models;
using Database;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beckend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DatabaseContext _context;

        public UserRepository(DatabaseContext database)
        {
            _context = database;
        }
        public void CreateUser(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _context.Add(user);
            _context.SaveChanges();
            
        }
        public void DeleteUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _context.Users.Remove(user);
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public IEnumerable<User> GetAllCompleteUsers()
        {
            List<User> users = new List<User>();
            foreach(User user in GetAllUsers())
            {
                user.Trainings = GetAllUserTrainings(user.Id);
                users.Add(user);
            }
            return users;
        }


        public bool SaveUserChanges()
        {
            return _context.SaveChanges()>=0;
        }

        public void UpdateUser(User user)
        {
            //_context.
            _context.Update(user);
            _context.SaveChanges();
        }

        public User GetUserByName(string name)
        {
            return _context.Users.FirstOrDefault(p => p.UserName == name);
        }

        public List<Training> GetAllUserTrainings(int id)
        {
            var trainings = _context.Users.Include(p => p.Trainings).Where(p => p.Id == id).First().Trainings.AsEnumerable().ToList();
            return trainings;
        }
    }
}
