using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;
using Beckend.DataLayer.Models;
using Beckend.DomainLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VisProject.DataLayer.DTO.TrainingDTO;

namespace Beckend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IService _model;
        private readonly IMapper _mapper;

        public HomeController(IService model,IMapper mapper)
        {
            _model = model;
            _mapper = mapper;
        }

        [Route("/home")]
        [HttpGet]
        public IActionResult ViewHomePage()
        {
            return View("Home");
        }

        [Route("/trainings")]
        [HttpGet]
        public IActionResult trainings()
        {
            
            var items = _model.GetAllTrainingsWithDate();
            List<ViewTraining> trainings =_mapper.Map<List<ViewTraining>>(items);
            ViewBag.trainings = trainings;



            //trainings.Select(t => { t.Users = _model.GetAllRegistredUsers(t.Id); return t;});


            //Controler -> dto
            //service relations handling
            //dto without relation




            return View();
        }


        [Route("/Trainings")]
        [HttpPost]
        public ActionResult<string> trainings(string name, string password)
        {
            
            string UID = Request.Form["UID"];
            string TID = Request.Form["TID"];
            if (_model.RegisterToTraining(UID, TID))
            {
                ViewBag.Message = String.Format("User is already registred");
                return View("home");
            }  
            ViewBag.Message = String.Format("User registred succesfully");
            return View("home");
        }

        [Route("/couches")]
        [HttpGet]
        public IActionResult couches()
        {
            ViewBag.couches = _model.GetAllCouchs();
            return View();
        }



    }
}
