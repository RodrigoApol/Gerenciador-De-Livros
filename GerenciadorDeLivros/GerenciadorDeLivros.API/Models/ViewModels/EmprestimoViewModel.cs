namespace GerenciadorDeLivros.API.Models.ViewModels;

public class EmprestimoViewModel
{
    public string? UsuarioNome { get; set; }
    public string? LivroTitulo { get; set; }
    public string DataEmprestimo { get; set; }
    public string DataDevolucao { get; set; }
}
