using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using Beckend.DataLayer.DTO;
using Beckend.DataLayer.DTO.UserDTO;
using Beckend.DataLayer.Models;
using Beckend.DomainLayer.Services;
using Beckend.Repositories;
using Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VisProject.DataLayer.DTO.TrainingDTO;
using static System.Net.WebRequestMethods;

namespace Beckend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userrepository;
        private readonly IService _model;

        

        public AccountController(IUserRepository userRepository, IMapper mapper, IService model)
        {
            _mapper = mapper;
            _userrepository = userRepository;
            _model = model;
            
        }

        
        [Route("/register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [Route("/login")]
        [HttpGet]
        public IActionResult login()
        {
            return View("login");
        }
        [Route("/user/{id}")]
        [HttpGet("{id}")]
        public IActionResult updateuser(int id)
        {
            var items = _model.GetAllUserFutureTrainings(id);
            List<ViewTraining> trainings = _mapper.Map<List<ViewTraining>>(items);
            ViewBag.nextTrainings = trainings;




            return View("user");
        }
        






        [Route("/register")]
        [HttpPost]
        public ActionResult<User> register()
        {
            User user = new User();
            user.UserName = Request.Form["UserName"];

            if (_model.GetUserByName(user.UserName) == null)
            {
                user.Email = Request.Form["Email"];
                user.Password = Request.Form["Password"];
                user.PhoneNumber = Request.Form["PhoneNumber"];
                user.BirthDate = DateTime.Parse(Request.Form["Birthdate"]);
                user.FirstName = Request.Form["Name"];
                if (user.Password != Request.Form["ConfirmPassword"]) {
                    ViewBag.Message = String.Format("Wrong confirm password");
                    return View("register"); }
                string message = "Congratulation User " + user.UserName + " is sucesfully registred";
                ViewBag.Message = String.Format(message);
                _model.CreateUser(user);
                
            }
            else
            {
                ViewBag.Message = String.Format("UserName Already exists!");
            }




            

            return View("register");   
        }

        [Route("/login")]
        [HttpPost]
        public ActionResult<string> Login()
        {
            ViewBag.Success = 0;
            string Name = Request.Form["name"];
            string Password = Request.Form["Password"];
            if (_model.LoginCheck(Name, Password)) 
            {
                string test = HttpContext.Session.GetString("test");
                ViewBag.Message = String.Format("Succesfully Loged in");
                ViewBag.id = _model.GetUserByName(Name).Id; 
                ViewBag.Name = Name;
                ViewBag.Success = 1;


                



                return View();
            }
            ViewBag.Message = String.Format("Wrong Password or Username");
            
            return View();
        }
        [Route("/user/{id}")]
        [HttpPost]
        public IActionResult UpdateUser(int id)
        {
            string sTID = Request.Form["TID"];
            if (sTID != null) //TODO check TID
            {
                int UID = Int32.Parse(Request.Form["UID"]);
                int TID = Int32.Parse(sTID);
                _model.Unregister(UID,TID);
                ViewBag.Message = String.Format("tréning úspešne zrušený");                
            }
            else
            {
                string ID = Request.Form["ID"];
                int UID = Int32.Parse(ID);
                string name = Request.Form["name"];
                string email = Request.Form["email"];
                string phonenumber = Request.Form["phonenumber"];
                string birthdate = Request.Form["birthdate"];
                _model.PartialUpdateUser(name, email, phonenumber, birthdate, UID);
                
            }



            return View("login");
        }





    }
}
