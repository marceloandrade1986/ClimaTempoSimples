using ClimaTempoSimples.Enumeradores;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClimaTempoSimples.Models
{
    [Table("PrevisaoClima")]
    public class PrevisaoClima
    {
        [Key]
        public int ID { get; set; }
        public EnumClima Clima { get; set; }
        public decimal TemperaturaMinima { get; set; }
        public decimal TemperaturaMaxima { get; set; }
        public DateTime DataPrevisao { get; set; }
        public virtual Cidade Cidade { get; set; }
        [Required(ErrorMessage = "Por favor preencha a {0}")]
        [Display(Name = "Cidade")]
        public int CidadeID { get; set; }
    }
}