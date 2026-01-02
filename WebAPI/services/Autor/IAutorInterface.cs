using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.services.Autor
{
    public interface IAutorInterface
    {
        Task<ResponseModel<List<AutorModel>>> ListarAutores();
        Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor);
        Task<ResponseModel<AutorModel>> BuscaAutorPorIdLivro(int IdLivro);
        Task<ResponseModel<List<AutorModel>>> CriarAutor(DTOAutor autor);
        Task<ResponseModel<List<AutorModel>>> EditarAutor(DTOAutorEditar autor);
        Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int idAutor);
    }
}
