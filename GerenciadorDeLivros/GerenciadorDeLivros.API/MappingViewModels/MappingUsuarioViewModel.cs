using GerenciadorDeLivros.API.Entities;
using GerenciadorDeLivros.API.Models.ViewModels;

namespace GerenciadorDeLivros.API.MappingViewModels;

public static class MappingUsuarioViewModel
{
    public static IEnumerable<UsuarioViewModel> ParaViewModel(this IEnumerable<Usuario> usuarios)
    {
        return usuarios.Select(usuario => new UsuarioViewModel
        {
            Nome = usuario.Nome,
            Email = usuario.Email,
        });
    }

    public static UsuarioViewModel ParaViewModelComId(this Usuario usuario) => new UsuarioViewModel
    {
        Nome = usuario.Nome,
        Email = usuario.Email
    };
}
