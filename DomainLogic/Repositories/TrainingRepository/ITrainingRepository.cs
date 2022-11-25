using Beckend.DataLayer.Models;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beckend.DomainLayer.Repositories.TrainingRepository
{
    public interface ITrainingRepository
    {
        bool SaveTrainingChanges();

        IEnumerable<Training> GetAllTrainings();
        Training GetTrainingById(int id);
        void CreateTraining(Training training);
        void UpdateTraining(Training training);
        void DeleteTraining(Training training);

        IEnumerable<User> GetAllTrainingUsers(int id);
        IEnumerable<Tag> GetAllTrainingTags(int id);
        
    }
}
