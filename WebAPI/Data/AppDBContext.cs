using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class AppDBContext : DbContext
    {
       public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<AutorModel> Autores { get; set; }   
        public DbSet<LivroModel> Livros { get; set; }   
        

    }
    
}
