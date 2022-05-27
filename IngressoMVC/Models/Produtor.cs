using System.Collections.Generic;

namespace IngressoMVC.Models
{
    public class Produtor : Artista
    {
        public Produtor(string nome, string bio, string fotoPerfilURL) 
            : base(nome, bio, fotoPerfilURL)
        {
        }

        public List<Filme> Filmes { get; set; }
    }
}
