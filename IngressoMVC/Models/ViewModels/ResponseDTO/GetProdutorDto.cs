using System.Collections.Generic;

namespace IngressoMVC.Models.ViewModels.ResponseDTO
{
    public class GetProdutorDto
    {
        public string Nome { get; set; }
        public string Bio { get; set; }
        public string FotoPerfilURL { get; set; }
        public List<string> TituloFilmes { get; set; }
        public List<string> FilmeFotoURL { get; set; }
    }
}
