using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TorneioDeLuta.Domain.Entities;


namespace TorneioDeLuta.Domain.Interface
{
    public interface ILutadorService
    {
       Task<List<Lutador>> GetLutadoresAsync();
    }
}
