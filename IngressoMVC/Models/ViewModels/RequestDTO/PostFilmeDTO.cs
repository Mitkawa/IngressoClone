using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IngressoMVC.Models.ViewModels.RequestDTO
{
    public class PostFilmeDTO
    {
        [Display(Name = "Título")]
        [Required(ErrorMessage = "O título é obrigatório!")]
        public string Titulo { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "A descrição é obrigatória!")]
        public string Descricao { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "O Preço é obrigatório!")]
        public decimal Preco { get; set; }

        [Display(Name = "Imagem")]
        [Required(ErrorMessage = "A imagem é obrigatóra!")]
        public string ImagemURL { get; set; }

        [Display(Name = "Estréia")]
        [Required(ErrorMessage = "Estréia é obrigatória!")]
        public DateTime DataLancamento { get; set; }

        [Display(Name = "Encerramento")]
        [Required(ErrorMessage = "Encerramento é obrigatório!")]
        public DateTime DataEncerramento { get; set; }

        #region relacionamentos
        [Display(Name = "Informe o Cinema")]
        [Required(ErrorMessage = "Cinema é Obrigatório")]
        public int CinemaId { get; set; }

        [Display(Name = "Informe o Produtor")]
        [Required(ErrorMessage = "Produtor é Obrigatório")]
        public int ProdutorId { get; set; }

        [Display(Name = "Informe o(s) Ator(es)")]
        [Required(ErrorMessage = "Ator(es) é Obrigatório")]
        public List<int> AtoresId { get; set; }

        [Display(Name = "Informe a(s) Categoria(s)")]
        [Required(ErrorMessage = "Categoria(s) é Obrigatório")]
        public List<int> CategoriasId { get; set; }
        #endregion
    }
}
