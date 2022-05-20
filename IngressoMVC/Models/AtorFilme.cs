using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Models
{

    public class AtorFilme
    {
        public AtorFilme(int atorId, int filmeId) 
        {
            AtorId = atorId;
            FilmeId = filmeId;
        }
        [Key]
        public int AtorId { get; private set; }
        public Ator Ator { get; set; }
        
        [Key]
        public int FilmeId { get; private set; }
        public Filme Filme { get; set; }
    }
}
