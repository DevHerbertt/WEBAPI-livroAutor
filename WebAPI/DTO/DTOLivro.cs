using WebAPI.Models;

namespace WebAPI.DTO
{
    public interface DTOLivro
    {
        public string title { get; set; }

        public AutorModel Autor { get; set; }
    }
}
