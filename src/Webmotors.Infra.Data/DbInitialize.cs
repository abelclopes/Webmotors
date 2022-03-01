using System;
using System.Collections.Generic;
using System.Linq;
using Webmotors.Domain;
using Webmotors.Domain.Interfaces;

namespace Webmotors.infra
{
    public static class DbInitialize
    {
        public static void Seed(this IContext context)
        {
            context.Database.EnsureCreated();
            var anuncios = new List<Anuncio>();
            if (!context.Anuncios.Any())
            {
                for (var i = 0; i < 3; i++)
                {
                    var marca = RandMarca(i);
                    var modelo = RandModelo(i);
                    var ano = 2017;
                    var versao = 2017;
                    var quilometragem = 500000;
                    var observacao = "teste observação";
                    var anuncio = new Anuncio(
                        marca,
                        modelo,
                        versao,
                        ano,
                        quilometragem,
                        observacao
                    );
                    anuncios.Add(anuncio);
                    context.Anuncios.Add(anuncio);
                    context.SaveChanges();
                }
            }
        }
        private static string RandMarca(int leng = 3)
        {
            string[] marcaNames = new string[3] { "Ford", "GM", "Toyota" };

            Random rand = new Random(DateTime.Now.Second);
            return marcaNames[rand.Next(0, marcaNames.Length - 1)];


        }
        private static string RandModelo(int leng = 3)
        {
            string[] modeloNames = new string[3] { "Corsa", "Eco Sport", "Etios" };

            Random rand = new Random(DateTime.Now.Second);
            return modeloNames[rand.Next(0, modeloNames.Length - 1)];


        }
    }
}
