using WebAPI.Models;

namespace WebAPI.DTO
{
    public class DTOLivro
    {
        public string title { get; set; } = string.Empty;
        public AutorModel Autor { get; set; } = null!;
    }
}
