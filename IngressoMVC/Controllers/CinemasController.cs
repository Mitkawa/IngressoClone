using IngressoMVC.Data;
using IngressoMVC.Models;
using IngressoMVC.Models.ViewModels.RequestDTO;
using Microsoft.AspNetCore.Mvc;

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
