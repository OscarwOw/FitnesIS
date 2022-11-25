using Beckend.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beckend.DomainLayer.Repositories.CouchRepository
{
    public interface ICouchRepository
    {
        bool SaveCouchChanges();

        IEnumerable<Couch> GetAllCouchs();
        Couch GetCouchById(int id);
        void CreateCouch(Couch Couch);
        void UpdateCouch(Couch Couch);
        void DeleteCouch(Couch Couch);

        IEnumerable<Training> GetAllCouchTrainings(int id);
    }
}
