using System;
using System.Threading.Tasks;
using TorneioDeLuta.Domain.Entities;
using Xunit;

namespace Test.Infrastructure
{
    public class TorneioServiceTest
    {
        [Fact]
        public async Task GetLutadoresAsync_Test()
        {
            //Arrange
            Torneio dadosTorneio = new Torneio();
            TorneioDeLuta.Infrastructure.Service.TorneioService _torneioService = new TorneioDeLuta.Infrastructure.Service.TorneioService();

            // Act
            dadosTorneio.Lutadores = await _torneioService.GetLutadoresAsync();


            //Assert
            Assert.True(dadosTorneio.Lutadores.Count > 0);
        }
    }
}
