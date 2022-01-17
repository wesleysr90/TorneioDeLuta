using System;
using System.Collections.Generic;
using System.Text;

namespace TorneioDeLuta.Application.ViewModels
{
    public class TorneioViewModel
    {
        public TorneioViewModel()
        {
            Lutadores = new List<LutadorViewModel>();
        }
        public List<LutadorViewModel> Lutadores { get; set; }
        public string Mensagem { get; set; }
        public int TipoMensagem { get; set; }

        public int TotalSelecionado { get; set; }
    }
}
