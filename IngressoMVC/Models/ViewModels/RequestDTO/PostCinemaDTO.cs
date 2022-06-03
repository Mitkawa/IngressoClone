using System.ComponentModel.DataAnnotations;

namespace IngressoMVC.Models.ViewModels.RequestDTO
{
    public class PostCinemaDTO
    {
        [Required(ErrorMessage ="O nome do Cinema é obrigatório")]
        [StringLength(50, MinimumLength =3, ErrorMessage = "O nome deve ter no minimo 3 e no máximo 50 Caracteres !")]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        [Required(ErrorMessage ="É obrigatório informar a logo do Cinema !")]
        public string LogoURL { get; set; }
    }
}
