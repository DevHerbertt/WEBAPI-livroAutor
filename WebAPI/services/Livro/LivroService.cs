using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.services.Livro
{
    public class LivroService : ILivroInterface
    {
        private readonly AppDBContext _Context;

        public LivroService(AppDBContext context)
        {
            _Context = context;
        }

        public async Task<ResponseModel<LivroModel>> BuscaLivroPorIdAutor(int IdAutor)
        {
            ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>();
            try
            {
                var livro = await _Context.Livros
                    .Include(l => l.autor)
                    .FirstOrDefaultAsync(livroBanco => livroBanco.autor.Id == IdAutor);

                if (livro == null)
                {
                    resposta.Mensagem = $"Nenhum livro encontrado para o autor {IdAutor}";
                    resposta.Status = false;
                    return resposta;
                }

                resposta.Mensagem = $"Livro do autor {IdAutor} foi encontrado";
                resposta.Dados = livro;
                resposta.Status = true;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro)
        {
            ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>();
            try
            {
                var livro = await _Context.Livros.FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);
                if (livro == null)
                {
                    resposta.Mensagem = $"Livro {idLivro} não encontrado";
                    resposta.Status = false;
                    return resposta;
                }
                resposta.Mensagem = $"Mostrando livro do id {idLivro}";
                resposta.Status = true;
                resposta.Dados = livro;

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> CriarLivro(DTOLivro DTOlivro)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livro = new LivroModel()
                {
                    title = DTOlivro.title,
                    autor = DTOlivro.Autor,
                };

                _Context.Livros.Add(livro);
                await _Context.SaveChangesAsync();

                resposta.Dados = await _Context.Livros.ToListAsync();
                resposta.Mensagem = "Livro criado com sucesso";
                resposta.Status = true;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> EditarLivro(DTOLIvroEditar DTOlivro)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livro = await _Context.Livros.FirstOrDefaultAsync(livroBanco => livroBanco.Id == DTOlivro.id);
                if (livro == null)
                {
                    resposta.Mensagem = "Livro não encontrado";
                    resposta.Status = false;
                    return resposta;
                }

                livro.title = DTOlivro.title;
                if (DTOlivro.Autor != null)
                {
                    livro.autor = DTOlivro.Autor;
                }

                await _Context.SaveChangesAsync();

                resposta.Dados = await _Context.Livros.ToListAsync();
                resposta.Mensagem = $"Livro {livro.Id} editado com sucesso";
                resposta.Status = true;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int idLivro)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livro = await _Context.Livros.FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);
                if (livro == null)
                {
                    resposta.Mensagem = "Livro não encontrado";
                    resposta.Status = false;
                    return resposta;
                }

                _Context.Livros.Remove(livro);
                await _Context.SaveChangesAsync();

                resposta.Mensagem = $"Livro {livro.Id}, {livro.title} deletado";
                resposta.Status = true;
                resposta.Dados = await _Context.Livros.ToListAsync();
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> ListarLivros()
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livros = await _Context.Livros.ToListAsync();

                resposta.Dados = livros;
                resposta.Mensagem = "Todos os livros foram listados";
                resposta.Status = true;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}