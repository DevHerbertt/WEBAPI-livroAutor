using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;
using WebAPI.Models;
using WebAPI.services.Autor;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorInterface _autorInterface;

        public AutorController(IAutorInterface autorInterface) {
            _autorInterface = autorInterface;
        }
        [HttpGet ("buscarAutorPorIdLivro")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> buscarAutorPorIdLivro(int idlivro)
        {
            var autor = await _autorInterface.BuscaAutorPorIdLivro(idlivro);
            return Ok(autor);
        }



        [HttpGet("ListarAutores")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores()
        {
            var autores = await _autorInterface.ListarAutores();
            return Ok(autores);
        }




        [HttpGet("BuscarPorId/{idAutor}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarPorId(int idAutor)
        {
            var autor = await _autorInterface.BuscarAutorPorId(idAutor);
            return Ok(autor);
        }

        [HttpPost("CriarAutor")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> CriarAutor(DTOAutor autor)
        {
            var autorCriado = await _autorInterface.CriarAutor(autor);
            return Ok(autorCriado);
        }

        [HttpPost("EditarAutor")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> EditarAutor(DTOAutorEditar autor)
        {
            var autorCriado = await _autorInterface.EditarAutor(autor);
            return Ok(autorCriado);
        }

        [HttpDelete("DeleteAutor/{idAutor}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> DeleteAutor(int idAutor)
        {
            var autor = await _autorInterface.ExcluirAutor(idAutor);
            return Ok(autor);
        }


    }
}
