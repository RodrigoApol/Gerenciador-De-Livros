namespace GerenciadorDeLivros.API.Models.ViewModels;

public class EmprestimoViewModel
{
    public string? UsuarioNome { get; set; }
    public string? LivroTitulo { get; set; }
    public DateTime DataEmprestimo { get; set; }
    public DateTime DataDevolucao { get; set; }
}
