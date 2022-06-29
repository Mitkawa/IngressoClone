using IngressoMVC.Data;
using IngressoMVC.Models;
using IngressoMVC.Models.ViewModels.RequestDTO;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace IngressoMVC.Controllers
{
    public class CategoriasController : Controller
    {
        private IngressoDbContext _context;

        public CategoriasController(IngressoDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() => View(_context.Categorias);
        

        public IActionResult Detalhes(int id)=>View(_context.Categorias.Find(id));


        public IActionResult Criar() => View();

        [HttpPost]
        public IActionResult Criar(PostCategoriaDTO categoriaDto)
        {
            if(!ModelState.IsValid)
                return View(categoriaDto);

            Categoria categoria = new Categoria(categoriaDto.Nome);
            _context.Add(categoria);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Atualizar(int id)
        {
            if (id == null) 
                return View();

            //buscar o categoria no banco
            var result = _context.Categorias.FirstOrDefault(x =>x.Id==id);

            if (result == null)
                return View();
            //passar o ator na view
            return View(result);
        }

        [HttpPost]
        public IActionResult Atualizar(int id, PostCategoriaDTO categoriaDTO) 
        {
            var categoria = _context.Categorias.FirstOrDefault(c => c.Id == id);

            categoria.AtualizarCategoria(categoriaDTO.Nome);
            _context.Update(categoria);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Deletar(int id)
        {
            //buscar o ator no banco
            var result = _context.Categorias.FirstOrDefault(a => a.Id == id);

            if (id == null) 
                return View();
            //passar o ator na view
            return View(result);
        }

        [HttpPost,]

        public IActionResult ConfirmarDeletar(int id)
        {
            var result = _context.Categorias.FirstOrDefault(a => a.Id == id);
            _context.Categorias.Remove(result);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
