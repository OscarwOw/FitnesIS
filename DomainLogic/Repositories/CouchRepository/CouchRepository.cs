using Beckend.DataLayer.Models;
using Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beckend.DomainLayer.Repositories.CouchRepository
{
    public class CouchRepository : ICouchRepository
    {
        private DatabaseContext _context;

        public CouchRepository(DatabaseContext database)
        {
            _context = database;
        }
        public void CreateCouch(Couch Couch)
        {
            if (Couch == null)
            {
                throw new ArgumentNullException(nameof(Couch));
            }
            _context.Add(Couch);

        }
        public void DeleteCouch(Couch Couch)
        {
            if (Couch == null)
            {
                throw new ArgumentNullException(nameof(Couch));
            }
            _context.Couches.Remove(Couch);
        }

        public Couch GetCouchById(int id)
        {
            return _context.Couches.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Couch> GetAllCouchs()
        {
            return _context.Couches.ToList();
        }

        public bool SaveCouchChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateCouch(Couch Couch)
        {
            _context.Update(Couch);
        }

        public IEnumerable<Training> GetAllCouchTrainings(int id)
        {
            var trainings = _context.Couches.Include(p => p.Trainings).Where(p => p.Id == id).First().Trainings.AsEnumerable();
            return trainings;
        }
    }
}
