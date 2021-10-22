using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClimaTempoSimples.Models
{
    public class Estado
    {
        public int EstadoId { get; set; }
        public string EstadoNome { get; set; }

        public string EstadoUF { get; set; }
    }
}