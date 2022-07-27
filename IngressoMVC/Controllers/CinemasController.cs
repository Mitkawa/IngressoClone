using IngressoMVC.Data;
using IngressoMVC.Models;
using IngressoMVC.Models.ViewModels.RequestDTO;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace IngressoMVC.Controllers
{
    public class CinemasController : Controller
    {
        private IngressoDbContext _context;

        public CinemasController(IngressoDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Cinemas);
        }

        public IActionResult Detalhes(int id)
        {
            return View(_context.Cinemas.Find(id));
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(PostCinemaDTO cinemaDto)
        {
            if (!ModelState.IsValid) return View(cinemaDto);
            
            Cinema cinema = new Cinema(cinemaDto.Nome, cinemaDto.Descricao, cinemaDto.LogoURL);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Atualizar(int id)
        {
            //buscar o ator no banco
            var result = _context.Cinemas.FirstOrDefault(x => x.Id == id);

            if (result == null)
            {
                return View("NotFould");
            }
            //passar o ator na view
            return View();
        }

        [HttpPost]
        public IActionResult Atualizar(PostCinemaDTO cinemaDTO, int id)
        {
            var result = _context.Cinemas.FirstOrDefault(x => x.Id == id);
            if (!ModelState.IsValid)
            {
                return View(result);
            }

            result.AlterarDados(cinemaDTO.Nome, cinemaDTO.Descricao, cinemaDTO.LogoURL);
            _context.Update(result);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Deletar(int id)
        {
            //buscar o ator no banco
            var result = _context.Cinemas.FirstOrDefault(x => x.Id == id);
            if (!ModelState.IsValid)
            {
                return View(result);
            }

            //passar o ator na view
            return View();
        }

        [HttpPost, ActionName("Deletar")]
        public IActionResult ConfirmarDeletar(int id)
        {
            var result = _context.Cinemas.FirstOrDefault(x => x.Id == id);
            _context.Remove(result);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
