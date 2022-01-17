using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorneioDeLuta.Application.Interfaces;
using TorneioDeLuta.Application.ViewModels;
using TorneioDeLuta.Domain.Entities;

namespace TorneioDeLuta.Application.Services
{
    public class TorneioAplicationService : ITorneioAplicationService
    {
        private readonly Domain.Interface.ITorneioService _torneioService;
        private readonly IMapper _mapper;
        private List<Domain.Entities.Lutador> _lutadoresCarregados = null;
        public TorneioAplicationService(IMapper mapper, TorneioDeLuta.Domain.Interface.ITorneioService torneioService)
        {
            _mapper = mapper;
            _torneioService = torneioService;
        }


        public async Task<List<LutadorViewModel>> GetLutadoresAsync()
        {
            try
            {
                _lutadoresCarregados = await _torneioService.GetLutadoresAsync();

                return _mapper.Map<List<LutadorViewModel>>(_lutadoresCarregados);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ResultadoViewModel IniciaTorneio(List<LutadorViewModel> listaDeLutadores)
        {
            try
            {
                var lutadoresEntidade = _mapper.Map<List<Domain.Entities.Lutador>>(listaDeLutadores).ToList();



                var listaOrdenada = lutadoresEntidade.OrderBy(x => x.Idade).ToList();



                Torneio torneio = new Torneio();
                torneio.Lutadores = listaOrdenada;

                torneio.IniciarTorneio();

                var result = _mapper.Map<ResultadoViewModel>(torneio.vencedores);

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
