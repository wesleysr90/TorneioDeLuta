using System;
using System.Collections.Generic;
using System.Text;

namespace TorneioDeLuta.Application.ViewModels
{
    public class ResultadoViewModel
    {
        public string Primeiro { get; set; }
        public string Segundo { get; set; }
        public string Terceiro { get; set; }

        public string Mensagem { get; set; }
        public int TipoMensagem { get; set; }

    }
}
