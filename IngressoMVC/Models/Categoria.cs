using IngressoMVC.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace IngressoMVC.Models
{
    public class Categoria : IEntidade
    {
        public Categoria(string nome)
        {
            Nome = nome;
        }
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public string Nome { get; private set; }
        public List<FilmeCategoria> FilmesCategorias { get; set; }
    }
}
