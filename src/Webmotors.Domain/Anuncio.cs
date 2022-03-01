using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webmotors.Domain
{
    public class Anuncio
    {
        public IList<Event> Events { get; private set; }

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
        [Key]
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Versao { get; set; }
        public int Ano { get; set; }
        public int Quilometragem { get; set; }
        public string Observacao { get; set; }





        public Anuncio Atualizar(Anuncio anuncio)
        {
            var atualizado = new Anuncio(anuncio.Marca,anuncio.Modelo,anuncio.Ano, anuncio.Versao, anuncio.Quilometragem,anuncio.Observacao);
            atualizado.Id = anuncio.Id;
            return atualizado;
        }
    }

}
