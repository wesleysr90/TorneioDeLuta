using System;
using System.Collections.Generic;
using System.Text;
using TorneioDeLuta.Application.Enum;

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

        public StatusMensagem Status;

        public int TotalSelecionado { get; set; }
    }
}
