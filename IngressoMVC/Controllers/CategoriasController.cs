using IngressoMVC.Data;
using IngressoMVC.Models;
using IngressoMVC.Models.ViewModels.RequestDTO;
using Microsoft.AspNetCore.Mvc;

namespace IngressoMVC.Controllers
{
    public class CategoriasController : Controller
    {
        private IngressoDbContext _context;

        public CategoriasController(IngressoDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Categorias);
        }

        public IActionResult Detalhes(int id)
        {
            return View(_context.Categorias.Find(id));
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(PostCategoriaDTO categoriaDto)
        {
            if (!ModelState.IsValid) return View();

            Categoria categoria = new Categoria(categoriaDto.Nome);
            _context.Add(categoria);
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
