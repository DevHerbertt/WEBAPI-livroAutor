namespace WebAPI.Models
{
    public class LivroModel
    {
        public int Id { get; set; }
        public string title { get; set; }

        public AutorModel autor { get; set; }
    }
}
