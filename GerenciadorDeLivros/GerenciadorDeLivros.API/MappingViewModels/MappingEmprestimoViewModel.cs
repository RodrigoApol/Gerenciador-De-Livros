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
            DataEmprestimo = e.DataEmprestimo.ToString("dd/MM/yyyy"),
            DataDevolucao = e.DataDevolucao.ToString("dd/MM/yyyy"),
        });
    }

    public static EmprestimoViewModel ParaViewModelComId(this Emprestimo emprestimo) => new EmprestimoViewModel
    {
        UsuarioNome = emprestimo.Usuario.Nome,
        LivroTitulo = emprestimo.Livro.Titulo,
        DataEmprestimo = emprestimo.DataEmprestimo.ToString("dd/MM/yyyy"),
        DataDevolucao = emprestimo.DataDevolucao.ToString("dd/MM/yyyy"),
    };
}
