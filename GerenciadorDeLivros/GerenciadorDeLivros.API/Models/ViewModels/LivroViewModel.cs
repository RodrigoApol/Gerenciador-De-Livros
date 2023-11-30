namespace GerenciadorDeLivros.API.Models.ViewModels;

public class LivroViewModel
{
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public string Resumo { get; set; } = string.Empty;
    public string Isbn { get; set; } = string.Empty;
    public int AnoPublicacao { get; set; }
}
