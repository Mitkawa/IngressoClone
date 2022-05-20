using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Models
{
    public class FilmeCategoria
    {
        public FilmeCategoria(int categoriaId, int filmeId)
        {
            FilmeId = filmeId;
            CategoriaId = categoriaId;
        }
        [Key]
        public int FilmeId { get; private set; }
        public Filme Filme { get; set; }
        [Key]
        public int CategoriaId { get; private set; }
        public Categoria Categoria { get; set; }
    }
}
