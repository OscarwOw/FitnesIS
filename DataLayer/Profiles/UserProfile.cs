using AutoMapper;
using Beckend.DataLayer.DTO;
using Beckend.DataLayer.DTO.UserDTO;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beckend.DataLayer.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {

            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();



            CreateMap<User, UserReadDTO>();
            CreateMap<UserCreateDTO, UserReadDTO>();
            CreateMap<UserCreateDTO, User>();

            CreateMap<UserUpdateDTO, User>();
            CreateMap<User, UserUpdateDTO>();


        }
    }
}
