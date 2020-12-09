using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PreguicaNews.Models
{
    public class EntertainmentModel
    {
        public int Id { get; set; }
        [Required]
        public string Imagem { get; set; }
        [Required]
        public string Nota { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
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