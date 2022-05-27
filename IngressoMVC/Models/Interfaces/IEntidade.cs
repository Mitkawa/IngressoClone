using System;

namespace IngressoMVC.Models.Interfaces
{
    public interface IEntidade
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
