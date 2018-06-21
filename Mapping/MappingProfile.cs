using ASP_Angular.Controllers.Resources;
using ASP_Angular.Models;
using AutoMapper;

namespace ASP_Angular.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Make,ModelResource>();
            CreateMap<Model,ModelResource>();
        }
    }
}