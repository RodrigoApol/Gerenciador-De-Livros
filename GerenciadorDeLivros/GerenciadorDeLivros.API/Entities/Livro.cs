namespace GerenciadorDeLivros.API.Entities;

public class Livro
{
    public Livro(string titulo, string autor, string resumo, int isbn, string anoPublicacao)
    {
        Titulo = titulo;
        Autor = autor;
        Resumo = resumo;
        Isbn = isbn;
        AnoPublicacao = anoPublicacao;
    }

    public int Id { get; private set; }
    public string Titulo { get; private set; }
    public string Autor { get; private set; }
    public string Resumo { get; private set; }
    public int Isbn { get; private set; }
    public string AnoPublicacao { get; private set; }

    public void AtualizarLivro(string titulo, string autor, string resumo, int isbn, string anoPublicacao)
    {
        Titulo = titulo;
        Autor = autor;
        Resumo = resumo;
        Isbn = isbn;
        AnoPublicacao = anoPublicacao;
    }
}
