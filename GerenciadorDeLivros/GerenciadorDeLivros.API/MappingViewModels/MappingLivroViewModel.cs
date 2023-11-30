using GerenciadorDeLivros.API.Entities;
using GerenciadorDeLivros.API.Models.ViewModels;

namespace GerenciadorDeLivros.API.MappingViewModels;

public static class MappingLivroViewModel
{
    public static IEnumerable<LivroViewModel> ParaViewModel(this IEnumerable<Livro> livros)
    {
        return livros.Select(livro => new LivroViewModel
        {
            Titulo = livro.Titulo,
            Autor = livro.Autor,
            Resumo = livro.Resumo,
            Isbn = livro.Isbn,
            AnoPublicacao = livro.AnoPublicacao,
        });
    }

    public static LivroViewModel ParaViewModelComId(this Livro livro) => new LivroViewModel
    {
        Titulo = livro.Titulo,
        Autor = livro.Autor,
        Resumo = livro.Resumo,
        Isbn = livro.Isbn,
        AnoPublicacao = livro.AnoPublicacao
    };
}
