using System.ComponentModel.DataAnnotations;

namespace IngressoMVC.Models.ViewModels.RequestDTO
{
    public class PostCategoriaDTO
    {
        [Required(ErrorMessage ="Campo obrigatório !")]
        public string Nome { get; set; }
    }
}
