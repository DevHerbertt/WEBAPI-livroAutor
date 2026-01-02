using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.services.Autor
{
    public class AutorService : IAutorInterface
    {
        private readonly AppDBContext _Context;
        public AutorService(AppDBContext context) {
            _Context = context;
        }

        public async Task<ResponseModel<AutorModel>> BuscaAutorPorIdLivro(int IdLivro)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();
            try
            {
                var livro = await _Context.Livros.Include(a => a.autor)
                    .FirstOrDefaultAsync(LivroBanco => LivroBanco.Id == IdLivro);

                if (livro == null)
                {
                    resposta.Mensagem = "nenhum livro encontrado";
                    return resposta;
                }
                
                resposta.Mensagem = $"autor do livro {livro.title} foi encontrado";
                resposta.Dados = livro.autor;
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

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor)
        {

            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();
            try
            {
                var autor = await _Context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == idAutor);
                if (autor == null)
                {
                    resposta.Mensagem = $"autor {idAutor} nao encontrado";
                    resposta.Status = false;
                    return resposta;
                }
                resposta.Mensagem = $"Mostrando autor do id {idAutor} ";
                resposta.Status = true ;
                resposta.Dados = autor;

                return resposta;

            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
                
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> CriarAutor(DTOAutor Dtoautor)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
            try
            {
                var autor = new AutorModel()
                {
                    Name = Dtoautor.name,
                    secondName = Dtoautor.secondName
                };

                _Context.Autores.Add(autor);
                await _Context.SaveChangesAsync();
               

                resposta.Dados = await _Context.Autores.ToListAsync();
                resposta.Mensagem = "Autores Criados ";
                resposta.Status = true;
                return resposta;
            }catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> EditarAutor(DTOAutorEditar Dtoautor)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
            try
            {
                var autorId = await _Context.Autores.FirstOrDefaultAsync(autorbanco => autorbanco.Id == Dtoautor.id);
                if (autorId == null)
                {
                    resposta.Mensagem = "Autor nao encontradoo";
                    resposta.Status = false;
                    return resposta;
                }



                    autorId.Name = Dtoautor.name;
                    autorId.secondName = Dtoautor.secondName;
               

                
                await _Context.SaveChangesAsync();


                resposta.Dados = await _Context.Autores.ToListAsync();
                resposta.Mensagem = $"Autor do {autorId.Id} editado ";
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

        public async Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int idAutor)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
            try
            {
                var autor = await _Context.Autores.FirstOrDefaultAsync(autorbanco => autorbanco.Id == idAutor);
                if (autor == null)
                {
                    resposta.Mensagem = "Autor nao encontradoo";
                    resposta.Status = false;
                    return resposta;
                }

                _Context.Autores.Remove(autor);
                await _Context.SaveChangesAsync();

                resposta.Mensagem = $"autor {autor.Name},[ {autor.Id} ] deletado";
                resposta.Status = true;
                resposta.Dados = await _Context.Autores.ToListAsync();
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> ListarAutores()
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
            try
            {
                var autores = await _Context.Autores.ToListAsync();

                resposta.Dados = autores;
                resposta.Mensagem = "Todos os Autores Foram listados";

                return resposta;
            }
            catch (Exception ex) { 
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
               
        }
    }
}
