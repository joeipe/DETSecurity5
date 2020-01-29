using AutoMapper;
using DETSecurity5.Api.ViewModels;
using DETSecurity5.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DETSecurity5.Api.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<OrderVM, Order>();
        }
    }
}
