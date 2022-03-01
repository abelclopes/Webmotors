using ExpectedObjects;
using System;
using Tests._Builders;
using Tests._Util;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{


    public class AnuncioWebmotorsTest : IDisposable
    {
        private readonly ITestOutputHelper _output;

        private readonly int _ID;
        private readonly string _Marca;
        private readonly string _Modelo;
        private readonly int _Versao;
        private readonly int _Ano;
        private readonly int _Quilometragem;
        private readonly string _Observacao;

        public AnuncioWebmotorsTest(ITestOutputHelper output)
        {

            _output = output;
            _output.WriteLine("Construtor foi executado");



            _ID = 1;
            _Marca = "Chevrolet";
            _Modelo = "Cobalt";
            _Versao = 2017;
            _Ano = 2017;
            _Quilometragem = 50000;
            _Observacao = "Procurando por Chevrolet Cobalt Novos e Usados ano 2017? Na Webmotors você encontra mais de 1.4 MPFI LT 8V FLEX 4P";
        }


        [Fact]
        public void Inserir_Novo_Anuncio()
        {
            var anuncioEsperado = new { Marca = _Marca, Modelo = _Modelo, Versao = _Versao, Ano = _Ano, Quilometragem = _Quilometragem, Observacao = _Observacao };

            var anuncio = new Anuncio(_Marca, _Modelo, _Versao, _Ano, _Quilometragem, _Observacao);
            anuncioEsperado.ToExpectedObject().ShouldMatch(anuncio);
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void MarcaIsNotNullOrEmpyt(string marcaIsInvalid)
        {
            Assert.Throws<ArgumentException>(() =>
                new Anuncio(marcaIsInvalid, _Modelo, _Versao, _Ano, _Quilometragem, _Observacao)
            ).CompareMessage("Marca é inválido");
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ModeloIsNotNullOrEmpyt(string modeloIsInvalid)
        {
            Assert.Throws<ArgumentException>(() =>
                new Anuncio(_Marca, modeloIsInvalid, _Versao, _Ano, _Quilometragem, _Observacao)
            ).CompareMessage("Modelo é inválido");
        }

        public void Dispose()
        {
            _output.WriteLine("Dispose sendo executado");
        }

    }

    public class Anuncio
    {

        public Anuncio()
        {
        }
        public Anuncio(string marca, string modelo, int versao, int ano, int quilometragem, string observacao)
        {
            if (string.IsNullOrEmpty(marca))
                throw new ArgumentException("Marca é inválido");
            if (string.IsNullOrEmpty(modelo))
                throw new ArgumentException("Modelo é inválido");
            if (versao < 1900)
                throw new ArgumentException("Versão é inválido");
            if (ano < 1900)
                throw new ArgumentException("Ano é inválido");
            if (string.IsNullOrEmpty(observacao))
                throw new ArgumentException("Observação é inválido");

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
