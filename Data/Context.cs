using EditorMarkdown.ModelMkd;
using Microsoft.EntityFrameworkCore;

namespace EditorMarkdown.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Modelmkd> Cadastro { get; set; }

        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Modelmkd>()
                .HasKey(t => t.Id)
                .HasAnnotation("Sqlite:Autoincrement", true);
        }
    }
}