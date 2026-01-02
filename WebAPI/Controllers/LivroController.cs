using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;
using WebAPI.Models;
using WebAPI.services.Livro;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroInterface _livroInterface;

        public LivroController(ILivroInterface livroInterface)
        {
            _livroInterface = livroInterface;
        }

        [HttpGet("buscarLivroPorIdAutor")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorIdAutor(int idAutor)
        {
            var livro = await _livroInterface.BuscaLivroPorIdAutor(idAutor);
            return Ok(livro);
        }

        [HttpGet("ListarLivros")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ListarLivros()
        {
            var livros = await _livroInterface.ListarLivros();
            return Ok(livros);
        }

        [HttpGet("BuscarPorId/{idLivro}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarPorId(int idLivro)
        {
            var livro = await _livroInterface.BuscarLivroPorId(idLivro);
            return Ok(livro);
        }

        [HttpPost("CriarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> CriarLivro(DTOLivro livro)
        {
            var livroCriado = await _livroInterface.CriarLivro(livro);
            return Ok(livroCriado);
        }

        [HttpPost("EditarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> EditarLivro(DTOLIvroEditar livro)
        {
            var livroEditado = await _livroInterface.EditarLivro(livro);
            return Ok(livroEditado);
        }

        [HttpDelete("DeleteLivro/{idLivro}")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> DeleteLivro(int idLivro)
        {
            var livro = await _livroInterface.ExcluirLivro(idLivro);
            return Ok(livro);
        }
    }
}