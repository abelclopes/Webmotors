using ExpectedObjects;
using System;
using Tests._Builders;
using Tests._Util;
using Webmotors.Domain;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{


    public class AnuncioWebmotorsTest : IDisposable
    {
        private readonly ITestOutputHelper _output;

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

    
}
