using System.Collections.Generic;

namespace IngressoMVC.Models.ViewModels.RequestDTO
{
    public class PostFilmeDropdownDTO
    {
        public PostFilmeDropdownDTO()
        {
            Cinemas = new List<Cinema>();
            Produtores = new List<Produtor>();
            Atores = new List<Ator>();
            Categorias = new List<Categoria>();
        }

        public List<Cinema> Cinemas { get; set; }
        public List<Produtor> Produtores { get; set; }
        public List<Ator> Atores { get; set; }
        public List<Categoria> Categorias { get; set; }
    }
}
