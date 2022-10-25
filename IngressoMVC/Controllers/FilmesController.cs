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
            DadosDropdown();

            return View();
        }

        [HttpPost]
        public IActionResult Criar(PostFilmeDTO filmeDto)
        {
            if(!ModelState.IsValid)
            {
                DadosDropdown();
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
            var result = _context.Filmes
                .Include(x => x.AtoresFilmes).ThenInclude(x => x.Ator)
                .Include(x => x.FilmesCategorias).ThenInclude(x => x.Categoria)
                .FirstOrDefault(x => x.Id == id);

            if (result == null)
                return View("NotFound");

            var response = new PostFilmeDTO()
            {
                Titulo = result.Titulo,
                Descricao = result.Descricao,
                Preco = result.Preco,
                ImagemURL = result.ImagemURL,
                DataLancamento = result.DataLancamento,
                DataEncerramento = result.DataEncerramento,
                CinemaId = result.CinemaId,
                ProdutorId = result.ProdutorId,
                AtoresId = result.AtoresFilmes.Select(x => x.AtorId).ToList(),
                CategoriasId = result.FilmesCategorias.Select(x => x.CategoriaId).ToList()
            };

            DadosDropdown();
            return View(response);
        }

        [HttpPost]
        public IActionResult Atualizar(int id, PostFilmeDTO filmeDto)
        {
            var result = _context.Filmes.FirstOrDefault(x => x.Id == id);

            if (!ModelState.IsValid)
            {
                DadosDropdown();
                return View(result);
            }

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

            var filmeCategoriasAtual = _context.FilmesCategorias.Where(fc => fc.FilmeId == result.Id);
            _context.FilmesCategorias.RemoveRange(filmeCategoriasAtual);
            _context.SaveChanges();

            foreach (var categoriaId in filmeDto.CategoriasId)
            {
                var novaCategoria = new FilmeCategoria(result.Id, categoriaId);
                _context.FilmesCategorias.Add(novaCategoria);
                _context.SaveChanges();
            }

            var atoresFilmesAtual = _context.AtoresFilmes.Where(af => af.FilmeId == result.Id);
            _context.AtoresFilmes.RemoveRange(atoresFilmesAtual);
            _context.SaveChanges();

            foreach(var atorId in filmeDto.AtoresId)
            {
                var atorFilme = new AtorFilme(atorId, result.Id);
                _context.AtoresFilmes.Add(atorFilme);
                _context.SaveChanges();
            }

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

        public void DadosDropdown()
        {
            var resp = new PostFilmeDropdownDTO()
            {
                Atores = _context.Atores.OrderBy(x => x.Nome).ToList(),
                Categorias = _context.Categorias.OrderBy(x => x.Nome).ToList(),
                Cinemas = _context.Cinemas.OrderBy(x => x.Nome).ToList(),
                Produtores = _context.Produtores.OrderBy(x => x.Nome).ToList()
            };

            ViewBag.Atores = new SelectList(resp.Atores, "Id", "Nome");
            ViewBag.Categorias = new SelectList(resp.Categorias, "Id", "Nome");
            ViewBag.Cinemas = new SelectList(resp.Cinemas, "Id", "Nome");
            ViewBag.Produtores = new SelectList(resp.Produtores, "Id", "Nome");
        }

        public IActionResult Buscar(string filtroDeBsuca)
        {
            var result = _context.Filmes
                .Include(filme => filme.AtoresFilmes).ThenInclude(atorFilme => atorFilme.Ator)
                .ToList();

            /*
            Filmes
	            Onde
		            (Filme.Titulo.Contem("busca")) ou
		            (Filme.Descri.Contem("busca)) ou
		            (Filme.AtoresFilmes.Atores.Nome.Contem("busca")) =[SOLUÇÃO ATIVIDADE]=
            */

            if (!string.IsNullOrEmpty(filtroDeBsuca))
            {
                filtroDeBsuca = filtroDeBsuca.ToLower().Trim();

                var resultadoDaBusca = result
                    .Where(filme => 
                        filme.Titulo.ToLower().Contains(filtroDeBsuca) || 
                        filme.Descricao.ToLower().Contains(filtroDeBsuca) ||  
                        filme.AtoresFilmes.Select(af => af.Ator.Nome.ToLower().Contains(filtroDeBsuca)).FirstOrDefault())
                    .OrderBy(x => x.Titulo)
                    .ToList();

                return View(nameof(Index), resultadoDaBusca);
            } 

            return View(nameof(Index), result);
        }
    }
}
