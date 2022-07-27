using IngressoMVC.Data;
using IngressoMVC.Models;
using IngressoMVC.Models.ViewModels.RequestDTO;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Detalhes(int id) => View(_context.Filmes.Find(id));

        public IActionResult Criar() => View();

        [HttpPost] IActionResult Criar(PostFilmeDTO filmeDto)
        {

            Filme filme = new Filme

              (
                  filmeDto.Titulo,
                  filmeDto.Descricao,
                  filmeDto.Preco,
                  filmeDto.ImageURL,
                  _context.Produtores.FirstOrDefault(x => x.Id == filmeDto.ProdutorId).Id
              );

            _context.Add(filme);
            _context.SaveChanges();

            //Incluir Relacionamentos
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
            //buscar o ator no banco
            var result = _context.Filmes.FirstOrDefault(x => x.Id == id);

            if(result == null) 
            {
                return View("NotFould");
            }
            //passar o ator na view
            return View();
        }

        [HttpPost]
        public IActionResult Atualizar(PostFilmeDTO filmeDTO, int id) 
        {
            var result = _context.Filmes.FirstOrDefault(x => x.Id == id);
            if (!ModelState.IsValid) 
            {
                return View(result);
            }

            result.AlterarDados(filmeDTO.Titulo, filmeDTO.Descricao, filmeDTO.Preco, filmeDTO.ImageURL);
            _context.Update(result);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Deletar(int id)
        {
            //buscar o ator no banco
            var result = _context.Filmes.FirstOrDefault(x => x.Id == id);
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
            var result = _context.Filmes.FirstOrDefault(x => x.Id == id);
            _context.Remove(result);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
