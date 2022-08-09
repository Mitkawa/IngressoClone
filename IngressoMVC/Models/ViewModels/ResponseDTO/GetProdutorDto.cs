using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IngressoMVC.Models.ViewModels.ResponseDTO
{
    public class GetProdutorDto
    {
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Biografia")]
        public string Bio { get; set; }

        [Display(Name = "Foto")]
        public string FotoPerfilURL { get; set; }

        public List<string> NomeFilmes { get; set; } 
        public List<string> FotoURLFilmes { get; set; } 
    }
}
