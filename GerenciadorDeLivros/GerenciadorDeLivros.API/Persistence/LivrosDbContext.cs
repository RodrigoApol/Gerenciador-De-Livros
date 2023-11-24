using GerenciadorDeLivros.API.Entities;

namespace GerenciadorDeLivros.API.Context;

public class LivrosDbContext
{
    public LivrosDbContext()
    {
        Livros = new List<Livro>();
        Usuarios = new List<Usuario>();
        Emprestimos = new List<Emprestimo>();
    }

    public List<Livro> Livros { get; set; }
    public List<Usuario> Usuarios { get; set; }
    public List<Emprestimo> Emprestimos { get; set; }
}
