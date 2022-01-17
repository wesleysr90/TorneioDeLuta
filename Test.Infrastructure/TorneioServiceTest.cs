using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Threading.Tasks;
using TorneioDeLuta.Domain.Entities;
using Xunit;

namespace Test.Infrastructure
{
    public class TorneioServiceTest
    {
        Mock<IConfiguration> _configuration;

        [Fact]
        public async Task GetLutadoresAsync_Test()
        {
            _configuration = new Mock<IConfiguration>();

            _configuration.SetupGet(x => x[It.Is<string>(s => s == "Torneio:UrlTorneio")]).Returns("https://apidev-mbb.t-systems.com.br:8443/edgemicro_tsdev/torneioluta/api/competidores");
            _configuration.SetupGet(x => x[It.Is<string>(s => s == "Torneio:Key")]).Returns("29452a07-5ff9-4ad3-b472-c7243f548a33");
            //Arrange
            Torneio dadosTorneio = new Torneio();
            TorneioDeLuta.Infrastructure.Service.TorneioService _torneioService = new TorneioDeLuta.Infrastructure.Service.TorneioService(_configuration.Object);

            // Act
            dadosTorneio.Lutadores = await _torneioService.GetLutadoresAsync();


            //Assert
            Assert.True(dadosTorneio.Lutadores.Count > 0);
        }
    }
}
