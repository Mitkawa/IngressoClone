using IngressoMVC.Data;
using IngressoMVC.Models;
using IngressoMVC.Models.ViewModels.RequestDTO;
using IngressoMVC.Models.ViewModels.ResponseDTO;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            return View(_context.Atores);
        }

        public IActionResult Detalhes(int id)
        {
            var ator = _context.Atores.Find(id);

            var result = _context.Atores.Where(at => at.Id == id)
                            .Select(at => new GetAtoresDTO()
                            {
                                Bio = at.Bio,
                                FotoPerfilURL = at.FotoPerfilURL,
                                Nome = at.Nome,
                                NomeFilmes = at.AtoresFilmes.Select(fm => fm.Filme.Titulo).ToList(),
                                FotoUrlFilmes = at.AtoresFilmes.Select(fm => fm.Filme.ImageURL).ToList()
                            }).FirstOrDefault();

            return View(result);

        }

        public IActionResult Criar()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Criar(PostAtorDTO atorDto)
        {
            //validar os dados
            if (!ModelState.IsValid)
                return View(atorDto);

            //instanciar novo ator
            Ator ator = new Ator(atorDto.Nome, atorDto.Bio, atorDto.FotoPerfilURL);

            //gravar esse ator no banco de dados
            _context.Atores.Add(ator);

            //salvar as mudanças
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Atualizar(int? id)
        {
            if (id == null)
                return NotFound();

            //buscar o ator no banco
            var result = _context.Atores.FirstOrDefault(a => a.Id == id);

            if (result == null)
                return View();

            //passar o ator na view
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

            if (result == null) return View();

            return View(result);
        }

        [HttpPost, ActionName("Deletar")]
        public IActionResult ConfirmarDeletar(int id)
        {
            var result = _context.Atores.FirstOrDefault(a => a.Id == id);
            _context.Atores.Remove(result);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
