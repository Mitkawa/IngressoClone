using IngressoMVC.Data;
using IngressoMVC.Models;
using IngressoMVC.Models.ViewModels.RequestDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace IngressoMVC.Controllers
{
    public class FilmesController : Controller
    {
        private IngressoDbContext _context;

        public FilmesController(IngressoDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() => View(_context.Filmes);

        public IActionResult Criar()
        {
            var dadosDropdown = DadosDropdown();

            ViewBag.Atores = new SelectList(dadosDropdown.Atores, "Id", "Nome");
            ViewBag.Categorias = new SelectList(dadosDropdown.Categorias, "Id", "Nome");
            ViewBag.Cinemas = new SelectList(dadosDropdown.Cinemas, "Id", "Nome");
            ViewBag.Produtores = new SelectList(dadosDropdown.Produtores, "Id", "Nome");

            return View();
        }

        public PostFilmeDropdownDTO DadosDropdown()
        {
            var resp = new PostFilmeDropdownDTO()
            {
                Atores = _context.Atores.OrderBy(x => x.Nome).ToList(),
                Categorias = _context.Categorias.OrderBy(x => x.Nome).ToList(),
                Cinemas = _context.Cinemas.OrderBy(x => x.Nome).ToList(),
                Produtores = _context.Produtores.OrderBy(x => x.Nome).ToList()
            };

            return resp;
        }

        [HttpPost]
        public IActionResult Criar(PostFilmeDTO filmeDto)
        {
            if(!ModelState.IsValid)
            {
                var dadosDropdown = DadosDropdown();

                ViewBag.Atores = new SelectList(dadosDropdown.Atores, "Id", "Nome");
                ViewBag.Categorias = new SelectList(dadosDropdown.Categorias, "Id", "Nome");
                ViewBag.Cinemas = new SelectList(dadosDropdown.Cinemas, "Id", "Nome");
                ViewBag.Produtores = new SelectList(dadosDropdown.Produtores, "Id", "Nome");

                return View();
            }

            Filme filme = new Filme
                (
                    filmeDto.Titulo,
                    filmeDto.Descricao,
                    filmeDto.Preco,
                    filmeDto.ImagemURL,
                    filmeDto.ProdutorId,
                    filmeDto.CinemaId,
                    filmeDto.DataLancamento,
                    filmeDto.DataEncerramento
                );

            _context.Add(filme);
            _context.SaveChanges();

            foreach (var categoriaId in filmeDto.CategoriasId)
            {
                var novaCategoria = new FilmeCategoria(filme.Id, categoriaId);
                _context.FilmesCategorias.Add(novaCategoria);
                _context.SaveChanges();
            }

            foreach (var atorId in filmeDto.AtoresId)
            {
                var novoAtor = new AtorFilme(atorId, filme.Id);
                _context.AtoresFilmes.Add(novoAtor);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Atualizar(int id)
        {
            var result = _context.Filmes.FirstOrDefault(x => x.Id == id);

            if (result == null)
                return View("NotFound");

            return View(result);
        }

        [HttpPost]
        public IActionResult Atualizar(int id, PostFilmeDTO filmeDto)
        {
            var result = _context.Filmes.FirstOrDefault(x => x.Id == id);

            if (!ModelState.IsValid)
                return View(result);

            result.AlterarDados
                (
                filmeDto.Titulo,
                filmeDto.Descricao,
                filmeDto.Preco,
                filmeDto.ImagemURL,
                filmeDto.ProdutorId,
                filmeDto.CinemaId,
                filmeDto.DataEncerramento,
                filmeDto.DataEncerramento
                );

            _context.Update(result);
            _context.SaveChanges();

            return RedirectToAction(nameof(Detalhes), result);
        }

        public IActionResult Deletar(int id)
        {
            var result = _context.Filmes.FirstOrDefault(x => x.Id == id);

            if (result == null)
                return View("NotFound");

            return View(result);
        }

        [HttpPost, ActionName("Deletar")]
        public IActionResult ConfirmarDeletar(int id)
        {
            var result = _context.Filmes.FirstOrDefault(x => x.Id == id);

            _context.Remove(result);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int id)
        {
            var result = _context.Filmes
                .Include(p => p.Produtor)
                .Include(c => c.Cinema)
                .Include(fc => fc.FilmesCategorias).ThenInclude(c => c.Categoria)
                .Include(af => af.AtoresFilmes).ThenInclude(a => a.Ator)
                .FirstOrDefault(f => f.Id == id);

            return View(result);
        }
    }
}
