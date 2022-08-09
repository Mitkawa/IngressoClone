using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Models.ViewModels.RequestDTO
{
    public class PostAtorDTO
    {
        [Required(ErrorMessage = "Nome do Ator é Obrigatório!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Ator deve ter no máximo 50 caracters, e no mínimo 3")]
        public string Nome { get; set; }

        public string Bio { get; set; }

        [Required(ErrorMessage = "Imagem obrigatória")]
        public string FotoPerfilURL { get; set; }
    }
}
