using System;
using System.Collections.Generic;
using System.Text;

namespace TorneioDeLuta.Domain.Entities
{
    public class Lutador
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public List<string> ArtesMarciais { get; set; }
        public int Lutas { get; set; }
        public int Derrotas { get; set; }
        public int Vitorias { get; set; }

        public int VitoriasNoTorneio { get; set; }

        public int Pontuacao()
        {

            return (int)(((double)Vitorias / (double)Lutas) * 100);
        }

        public int TotalArtesMarciais()
        {
            return ArtesMarciais == null ? 0 : this.ArtesMarciais.Count;
        }

    }
}
