using IngressoMVC.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace IngressoMVC.Models
{
    public class Cinema : IEntidade
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string LogoURL { get; set; }

        public List<Filme> Filmes { get; set; }
    }
}
