namespace ClimaTempoSimples.Migrations
{
    using ClimaTempoSimples.Enumeradores;
    using ClimaTempoSimples.Models;
    using Microsoft.Ajax.Utilities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.ClimaTempoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Models.ClimaTempoContext context)
        {

            string[] listaEstados = new string[7] { "SÃO PAULO - SP", "RIO DE JANEIRO - RJ", "DISTRITO FEDERAL - DF", "CEARA - CE", "SANTA CATARINA - SC", "RIO GRANDE DO SUL - RS", "PARA - PR" };
            string[] listCidades = new string[21] {"SÃO PAULO - SP", "ATIABAIA - SP", "SÃO BERNARDO DO CAMPO - SP", "RIO DE JANEIRO - RJ", "NITEROI - RJ", "PETROPOLES - RJ","BRASILIA - DF", "ASA SUL - DF", "LAGO NORTE - DF",
                "CRATO - CE", "SOBRAL - CE", "FORTALEZA - CE", "FLORIANOPOLIS - SC", "BLUMENAL - SC", "SÃO JOSÉ - SC", "PORTO ALEGRE - RS", "PELOTAS - RS", "RIO GRANDE DO SUL - RS","BELEM - PR", "CURITIBA - PR", "MARABÁ - PR"
            };

            List<Estado> estados = new List<Estado>();

            listaEstados.ToList().ForEach(itemEstado =>
            {
                string nomeEstado = itemEstado.Split('-')[0].Trim();
                string nomeUf = itemEstado.Split('-')[1].Trim();


                Estado estado = new Estado { Nome = nomeEstado, UF = nomeUf };
                estado.Cidades = new List<Cidade>();

                listCidades.ToList().Where(x => x.Contains(nomeUf))?.ForEach(itemCidade =>
                {

                    Cidade cidade = new Cidade { Nome = itemCidade.Split('-')[0].Trim() };
                    cidade.Previsoes = new List<PrevisaoClima>();

                    Random random = new Random(DateTime.Now.Millisecond);
                    DateTime inicial = DateTime.Now;
                    for (int i = 0; i < 7; i++)
                    {
                        int temperaturaMinima = random.Next(1, 15);
                        int temperaturaMaxima = random.Next(temperaturaMinima + 1, 35);

                        EnumClima clima = EnumClima.Nublado;

                        if (temperaturaMinima <= 12)
                        {
                            clima = EnumClima.Chuva;
                        }

                        if (temperaturaMinima >= 12 && temperaturaMaxima >= 25)
                        {
                            clima = EnumClima.Sol;
                        }

                        if (temperaturaMinima >= 12 && temperaturaMaxima < 25)
                        {
                            clima = EnumClima.Nublado;
                        }

                        if (temperaturaMinima <= 12 && temperaturaMaxima <= 15)
                        {
                            clima = EnumClima.Tempestuoso;
                        }

                        PrevisaoClima previsao = new PrevisaoClima { TemperaturaMaxima = temperaturaMaxima, TemperaturaMinima = temperaturaMinima, Clima = clima, DataPrevisao = inicial.AddDays(i) };
                        cidade.Previsoes.Add(previsao);
                    }

                    estado.Cidades.Add(cidade);
                });
                estados.Add(estado);
            });

            context.Estados.AddRange(estados);           


        }
    }
}
