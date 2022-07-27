using IngressoMVC.Data;
using IngressoMVC.Models;
using IngressoMVC.Models.ViewModels.RequestDTO;
using IngressoMVC.Models.ViewModels.ResponseDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace IngressoMVC.Controllers
{
    public class AtoresController : Controller
    {
        private IngressoDbContext _context;

        public AtoresController(IngressoDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() => View(_context.Atores);

        public IActionResult Detalhes(int id) => View(AtorFilmes(id));

        public GetAtorDto AtorFilmes(int id)
        {
            var result = _context.Atores
                .FirstOrDefault(at => at.Id == id);

            GetAtorDto ator = new GetAtorDto()
            {
                Nome = result.Nome,
                Bio = result.Bio,
                FotoPerfilURL = result.FotoPerfilURL,
                FilmeFotoURL = result.AtoresFilmes.Select(af => af.Filme.ImageURL).ToList(),
                TituloFilmes = result.AtoresFilmes.Select(af => af.Filme.Titulo).ToList()
            };

            return ator;
        }

        public IActionResult Criar() => View();

        [HttpPost]
        public IActionResult Criar(PostAtorDTO atorDto)
        {
            if (!ModelState.IsValid)
                return View(atorDto);

            Ator ator = new Ator(atorDto.Nome, atorDto.Bio, atorDto.FotoPerfilURL);
            _context.Atores.Add(ator);
            _context.SaveChanges();
            
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Atualizar(int? id)
        {
            if (id == null)
                return NotFound();

            var result = _context.Atores.FirstOrDefault(a => a.Id == id);

            if (result == null)
                return View();

            return View(result);
        }

        [HttpPost]
        public IActionResult Atualizar(int id, PostAtorDTO atorDto)
        {
            var ator = _context.Atores.FirstOrDefault(a => a.Id == id);

            if (!ModelState.IsValid)
                return View(ator);

            ator.AtualizarDados(atorDto.Nome, atorDto.Bio, atorDto.FotoPerfilURL);

            _context.Update(ator);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Deletar(int id)
        {
            var result = _context.Atores.FirstOrDefault(a => a.Id == id);

            if (result == null) return View("NotFould");

            return View(result);
        }

[HttpPost, ActionName("Deletar")]
public IActionResult ConfirmarDeletar(int id)
{
    var result = _context.Atores.FirstOrDefault(a => a.Id == id);
    _context.Atores.Remove(result);

    return RedirectToAction(nameof(Index));
}
    }
}
