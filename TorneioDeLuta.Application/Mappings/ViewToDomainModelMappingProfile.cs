using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TorneioDeLuta.Application.ViewModels;
using TorneioDeLuta.Domain.Entities;

namespace TorneioDeLuta.Application.Mappings
{
    public class ViewToDomainModelMappingProfile : Profile
    {
        public ViewToDomainModelMappingProfile()
        {
            CreateMap<LutadorViewModel, Lutador>();
        }


    }
}
