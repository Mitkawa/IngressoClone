using System.Collections.Generic;

namespace IngressoMVC.Models
{
    public class Ator : Artista
    {
        public Ator(string nome, string bio, string fotoPerfilURL) 
            : base(nome, bio, fotoPerfilURL)
        {
        }

        public List<AtorFilme> AtoresFilmes { get; set; }
    }
}
