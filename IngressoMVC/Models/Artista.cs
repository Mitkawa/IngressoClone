using System;

namespace IngressoMVC.Models
{
    public class Artista : IEntidade
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public string Nome { get; set; }
        public string Bio { get; set; }
        public string FotoPerfilURL { get; set; }
    }
}
