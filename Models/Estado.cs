using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClimaTempoSimples.Models
{
    [Table("Estados")]
    public class Estado
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Por favor preencha o {0}")]
        [MaxLength(200, ErrorMessage = "Por favor preencha o {1} com tamanho máximo de {0}")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor preencha o {0}")]
        [MaxLength(2, ErrorMessage = "Por favor preencha o {1} com tamanho máximo de {0}")]
        public string UF { get; set; }

        public virtual List<Cidade> Cidades { get; set; }
    }
}