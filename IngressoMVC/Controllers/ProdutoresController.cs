using IngressoMVC.Data;
using IngressoMVC.Models;
using IngressoMVC.Models.ViewModels.RequestDTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Controllers
{
    public class ProdutoresController : Controller
    {
        private IngressoDbContext _context;

        public ProdutoresController(IngressoDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Produtores);
        }

        public IActionResult Detalhes(int id)
        {
            return View(_context.Produtores.Find(id));
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(PostProdutorDTO produtorDto)
        {
            if (!ModelState.IsValid || !produtorDto.FotoPerfilURL.EndsWith(".jpg")) return View();

            Produtor produtor = new Produtor(
                produtorDto.Nome, 
                produtorDto.Bio, 
                produtorDto.FotoPerfilURL);

            _context.Produtores.Add(produtor);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Atualizar(int id)
        {
            //buscar o ator no banco
            //passar o ator na view
            return View();
        }

        public IActionResult Deletar(int id)
        {
            //buscar o ator no banco
            //passar o ator na view
            return View();
        }
    }
}
