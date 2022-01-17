using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TorneioDeLuta.Application.Mappings;
using TorneioDeLuta.Application.Services;
using TorneioDeLuta.Application.ViewModels;
using TorneioDeLuta.Domain.Entities;
using Xunit;

namespace Test.Application
{
    public class TorneioAplicationServiceTest
    {
        public Mock<TorneioDeLuta.Domain.Interface.ITorneioService> _torneioService;
        Mock<IConfiguration> _configuration;
        Mock<IServiceCollection> _services;
        public IMapper _mapper;
        public Startup setup = null;





        [Fact]
        public async Task GetLutadoresAsync_Test()
        {
            //Arrange
            _configuration = new Mock<IConfiguration>();
            _services = new Mock<IServiceCollection>();
            _torneioService = new Mock<TorneioDeLuta.Domain.Interface.ITorneioService>();

            string json = "[{'id':37,'nome':'Muhammad Ali','idade':74,'artesMarciais':['Boxe'],'lutas':61,'derrotas':5,'vitorias':56},{'id':36,'nome':'Chuck Liddell','idade':49,'artesMarciais':['Wrestling','Kempo','Kickboxing'],'lutas':30,'derrotas':9,'vitorias':21},{'id':35,'nome':'Sugar Ray Robinson','idade':67,'artesMarciais':['Boxe'],'lutas':200,'derrotas':19,'vitorias':173},{'id':34,'nome':'Anderson Silva','idade':43,'artesMarciais':['Boxe','Muay Thai','Jiu-Jitsu','Taekwondo','Capoeira'],'lutas':44,'derrotas':9,'vitorias':34},{'id':33,'nome':'George Foreman','idade':70,'artesMarciais':['Boxe'],'lutas':81,'derrotas':5,'vitorias':76},{'id':32,'nome':'Sugar Ray Leonard','idade':62,'artesMarciais':['Boxe'],'lutas':40,'derrotas':3,'vitorias':36},{'id':31,'nome':'Jon Jones','idade':31,'artesMarciais':['Wrestling','Jiu-Jitsu'],'lutas':25,'derrotas':1,'vitorias':23},{'id':30,'nome':'Rocky Marciano','idade':45,'artesMarciais':['Boxe'],'lutas':49,'derrotas':0,'vitorias':49},{'id':29,'nome':'Vitor Belfort','idade':41,'artesMarciais':['Boxe','Jiu-Jitsu','Muay Thai','Jud�'],'lutas':40,'derrotas':14,'vitorias':26},{'id':28,'nome':'Floyd MayweatherJr.','idade':41,'artesMarciais':['Boxe'],'lutas':50,'derrotas':0,'vitorias':50},{'id':27,'nome':'Lyoto Machida','idade':40,'artesMarciais':['Karat�','Shotokan','Jiu-Jitsu','Capoeira'],'lutas':33,'derrotas':8,'vitorias':25},{'id':26,'nome':'Cain Velasquez','idade':36,'artesMarciais':['Boxe','Jiu-j�tsu','Kickboxing','Muay Thai'],'lutas':17,'derrotas':3,'vitorias':14},{'id':25,'nome':'Cigano','idade':35,'artesMarciais':['Boxe','Jiu-j�tsu'],'lutas':25,'derrotas':5,'vitorias':20},{'id':24,'nome':'Jacar�','idade':39,'artesMarciais':['Jiu-j�tsu'],'lutas':32,'derrotas':6,'vitorias':26},{'id':23,'nome':'Chael Sonnen','idade':41,'artesMarciais':['Greco-romana'],'lutas':47,'derrotas':16,'vitorias':30},{'id':22,'nome':'George Saint Pierre','idade':37,'artesMarciais':['Boxe','Jiu-j�tsu','Kyokushin','Muay thai','Jiu-jitsu'],'lutas':28,'derrotas':2,'vitorias':26},{'id':21,'nome':'Matt Hughes','idade':45,'artesMarciais':['Artes marciais mistas'],'lutas':54,'derrotas':9,'vitorias':45},{'id':20,'nome':'Demetrious Johnson','idade':32,'artesMarciais':['Ol�mpica estilo livre'],'lutas':31,'derrotas':3,'vitorias':27},{'id':19,'nome':'Evander Holyfield','idade':56,'artesMarciais':['Boxe'],'lutas':57,'derrotas':10,'vitorias':44},{'id':18,'nome':'Mike Tyson','idade':52,'artesMarciais':['Boxe'],'lutas':58,'derrotas':6,'vitorias':50},{'id':17,'nome':'Manny Pacquiao','idade':40,'artesMarciais':['Boxe'],'lutas':70,'derrotas':7,'vitorias':61},{'id':16,'nome':'Eder Jofre','idade':82,'artesMarciais':['Boxe'],'lutas':81,'derrotas':2,'vitorias':77},{'id':15,'nome':'Acelino Pop� Freitas','idade':43,'artesMarciais':['Boxe'],'lutas':43,'derrotas':2,'vitorias':41},{'id':14,'nome':'Micky Ward','idade':53,'artesMarciais':['Boxe'],'lutas':51,'derrotas':13,'vitorias':38},{'id':13,'nome':'Joe Louis','idade':66,'artesMarciais':['Boxe'],'lutas':69,'derrotas':3,'vitorias':66},{'id':12,'nome':'Roberto Duran','idade':67,'artesMarciais':['Boxe'],'lutas':119,'derrotas':16,'vitorias':103},{'id':11,'nome':'Julio Cesar Chavez','idade':56,'artesMarciais':['Boxe'],'lutas':115,'derrotas':6,'vitorias':107},{'id':10,'nome':'Wanderlei Silva','idade':42,'artesMarciais':['Muay Thay','Jiu-Jitsu'],'lutas':50,'derrotas':13,'vitorias':35},{'id':9,'nome':'Jos� Aldo','idade':32,'artesMarciais':['Muay Thai','Jiu-Jitsu'],'lutas':32,'derrotas':4,'vitorias':28},{'id':8,'nome':'Conor McGregor','idade':30,'artesMarciais':['Boxe','Jiu-j�tsu','Kickboxing','Capoeira','Karat�','Taekwondo'],'lutas':25,'derrotas':4,'vitorias':21},{'id':7,'nome':'Rafael dos Anjos','idade':34,'artesMarciais':['Boxe','Jiu-j�tsu','Muay thai'],'lutas':39,'derrotas':11,'vitorias':28},{'id':6,'nome':'Thiago Marreta','idade':35,'artesMarciais':['Muay thai','Capoeira'],'lutas':26,'derrotas':5,'vitorias':21},{'id':5,'nome':'Henry Cejudo','idade':32,'artesMarciais':['Ol�mpica estilo livre'],'lutas':16,'derrotas':2,'vitorias':14},{'id':4,'nome':'Tyron Woodley','idade':36,'artesMarciais':['Wrestling','KickBoxing','Boxe'],'lutas':23,'derrotas':3,'vitorias':19},{'id':3,'nome':'Rocky Balboa','idade':42,'artesMarciais':['Boxe'],'lutas':81,'derrotas':23,'vitorias':57},{'id':2,'nome':'Apollo Creed','idade':43,'artesMarciais':['Boxe'],'lutas':47,'derrotas':1,'vitorias':46},{'id':1,'nome':'Adonis Creed','idade':32,'artesMarciais':['Boxe'],'lutas':26,'derrotas':1,'vitorias':25}]";

            List<Lutador> lista = JsonConvert.DeserializeObject<List<Lutador>>(json);
          

            _torneioService.Setup(x => x.GetLutadoresAsync()).ReturnsAsync(lista);

            setup = new Startup(_configuration.Object);

            setup.ConfigureServices(_services.Object);


            var profile = new DomainToViewModelMappingProfile();

            _mapper = new MapperConfiguration(x => x.AddProfile(profile)).CreateMapper();
            // Act
            TorneioDeLuta.Application.Services.TorneioAplicationService torneioService = new TorneioAplicationService(_mapper, _torneioService.Object);



            var result = await torneioService.GetLutadoresAsync();
            //Assert
            Assert.True(result.Count > 0);


        }


        [Fact]
        public async Task InicioTorneio_Test()
        {
            //Arrange
            _configuration = new Mock<IConfiguration>();
            _services = new Mock<IServiceCollection>();
            _torneioService = new Mock<TorneioDeLuta.Domain.Interface.ITorneioService>();

            var profile = new DomainToViewModelMappingProfile();
            

            _mapper = new MapperConfiguration(x => x.AddProfile(profile)).CreateMapper();
            

            string json = "[{'id':37,'nome':'Muhammad Ali','idade':74,'artesMarciais':['Boxe'],'lutas':61,'derrotas':5,'vitorias':56},{'id':36,'nome':'Chuck Liddell','idade':49,'artesMarciais':['Wrestling','Kempo','Kickboxing'],'lutas':30,'derrotas':9,'vitorias':21},{'id':35,'nome':'Sugar Ray Robinson','idade':67,'artesMarciais':['Boxe'],'lutas':200,'derrotas':19,'vitorias':173},{'id':34,'nome':'Anderson Silva','idade':43,'artesMarciais':['Boxe','Muay Thai','Jiu-Jitsu','Taekwondo','Capoeira'],'lutas':44,'derrotas':9,'vitorias':34},{'id':33,'nome':'George Foreman','idade':70,'artesMarciais':['Boxe'],'lutas':81,'derrotas':5,'vitorias':76},{'id':32,'nome':'Sugar Ray Leonard','idade':62,'artesMarciais':['Boxe'],'lutas':40,'derrotas':3,'vitorias':36},{'id':31,'nome':'Jon Jones','idade':31,'artesMarciais':['Wrestling','Jiu-Jitsu'],'lutas':25,'derrotas':1,'vitorias':23},{'id':30,'nome':'Rocky Marciano','idade':45,'artesMarciais':['Boxe'],'lutas':49,'derrotas':0,'vitorias':49},{'id':29,'nome':'Vitor Belfort','idade':41,'artesMarciais':['Boxe','Jiu-Jitsu','Muay Thai','Jud�'],'lutas':40,'derrotas':14,'vitorias':26},{'id':28,'nome':'Floyd MayweatherJr.','idade':41,'artesMarciais':['Boxe'],'lutas':50,'derrotas':0,'vitorias':50},{'id':27,'nome':'Lyoto Machida','idade':40,'artesMarciais':['Karat�','Shotokan','Jiu-Jitsu','Capoeira'],'lutas':33,'derrotas':8,'vitorias':25},{'id':26,'nome':'Cain Velasquez','idade':36,'artesMarciais':['Boxe','Jiu-j�tsu','Kickboxing','Muay Thai'],'lutas':17,'derrotas':3,'vitorias':14},{'id':25,'nome':'Cigano','idade':35,'artesMarciais':['Boxe','Jiu-j�tsu'],'lutas':25,'derrotas':5,'vitorias':20},{'id':24,'nome':'Jacar�','idade':39,'artesMarciais':['Jiu-j�tsu'],'lutas':32,'derrotas':6,'vitorias':26},{'id':23,'nome':'Chael Sonnen','idade':41,'artesMarciais':['Greco-romana'],'lutas':47,'derrotas':16,'vitorias':30},{'id':22,'nome':'George Saint Pierre','idade':37,'artesMarciais':['Boxe','Jiu-j�tsu','Kyokushin','Muay thai','Jiu-jitsu'],'lutas':28,'derrotas':2,'vitorias':26},{'id':21,'nome':'Matt Hughes','idade':45,'artesMarciais':['Artes marciais mistas'],'lutas':54,'derrotas':9,'vitorias':45},{'id':20,'nome':'Demetrious Johnson','idade':32,'artesMarciais':['Ol�mpica estilo livre'],'lutas':31,'derrotas':3,'vitorias':27},{'id':19,'nome':'Evander Holyfield','idade':56,'artesMarciais':['Boxe'],'lutas':57,'derrotas':10,'vitorias':44},{'id':18,'nome':'Mike Tyson','idade':52,'artesMarciais':['Boxe'],'lutas':58,'derrotas':6,'vitorias':50},{'id':17,'nome':'Manny Pacquiao','idade':40,'artesMarciais':['Boxe'],'lutas':70,'derrotas':7,'vitorias':61},{'id':16,'nome':'Eder Jofre','idade':82,'artesMarciais':['Boxe'],'lutas':81,'derrotas':2,'vitorias':77},{'id':15,'nome':'Acelino Pop� Freitas','idade':43,'artesMarciais':['Boxe'],'lutas':43,'derrotas':2,'vitorias':41},{'id':14,'nome':'Micky Ward','idade':53,'artesMarciais':['Boxe'],'lutas':51,'derrotas':13,'vitorias':38},{'id':13,'nome':'Joe Louis','idade':66,'artesMarciais':['Boxe'],'lutas':69,'derrotas':3,'vitorias':66},{'id':12,'nome':'Roberto Duran','idade':67,'artesMarciais':['Boxe'],'lutas':119,'derrotas':16,'vitorias':103},{'id':11,'nome':'Julio Cesar Chavez','idade':56,'artesMarciais':['Boxe'],'lutas':115,'derrotas':6,'vitorias':107},{'id':10,'nome':'Wanderlei Silva','idade':42,'artesMarciais':['Muay Thay','Jiu-Jitsu'],'lutas':50,'derrotas':13,'vitorias':35},{'id':9,'nome':'Jos� Aldo','idade':32,'artesMarciais':['Muay Thai','Jiu-Jitsu'],'lutas':32,'derrotas':4,'vitorias':28},{'id':8,'nome':'Conor McGregor','idade':30,'artesMarciais':['Boxe','Jiu-j�tsu','Kickboxing','Capoeira','Karat�','Taekwondo'],'lutas':25,'derrotas':4,'vitorias':21},{'id':7,'nome':'Rafael dos Anjos','idade':34,'artesMarciais':['Boxe','Jiu-j�tsu','Muay thai'],'lutas':39,'derrotas':11,'vitorias':28},{'id':6,'nome':'Thiago Marreta','idade':35,'artesMarciais':['Muay thai','Capoeira'],'lutas':26,'derrotas':5,'vitorias':21},{'id':5,'nome':'Henry Cejudo','idade':32,'artesMarciais':['Ol�mpica estilo livre'],'lutas':16,'derrotas':2,'vitorias':14},{'id':4,'nome':'Tyron Woodley','idade':36,'artesMarciais':['Wrestling','KickBoxing','Boxe'],'lutas':23,'derrotas':3,'vitorias':19},{'id':3,'nome':'Rocky Balboa','idade':42,'artesMarciais':['Boxe'],'lutas':81,'derrotas':23,'vitorias':57},{'id':2,'nome':'Apollo Creed','idade':43,'artesMarciais':['Boxe'],'lutas':47,'derrotas':1,'vitorias':46},{'id':1,'nome':'Adonis Creed','idade':32,'artesMarciais':['Boxe'],'lutas':26,'derrotas':1,'vitorias':25}]";

            List<Lutador> teste = JsonConvert.DeserializeObject<List<Lutador>>(json);


           var viewModel = _mapper.Map<List<LutadorViewModel>>(teste);

            setup = new Startup(_configuration.Object);

            setup.ConfigureServices(_services.Object);


            
            // Act
            TorneioDeLuta.Application.Services.TorneioAplicationService torneioService = new TorneioAplicationService(_mapper, _torneioService.Object);

            viewModel.RemoveRange(20, viewModel.Count - 20);

            var result = torneioService.IniciaTorneio(viewModel);
            //Assert
            Assert.True(!string.IsNullOrEmpty(result.Primeiro));

            Assert.True(!string.IsNullOrEmpty(result.Segundo));

            Assert.True(!string.IsNullOrEmpty(result.Terceiro));
        }
    }
}
