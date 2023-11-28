using GerenciadorDeLivros.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GerenciadorDeLivros.API.Context;

public class GerenciadorLivrosDbContext : DbContext
{
    public GerenciadorLivrosDbContext(DbContextOptions<GerenciadorLivrosDbContext> options) : base(options)
    {
        
    }

    public DbSet<Livro> Livros { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Emprestimo> Emprestimos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Livro>(e =>
        {
            e.HasKey(l => l.Id);

            e
            .Property(l => l.Resumo)
            .IsRequired(false)
            .HasMaxLength(200)
            .HasColumnType("varchar(200)");
        });

        modelBuilder.Entity<Usuario>(e =>
        {
            e.HasKey(u => u.Id);
        });

        modelBuilder.Entity<Emprestimo>(e =>
        {
            e.HasKey(e => e.Id);

            e.HasOne(e => e.Usuario).WithMany().HasForeignKey(e => e.IdUsuario);

            e.HasOne(e => e.Livro).WithMany().HasForeignKey(e => e.IdLivro);
        });
    }
}
