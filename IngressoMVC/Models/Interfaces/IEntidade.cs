using System;

namespace IngressoMVC.Models.Interfaces
{
    public interface IEntidade
    {
        int Id { get; }
        DateTime DataCadastro { get; }
        DateTime DataAlteracao { get; }
    }
}
