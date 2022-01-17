using System;
using System.Collections.Generic;
using System.Text;

namespace TorneioDeLuta.Domain.Entities
{
    public class Grupo
    {

        public Grupo()
        {
            Lutadores = new List<Lutador>();
        }

        public List<Lutador> Lutadores { get; set; }
        public int IdGrupo { get; set; }



    }
}
