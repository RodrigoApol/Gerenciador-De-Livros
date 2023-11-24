namespace GerenciadorDeLivros.API.Entities;

public class Usuario
{
    public Usuario(int id, string nome, string email)
    {
        Id = id;
        Nome = nome;
        Email = email;
    }

    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }

    public void AtualizarUsuario(string nome, string email)
    {
        Nome = nome;
        Email = email;
    }
}
