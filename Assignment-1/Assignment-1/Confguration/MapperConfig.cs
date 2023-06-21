
using Assignment_1.Models;
using Assignment_1.Models.DTO;
using AutoMapper;

namespace Assignment_1.Confguration
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<Register, LoginVM>().ReverseMap();
        }
    }
}
