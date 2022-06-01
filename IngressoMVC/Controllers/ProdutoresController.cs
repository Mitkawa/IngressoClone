using IngressoMVC.Data;
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
