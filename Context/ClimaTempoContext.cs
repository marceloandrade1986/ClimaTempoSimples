using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ClimaTempoSimples.Models
{
    public class ClimaTempoContext : DbContext
    {
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Cidade> Cidades { get; set; }  
        public virtual DbSet<PrevisaoClima> PrevisaoClimas { get; set; }

        public ClimaTempoContext() :base("Default")
        {

        }
    }
}