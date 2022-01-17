using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TorneioDeLuta.Application.ViewModels;
using TorneioDeLuta.Domain.Entities;

namespace TorneioDeLuta.Application.Mappings
{
    public class DomainToViewModelMappingProfile: Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Lutador, LutadorViewModel>();
            CreateMap<Resultado, ResultadoViewModel>();
        }


    }
}
