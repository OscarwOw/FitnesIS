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
    public class Service :  IService
    {
        
        private readonly IUserRepository _userRepository;
        private readonly ITrainingRepository _trainingRepository;
        private readonly ITagRepository _tagRepository;
        private readonly ICouchRepository _couchRepository;
        private readonly IRoomRepository _roomRepository;
        
        public Service( IUserRepository userRepository,ITrainingRepository trainingRepository, ITagRepository tagRepository,
            ICouchRepository couchRepository, IRoomRepository roomRepository)
        {   
            _userRepository = userRepository;
            _trainingRepository = trainingRepository;
            _tagRepository = tagRepository;
            _couchRepository = couchRepository;
            _roomRepository = roomRepository;      
        }

        public bool LoginCheck(string name, string password)
        {
            User user =_userRepository.GetUserByName(name);
            if (user == null) { return false; }
            if (user.UserName == name && user.Password == password)
            {
                return true;
            }
            return false;
            
        }
        public bool Register(User user)
        {
            return true;
        }

        public int CountRegistredUsers(int id)
        {

            return GetAllTrainingUsers(id).Count();// useless funkcia
        }

        public bool RegisterToTraining(string uID, string tID)
        {
            int _uID = Int32.Parse(uID);
            int _tID = Int32.Parse(tID);
            IEnumerable<User> users=GetAllTrainingUsers(_tID);
            foreach (User registredUser in users)
            {
                if (registredUser.Id == _uID)
                {
                    return true;//if registred
                }
            }
            User user =_userRepository.GetUserById(_uID);
            Training training = _trainingRepository.GetTrainingById(_tID);
            training.Users.Add(user);
            _trainingRepository.UpdateTraining(training);
            return false;//registred new user
        }


        public List<Training> FilterPastTrainings(List<Training> trainings)
        {
            List<Training> registredTrainings = new List<Training>();
            foreach (Training t in trainings)
            {
                if (DateTime.Compare(DateTime.Today, t.Date) > 0)
                {
                    registredTrainings.Append(t);
                }
            }
            return registredTrainings;
        }

        public List<Training> FilterFutureTrainings(List<Training> trainings)
        {
            List<Training> registredTrainings = new List<Training>();
            foreach (Training t in trainings)
            {
                if (DateTime.Compare(DateTime.Today, t.Date) < 0)
                {
                    registredTrainings.Add(t);




                    
                }
            }
            return registredTrainings;
        }

        public List<Training> GetAllTrainingsWithDate()
        {
            List<Training> list = _trainingRepository.GetAllTrainings().ToList();
            foreach (Training t in list)
            {
                t.Users = _trainingRepository.GetAllTrainingUsers(t.Id).ToList();
            }




            return FilterFutureTrainings(list);           
        }



        public List<Training> GetAllUserFutureTrainings(int id)
        {


            List<Training> list = _userRepository.GetAllUserTrainings(id);
            foreach (Training t in list)
            {
                t.Users = _trainingRepository.GetAllTrainingUsers(t.Id).ToList();
            }
            return FilterFutureTrainings(list);
        }

        public void Unregister(int uID, int tID)
        {
            List<Training> trainings = GetAllUserTrainings(uID);
            trainings.RemoveAll(r => r.Id == tID);
            User user = _userRepository.GetUserById(uID);
            user.Trainings = trainings;
            _userRepository.UpdateUser(user);
        }

        public void PartialUpdateUser(string name, string email, string phonenumber, string birthdate, int uID)
        {
            User user = _userRepository.GetUserById(uID);
            if (name != null) { user.FirstName = name; }
            if (email != null) { user.Email = email; }
            if (phonenumber != null) { user.PhoneNumber = phonenumber; }
            if (birthdate != null) { user.BirthDate = DateTime.Parse(birthdate); }
            _userRepository.UpdateUser(user);
        }



        

        











        //CRUD operations
        public void CreateCouch(Couch Couch)
        {
            _couchRepository.CreateCouch(Couch);
        }

        public void CreateRoom(Room Room)
        {
            _roomRepository.CreateRoom(Room);
        }

        public void CreateTag(Tag Tag)
        {
            _tagRepository.CreateTag(Tag);
        }

        public void CreateTraining(Training training)
        {
            _trainingRepository.CreateTraining(training);
        }

        public void CreateUser(User user)
        {
            _userRepository.CreateUser(user);
        }

        public void DeleteCouch(Couch Couch)
        {
            _couchRepository.DeleteCouch(Couch);
        }

        public void DeleteRoom(Room Room)
        {
            _roomRepository.DeleteRoom(Room);
        }

        public void DeleteTag(Tag Tag)
        {
            _tagRepository.DeleteTag(Tag);
        }

        public void DeleteTraining(Training training)
        {
            _trainingRepository.DeleteTraining(training);    
        }

        public void DeleteUser(User user)
        {
            _userRepository.DeleteUser(user);
        }

        public IEnumerable<Couch> GetAllCouchs()
        {
            return _couchRepository.GetAllCouchs();
        }

        public IEnumerable<Room> GetAllRooms()
        {
            return _roomRepository.GetAllRooms();
        }

        public IEnumerable<Tag> GetAllTags()
        {
            return _tagRepository.GetAllTags();
        }

        public IEnumerable<Training> GetAllTrainings()
        {
            return _trainingRepository.GetAllTrainings();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public Couch GetCouchById(int id)
        {
            return _couchRepository.GetCouchById(id);
        }

        public Room GetRoomById(int id)
        {
            return _roomRepository.GetRoomById(id);
        }

        public Tag GetTagById(int id)
        {
            return _tagRepository.GetTagById(id);
        }

        public Training GetTrainingById(int id)
        {
            return _trainingRepository.GetTrainingById(id);
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public bool SaveCouchChanges()
        {
            return _couchRepository.SaveCouchChanges();
        }

        public bool SaveRoomChanges()
        {
            return _roomRepository.SaveRoomChanges();
        }

        public bool SaveTagChanges()
        {
            return _tagRepository.SaveTagChanges();
        }

        public bool SaveTrainingChanges()
        {
            return _trainingRepository.SaveTrainingChanges();
        }

        public bool SaveUserChanges()
        {
            return _userRepository.SaveUserChanges();
        }

        public void UpdateCouch(Couch Couch)
        {
            _couchRepository.UpdateCouch(Couch);
        }

        public void UpdateRoom(Room Room)
        {
            _roomRepository.UpdateRoom(Room);
        }

        public void UpdateTag(Tag Tag)
        {
            _tagRepository.UpdateTag(Tag);
        }

        public void UpdateTraining(Training training)
        {
            _trainingRepository.UpdateTraining(training);
        }

        public void UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
        }

        public User GetUserByName(string name)
        {
            return _userRepository.GetUserByName(name);
        }

        public IEnumerable<User> GetAllTrainingUsers(int id)
        {
            return _trainingRepository.GetAllTrainingUsers(id);
        }
        public List<Training> GetAllUserTrainings(int id)
        {
            return _userRepository.GetAllUserTrainings(id);
        }

        IEnumerable<Training> ICouchRepository.GetAllCouchTrainings(int id)
        {
            return _couchRepository.GetAllCouchTrainings(id);
        }

        IEnumerable<Training> IRoomRepository.GetAllRoomTrainings(int id)
        {
            return _roomRepository.GetAllRoomTrainings(id);
        }

        public IEnumerable<Tag> GetAllTrainingTags(int id)
        {
            return _trainingRepository.GetAllTrainingTags(id);
        }

        public IEnumerable<User> GetAllCompleteUsers()
        {
            return _userRepository.GetAllCompleteUsers();
        }

        

        
        
    }
}
