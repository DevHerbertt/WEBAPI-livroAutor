using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class AutorModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string secondName { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<LivroModel> livros { get; set; } = new List<LivroModel>();
    }
}
