using GerenciadorDeLivros.API.Entities;
using GerenciadorDeLivros.API.Models.ViewModels;

namespace GerenciadorDeLivros.API.MappingViewModels;

public static class MappingEmprestimoViewModel
{
    public static IEnumerable<EmprestimoViewModel> ParaViewModel(this IEnumerable<Emprestimo> emprestimos)
    {
        return emprestimos.Select(e => new EmprestimoViewModel
        {
            UsuarioNome = e.Usuario.Nome,
            LivroTitulo = e.Livro.Titulo,
            DataEmprestimo = e.DataEmprestimo,
            DataDevolucao = e.DataDevolucao,
        });
    }

    public static EmprestimoViewModel ParaViewModelComId(this Emprestimo emprestimo) => new EmprestimoViewModel
    {
        UsuarioNome = emprestimo.Usuario.Nome,
        LivroTitulo = emprestimo.Livro.Titulo,
        DataEmprestimo = emprestimo.DataEmprestimo,
        DataDevolucao = emprestimo.DataDevolucao,
    };
}
