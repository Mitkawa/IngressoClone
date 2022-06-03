using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Models.ViewModels.RequestDTO
{
    public class PostProdutorDTO
    {   
        [Required(ErrorMessage = "O nome do Produtor é obrigatório !")]
        [StringLength(50,MinimumLength =3, ErrorMessage ="O nome deve ter no minimo 3 e no máximo 50 Caracteres !")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "A biografia do Produtor é obrigatória !")]
        public string Bio { get; set; }
        [Required(ErrorMessage ="Foto do produtor é obrigatória !")]
        public string FotoPerfilURL { get; set; }
    }
}
