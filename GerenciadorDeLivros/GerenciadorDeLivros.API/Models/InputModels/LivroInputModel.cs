namespace GerenciadorDeLivros.API.Models.InputModel;

public class LivroInputModel
{
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public string Resumo { get; set; } = string.Empty;
    public string Isbn { get; set; } = string.Empty;
    public int AnoPublicacao { get; set; }
}
