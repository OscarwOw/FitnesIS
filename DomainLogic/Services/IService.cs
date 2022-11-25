using Beckend.DataLayer.Models;
using Beckend.DomainLayer.Repositories.CouchRepository;
using Beckend.DomainLayer.Repositories.RoomRepository;
using Beckend.DomainLayer.Repositories.TagRepository;
using Beckend.DomainLayer.Repositories.TrainingRepository;
using Beckend.Repositories;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisProject.DataLayer.DTO.TrainingDTO;

namespace Beckend.DomainLayer.Services
{
    public interface IService : ICouchRepository, IRoomRepository, ITagRepository, ITrainingRepository, IUserRepository
    {
        public bool LoginCheck(string name, string password);
        public bool Register(User user);
        public int CountRegistredUsers(int id);
        public bool RegisterToTraining(string uID, string tID);
        public List<Training> FilterPastTrainings(List<Training> trainings);
        public List<Training> FilterFutureTrainings(List<Training> trainings);
        public List<Training> GetAllTrainingsWithDate();
        public List<Training> GetAllUserFutureTrainings(int id);
        void Unregister(int uID, int tID);
        void PartialUpdateUser(string name, string email, string phonenumber, string birthdate, int uID);
        //List<Training> GetAllRegistredTrainings(int id);
    }
}
