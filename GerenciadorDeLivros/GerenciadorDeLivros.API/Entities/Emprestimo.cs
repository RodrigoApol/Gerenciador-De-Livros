using System.Text.Json.Serialization;

namespace GerenciadorDeLivros.API.Entities;

public class Emprestimo
{
    public Emprestimo(int id, int idUsuario, int idLivro)
    {
        Id = id;
        IdUsuario = idUsuario;
        IdLivro = idLivro;
    }

    public int Id { get; private set; }
    public int IdUsuario { get; private set; }
    public int IdLivro { get; private set; }
    public DateTime DataEmprestimo { get; private set; } = DateTime.Now.Date;
    public DateTime DataDevolucao { get; private set; } = DateTime.Now.Date.AddDays(7);

    public void AtualizarEmprestimo(int idUsuario, int idLivro)
    {
        IdUsuario = idUsuario;
        IdLivro = idLivro;
    }
}
