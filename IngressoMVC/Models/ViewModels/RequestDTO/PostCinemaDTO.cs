using System.ComponentModel.DataAnnotations;

namespace IngressoMVC.Models.ViewModels.RequestDTO
{
    public class PostCinemaDTO
    {
        [Required, StringLength(100, MinimumLength = 1, ErrorMessage = "Nome do cinema é obrigatório")]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "A LOGO do Cinema é obrigatória")]
        public string LogoURL { get; set; }
    }
}
