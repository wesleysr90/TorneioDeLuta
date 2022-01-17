using AutoMapper;
using Moq;
using System;
using System.Threading.Tasks;
using TorneioDeLuta.Application.Mappings;
using TorneioDeLuta.Application.Services;
using Xunit;

namespace Test.Infrastructure
{
    public class UnitTest1
    {
        public  Mock<TorneioDeLuta.Domain.Interface.ITorneioService> _torneioService;
        public  IMapper _mapper;

        

        [Fact]
        public async Task Test1Async()
        {
            _torneioService = new Mock<TorneioDeLuta.Domain.Interface.ITorneioService>();
            var profile = new DomainToViewModelMappingProfile();
            
            _mapper = new MapperConfiguration(x => x.AddProfile(profile)).CreateMapper();

            TorneioDeLuta.Application.Services.TorneioAplicationService torneioService = new TorneioAplicationService(_mapper, _torneioService.Object);

            var teste = await torneioService.GetLutadoresAsync();


        }
    }
}
