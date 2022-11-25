using Beckend.DataLayer.Models;
using Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Beckend.DomainLayer.Repositories.TrainingRepository
{
    public class TrainingRepository : ITrainingRepository
    {
        private DatabaseContext _context;

        public TrainingRepository(DatabaseContext database)
        {
            _context = database;
        }


        public void CreateTraining(Training training)
        {
            if (training == null)
            {
                throw new ArgumentNullException(nameof(training));
            }
            _context.Add(training);
        }

        public void DeleteTraining(Training training)
        {
            if (training == null)
            {
                throw new ArgumentNullException(nameof(training));
            }
            _context.Trainings.Remove(training);
        }

        public IEnumerable<Tag> GetAllTrainingTags(int id)
        {
            var tags = _context.Trainings.Include(p => p.Tags).Where(p => p.Id == id).First().Tags.AsEnumerable();
            return tags;
        }

        public IEnumerable<User> GetAllTrainingUsers(int id)
        {        
            var users = _context.Trainings.Include(p => p.Users).Where(p => p.Id == id).First().Users.AsEnumerable();
            return users;      
        }

        public IEnumerable<Training> GetAllTrainings()
        {
            return _context.Trainings.ToList();
        }

        
   

        public Training GetTrainingById(int id)
        {
            return _context.Trainings.FirstOrDefault(p => p.Id == id);
        }

        

        public bool SaveTrainingChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateTraining(Training training)
        {
            _context.Update(training);
            SaveTrainingChanges();
        }
    }
}
