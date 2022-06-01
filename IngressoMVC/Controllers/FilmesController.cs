using IngressoMVC.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Controllers
{
    public class FilmesController : Controller
    {
        private IngressoDbContext _context;
        public FilmesController(IngressoDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Filmes);
        }

        public IActionResult Detalhes(int id)
        {
            return View(_context.Filmes.Find(id));
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Atualizar(int id)
        {
            return View();
        }

        public IActionResult Deletar(int id)
        {
            return View();
        }
    }
}
