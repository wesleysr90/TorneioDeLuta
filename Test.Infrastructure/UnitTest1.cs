using System;
using System.Threading.Tasks;
using TorneioDeLuta.Domain.Entities;
using Xunit;

namespace Test.Infrastructure
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1Async()
        {
            Torneio dadosTorneio = new Torneio();
            TorneioDeLuta.Infrastructure.Service.TorneioService _torneioService = new TorneioDeLuta.Infrastructure.Service.TorneioService();
            
            dadosTorneio.Lutadores = await _torneioService.GetLutadoresAsync();


        }
    }
}
