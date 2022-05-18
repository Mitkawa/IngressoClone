using System;
using System.ComponentModel.DataAnnotations;

namespace IngressoMVC.Models
{
    public interface IEntidade
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
