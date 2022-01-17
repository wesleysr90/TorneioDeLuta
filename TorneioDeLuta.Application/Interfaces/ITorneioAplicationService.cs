using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TorneioDeLuta.Application.ViewModels;

namespace TorneioDeLuta.Application.Interfaces
{
    public interface ITorneioAplicationService
    {
        Task<List<LutadorViewModel>> GetLutadoresAsync();
        ResultadoViewModel IniciaTorneio(List<LutadorViewModel> listaDeLutadores);

    }
}
