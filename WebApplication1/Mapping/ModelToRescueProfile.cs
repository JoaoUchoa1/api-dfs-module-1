using System;
using AutoMapper;
using WebApplication1.Domains.Models;
using WebApplication1.Resoucers;

namespace WebApplication1.Mapping
{
    public class ModelToRescueProfile : Profile
    {
        public ModelToRescueProfile() 
        {
            CreateMap<Category, CategoryResource>();
        }
    }
}
