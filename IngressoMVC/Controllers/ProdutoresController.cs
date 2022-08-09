using IngressoMVC.Data;
using IngressoMVC.Models;
using IngressoMVC.Models.ViewModels.RequestDTO;
using IngressoMVC.Models.ViewModels.ResponseDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace IngressoMVC.Controllers
{
    public class ProdutoresController : Controller
    {
        private IngressoDbContext _context;

        public ProdutoresController(IngressoDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() => View(_context.Produtores);

        public IActionResult Detalhes(int id)
        {
            var resultado = _context.Produtores.Include(p => p.Filmes).FirstOrDefault(p => p.Id == id);

            if (resultado == null)
                return View("NotFound");            

            return View(resultado);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(PostProdutorDTO produtorDto)
        {
            if(!ModelState.IsValid)
                return View(produtorDto);

            Produtor produtor = new Produtor(
                produtorDto.Nome, 
                produtorDto.Bio, 
                produtorDto.FotoPerfilURL);

            _context.Produtores.Add(produtor);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Atualizar(int? id)
        {
            if(id == null)
                return NotFound();

            var result = _context.Produtores.FirstOrDefault(p => p.Id == id);
            
            if(result == null)
                return View();

            return View(result);
        }

        [HttpPost]
        public IActionResult Atualizar(int id, PostProdutorDTO produtorDTO)
        {
            var produtor = _context.Produtores.FirstOrDefault(p => p.Id == id);

            if(!ModelState.IsValid)
                return View(produtor);

            produtor.AtualizarDados(produtorDTO.Nome, produtorDTO.Bio, produtorDTO.FotoPerfilURL);

            _context.Update(produtor);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Deletar(int id)
        {
            var result = _context.Produtores.FirstOrDefault(p => p.Id == id);

            if(result == null)
                return View();

            return View(result);
        }

        [HttpPost]
        public IActionResult ConfirmarDeletar(int id)
        {
            var result = _context.Produtores.FirstOrDefault(p => p.Id == id);
            
            _context.Produtores.Remove(result);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
