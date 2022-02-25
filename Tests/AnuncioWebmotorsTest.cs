using System;
using Xunit;

namespace Tests
{
    public class AnuncioWebmotorsTest : IDisposable
    {
        [Fact]
        public void Inserir_Novo_Anuncio()
        {
            var anuncio = new Anuncio(1, "Chevrolet","Cobalt", 2017,2017, 50000, "Procurando por Chevrolet Cobalt Novos e Usados ano 2017? Na Webmotors você encontra mais de 1.4 MPFI LT 8V FLEX 4P" );

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }

    public class Anuncio
    {

        public Anuncio()
        {
        }
        public Anuncio(int id, string marca, string modelo, int versao, int ano, int quilometragem, string observacao)
        {
            ID = id;
            Marca = marca;
            Modelo = modelo;
            Versao = versao;
            Ano = ano;
            Quilometragem = quilometragem;
            Observacao = observacao;

        }
        public Anuncio(string marca, string modelo, int versao, int ano, int quilometragem, string observacao)
        {
            Marca = marca;
            Modelo = modelo;
            Versao = versao;
            Ano = ano;
            Quilometragem = quilometragem;
            Observacao = observacao;

        }

        public int ID { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Versao { get; set; }
        public int Ano { get; set; }
        public int Quilometragem { get; set; }
        public string Observacao { get; set; }
    }
}
