using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PreguicaNews.Models
{
    public class EntertainmentModel
    {
        public int Id { get; set; }
        public string Imagem { get; set; }
        public string Nota { get; set; }
        public string Nome { get; set; }
        public string Resumo { get; set; }

        public EntertainmentModel()
        {
            Id = -1;
            Nome = "Nada";
            Imagem = "Nada";
            Nota = "Nada";
            Resumo = "nada";
        }

        public EntertainmentModel(int id, string imagem, string nota, string nome, string resumo)
        {
            Id = id;
            Imagem = imagem;
            Nota = nota;
            Nome = nome;
            Resumo = resumo;
        }
    }
}