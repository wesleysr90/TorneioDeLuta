using System;
using System.Collections.Generic;
using System.Text;

namespace TorneioDeLuta.Application.ViewModels
{
    public class LutadorViewModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public List<string> ArtesMarciais { get; set; }
        public int Lutas { get; set; }
        public int Derrotas { get; set; }
        public int Vitorias { get; set; }
        public bool Selecionado { get; set; }
    }
}
