using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.services.Livro
{
    public interface ILivroInterface
    {
        Task<ResponseModel<List<LivroModel>>> ListarLivros();
        Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro);
        Task<ResponseModel<LivroModel>> BuscaLivroPorIdAutor(int IdAutor);
        Task<ResponseModel<List<LivroModel>>> CriarLivro(DTOLivro livro);
        Task<ResponseModel<List<LivroModel>>> EditarLivro(DTOLIvroEditar livro);
        Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int idLivro);
    }
}
