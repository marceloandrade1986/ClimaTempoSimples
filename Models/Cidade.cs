using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClimaTempoSimples.Models
{
    [Table("Cidades")]
    public class Cidade
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Por favor preencha o {0}")]
        [MaxLength(200, ErrorMessage = "Por favor preencha o {1} com tamanho máximo de {0}")]
        public string Nome { get; set; }
        
        public virtual Estado Estado { get; set; }

        [Required(ErrorMessage = "Por favor preencha o {0}")]        
        public int EstadoID { get; set; }

        public virtual List<PrevisaoClima> Previsoes { get; set; }
    }
}