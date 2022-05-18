using System;
using System.Collections.Generic;

namespace IngressoMVC.Models
{
    public class Categoria : IEntidade
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public string Nome { get; set; }
        public List<FilmeCategoria> FilmesCategorias { get; set; }
    }
}
