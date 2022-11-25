using AutoMapper;
using Beckend.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisProject.DataLayer.DTO.TrainingDTO;

namespace VisProject.DataLayer.Profiles
{
    public class TrainingProfile : Profile
    {
        public TrainingProfile()
        {


            CreateMap<Training, ViewTraining>().ForMember(vm => vm.Registred, m => m.MapFrom(u => u.Users.Count()));
                
        }

        
    }
}
