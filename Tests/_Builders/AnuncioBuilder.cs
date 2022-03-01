using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests._Builders
{
    public class AnuncioBuilder
    {
        private string _Marca;
        private string _Modelo;
        private int _Versao;
        private int _Ano;
        private int _Quilometragem;
        private string _Observacao;
        public static AnuncioBuilder Novo()
        {
            return new AnuncioBuilder();
        }

        public AnuncioBuilder ComMarca(string marca)
        {
            _Marca = marca;
            return this;
        }
        public AnuncioBuilder ComModelo(string modelo)
        {
            _Modelo = modelo;
            return this;
        }
        public AnuncioBuilder ComVersao(int versao)
        {
            _Versao = versao;
            return this;
        }
        public AnuncioBuilder ComAno(int ano)
        {
            _Ano = ano;
            return this;
        }
        public AnuncioBuilder ComQuilometragem(int quilometragem)
        {
            _Quilometragem = quilometragem;
            return this;
        }
        public AnuncioBuilder ComObservacao(string observacao)
        {
            _Observacao = observacao;
            return this;
        }
        public Anuncio Build()
        {
            return new Anuncio(_Marca, _Modelo, _Versao, _Ano, _Quilometragem, _Observacao);
        }
    }
}
