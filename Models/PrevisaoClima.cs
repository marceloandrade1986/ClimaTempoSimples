using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClimaTempoSimples.Models
{
    public class PrevisaoClima
    {
        public int PrevisaoClimaId { get; set; }
        public string Clima { get; set; }
        public decimal TemperaturaMinima { get; set; }

        public decimal TemperaturaMaxima { get; set; }
    }
}