using AutoMapper;
using Beckend.DataLayer.DTO;
using Beckend.DataLayer.Models;
using Beckend.DomainLayer.Services;
using Beckend.Repositories;
using Database;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beckend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IService _model;



        public ApiController(IService model, IMapper mapper)
        {
            _mapper = mapper;
            _model = model;

        }




        //Room API endpoints

        [HttpPut("/room/{id}")]
        public ActionResult<Couch> UpdateRoom(int id, Room item)
        {
            var repo_item = _model.GetRoomById(id);
            if (repo_item == null)
            {
                return NotFound();
            }

            _model.UpdateRoom(repo_item);
            _model.SaveRoomChanges();
            return NoContent();
        }

        [HttpDelete("/room/{id}")]
        public ActionResult DeleteRoom(int id)
        {
            var repo_item = _model.GetRoomById(id);
            if (repo_item == null)
            {
                return NotFound();
            }
            _model.DeleteRoom(repo_item);
            _model.SaveCouchChanges();
            return NoContent();
        }
        [HttpPost("room")]
        public ActionResult<Couch> CreateRoom(Room item)
        {
            _model.CreateRoom(item);
            _model.SaveRoomChanges();
            return Ok(item);
        }

        [HttpGet("room")]
        public ActionResult<IEnumerable<Room>> GetAllRooms()
        {
            var items = _model.GetAllRooms();
            return Ok(items);
        }

        [HttpGet("room/{id}")]
        public ActionResult<IEnumerable<Room>> GetRoomById(int Id)
        {
            var item = _model.GetRoomById(Id);
            return Ok(item);
        }


        //Couch API endpoints

        [HttpPut("couch/{id}")]
        public ActionResult<Couch> UpdateCouch(int id, Couch item)
        {
            var repo_item = _model.GetCouchById(id);
            if (repo_item == null)
            {
                return NotFound();
            }

            _model.UpdateCouch(repo_item);
            _model.SaveCouchChanges();
            return NoContent();
        }

        [HttpDelete("couch/{id}")]
        public ActionResult DeleteCouch(int id)
        {
            var repo_item = _model.GetCouchById(id);
            if (repo_item == null)
            {
                return NotFound();
            }
            _model.DeleteCouch(repo_item);
            _model.SaveCouchChanges();
            return NoContent();
        }

        [HttpPost("couch")]
        public ActionResult<Couch> CreateCouch(Couch item)
        {
            _model.CreateCouch(item);
            _model.SaveCouchChanges();
            return Ok(item);
        }

        [HttpGet("couch")]
        public ActionResult<IEnumerable<Couch>> GetAllCouches()
        {
            var items = _model.GetAllCouchs();
            return Ok(items);
        }

        [HttpGet("couch/{id}")]
        public ActionResult<IEnumerable<Couch>> GetCouchById(int Id)
        {
            var item = _model.GetCouchById(Id);
            return Ok(item);
        }


        //Tags API endpoints
        [HttpPut("tag/{id}")]
        public ActionResult<Couch> UpdateTag(int id, Tag item)
        {
            var repo_item = _model.GetTagById(id);
            if (repo_item == null)
            {
                return NotFound();
            }
            _model.UpdateTag(repo_item);
            _model.SaveTagChanges();
            return NoContent();
        }

        [HttpDelete("tag/{id}")]
        public ActionResult DeleteTag(int id)
        {
            var repo_item = _model.GetTagById(id);
            if (repo_item == null)
            {
                return NotFound();
            }
            _model.DeleteTag(repo_item);
            _model.SaveTagChanges();
            return NoContent();
        }

        [HttpPost("tag")]
        public ActionResult<Tag> CreateTag(Tag item)
        {
            _model.CreateTag(item);
            _model.SaveTagChanges();
            return Ok(item);
        }

        [HttpGet("tag")]
        public ActionResult<IEnumerable<Tag>> GetAllTags()
        {
            var items = _model.GetAllTags();
            return Ok(items);
        }

        [HttpGet("tag/{id}")]
        public ActionResult<IEnumerable<Tag>> GetTagById(int Id)
        {
            var item = _model.GetTagById(Id);
            return Ok(item);
        }


        //Trainings API endpoints

        [HttpPut("training/{id}")]
        public ActionResult<UserReadDTO> UpdateTraining(int id, Training training)
        {
            var repo_training = _model.GetTrainingById(id);
            if (repo_training == null)
            {
                return NotFound();
            }

            _model.UpdateTraining(repo_training);
            _model.SaveTrainingChanges();
            return NoContent();
        }

        [HttpDelete("training/{id}")]
        public ActionResult DeleteTraining(int id)
        {
            var repo_training = _model.GetTrainingById(id);
            if (repo_training == null)
            {
                return NotFound();
            }
            _model.DeleteTraining(repo_training);
            _model.SaveUserChanges();
            return NoContent();
        }

        [HttpPost("training")]
        public ActionResult<Training> Create(Training training)
        {
            _model.CreateTraining(training);
            _model.SaveTrainingChanges();
            return Ok(training);
        }
        [Route("training")]
        [HttpGet]
        public ActionResult<IEnumerable<Training>> GetAllTrainings()
        {
            var trainings = _model.GetAllTrainings();
            return Ok(trainings);
        }

        [HttpGet("training/{id}")]
        public ActionResult<IEnumerable<Training>> GetTrainingById(int Id)
        {
            var training = _model.GetTrainingById(Id);
            return Ok(training);
        }




        //users API endpoints
        [HttpPut("user/{id}")]
        public ActionResult<UserReadDTO> UpdateUser(int id, UserUpdateDTO user)
        {
            var repo_user = _model.GetUserById(id);
            if (repo_user == null)
            {
                return NotFound();
            }
            _mapper.Map(user, repo_user);
            _model.UpdateUser(repo_user);
            _model.SaveUserChanges();
            return NoContent();
        }
        [HttpPatch("user/{id}")]
        public ActionResult PartialUserUpdate(int id, JsonPatchDocument<UserUpdateDTO> patchdoc)
        {
            var repo_user = _model.GetUserById(id);
            if (repo_user == null)
            {
                return NotFound();
            }
            var userToPatch = _mapper.Map<UserUpdateDTO>(repo_user);
            patchdoc.ApplyTo(userToPatch, ModelState);
            if (!TryValidateModel(userToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(userToPatch, repo_user);
            _model.UpdateUser(repo_user);
            _model.SaveUserChanges();

            return NoContent();
        }
        [HttpDelete("user/{id}")]
        public ActionResult Delete(int id)
        {
            var repo_user = _model.GetUserById(id);
            if (repo_user == null)
            {
                return NotFound();
            }
            _model.DeleteUser(repo_user);
            _model.SaveUserChanges();
            return NoContent();
        }
        [HttpPost("user")]
        public ActionResult<User> Create(User user)
        {
            _model.CreateUser(user);
            _model.SaveUserChanges();
            return Ok(user);
        }
        [HttpGet("user")]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var users = _model.GetAllUsers();

            return Ok(users);
        }
        [HttpGet("user/{id}")]

        public ActionResult<IEnumerable<User>> GetUserById(int Id)
        {
            var user = _model.GetUserById(Id);
            return Ok(user);
        }

        [HttpGet("user/training")]
        public ActionResult<List<Tuple<int,int>>> GetUserTraining()
        {
            List<Tuple<int, int>> items = new List<Tuple<int, int>>();
            foreach(User u in _model.GetAllUsers())
            {
                foreach(Training t in _model.GetAllUserTrainings(u.Id))
                {
                    items.Add(Tuple.Create(u.Id,t.Id));
                }
                
            }
            return items;
        }
        [HttpGet("training/tag")]
        public ActionResult<List<Tuple<int, int>>> GetTrainingTag()
        {
            List<Tuple<int, int>> items = new List<Tuple<int, int>>();
            foreach (Training t in _model.GetAllTrainings())
            {
                foreach (Tag tag in _model.GetAllTrainingTags(t.Id))
                {
                    items.Add(Tuple.Create(t.Id, tag.Id));
                }

            }
            return items;
        }
        [HttpGet("room/training")]
        public ActionResult<List<Tuple<int, int>>> GetRoomTraining()
        {
            List<Tuple<int, int>> items = new List<Tuple<int, int>>();
            foreach (Room r in _model.GetAllRooms())
            {
                foreach (Training t in _model.GetAllRoomTrainings(r.Id))
                {
                    items.Add(Tuple.Create(r.Id, t.Id));
                }

            }
            return items;
        }
        [HttpGet("couch/training")]
        public ActionResult<List<Tuple<int, int>>> GetCouchTraining()
        {
            List<Tuple<int, int>> items = new List<Tuple<int, int>>();
            foreach (Couch c in _model.GetAllCouchs())
            {
                foreach (Training t in _model.GetAllRoomTrainings(c.Id))
                {
                    items.Add(Tuple.Create(c.Id, t.Id));
                }

            }
            return items;
        }









    }
}
