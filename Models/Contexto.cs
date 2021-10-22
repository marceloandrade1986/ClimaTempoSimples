using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ClimaTempoSimples.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Cidade> Cidades { get; set; }  
        public DbSet<PrevisaoClima> PrevisaoClimas { get; set; }

        public Contexto()
        {

        }
    }
}