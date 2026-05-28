using AutoMapper;
using Order.DTO.DTO.Request;
using Order.DTO.DTO.Response;
using Order.DTO.Models;

namespace Order.Data.Automapper
{
    public class UserMapping :Profile
    {
        public UserMapping()
        {
            CreateMap<User, UserResponse>();
            CreateMap<UserRequest, User>();
        }
    }
}
