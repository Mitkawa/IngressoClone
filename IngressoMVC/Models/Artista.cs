using IngressoMVC.Models.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace IngressoMVC.Models
{
    public abstract class Artista : IEntidade
    {
        protected Artista(string nome, string bio, string fotoPerfilURL)
        {
            DataCadastro = DateTime.Now;
            DataAlteracao = DataCadastro;
            Nome = nome;
            Bio = bio;
            FotoPerfilURL = fotoPerfilURL;
        }

        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; private set; }

        [Display(Name = "Biografia")]
        public string Bio { get; private set; }

        [Display(Name = "Foto")]
        public string FotoPerfilURL { get; private set; }

        public void AtualizarDados(string nome, string bio, string fotoPerfilURL)
        {
            Nome = nome;
            Bio = bio;
            FotoPerfilURL = fotoPerfilURL;
            DataAlteracao = System.DateTime.Now;
        }
    }
}
