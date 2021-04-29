using WebApplication1.Domains.Models;
using WebApplication1.Resoucers;
using AutoMapper;

namespace WebApplication1.Mapping
{
    public class ResouceToModelProfile : Profile
    {
        public ResouceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>();
        }
    }
}
