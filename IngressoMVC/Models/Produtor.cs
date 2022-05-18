using System;
using System.Collections.Generic;

namespace IngressoMVC.Models
{
    public class Produtor : Artista
    {
        public List<Filme> Filmes { get; set; }
    }
}
