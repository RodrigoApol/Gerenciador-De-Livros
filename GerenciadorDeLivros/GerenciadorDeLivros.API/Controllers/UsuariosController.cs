using GerenciadorDeLivros.API.Context;
using GerenciadorDeLivros.API.Entities;
using GerenciadorDeLivros.API.MappingViewModels;
using GerenciadorDeLivros.API.Models.InputModel;
using GerenciadorDeLivros.API.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeLivros.API.Controllers;

[Route("api/usuario")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly GerenciadorLivrosDbContext _context;

    public UsuariosController(GerenciadorLivrosDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult ConsultarUsuarios()
    {
        var usuarios = _context.Usuarios;

        var usuariosViewModel = usuarios.ParaViewModel();

        return Ok(usuariosViewModel);
    }

    [HttpGet("{id}")]
    public IActionResult ConsultarUmUsuario(int id)
    {
        var usuario = _context.Usuarios.SingleOrDefault(u => u.Id == id);

        if (usuario is null)
            return NotFound();

        var usuarioViewModel = usuario.ParaViewModelComId();

        return Ok(usuarioViewModel);
    }

    [HttpPost]
    public IActionResult AdicionarUsuario(UsuarioInputModel usuarioInputModel)
    {
        var usuario = new Usuario(usuarioInputModel.Nome, usuarioInputModel.Email);

        _context.Usuarios.Add(usuario);
        _context.SaveChanges();

        return CreatedAtAction(
            nameof(ConsultarUmUsuario), 
            new {id = usuario.Id}, 
            usuario);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarUsuario(UsuarioInputModel usuarioInputModel, int id)
    {
        var usuarioExistente = _context.Usuarios.SingleOrDefault(u => u.Id == id);

        if (usuarioExistente is null)
            return NotFound();

        usuarioExistente.AtualizarUsuario(usuarioInputModel.Nome, usuarioInputModel.Email);

        _context.Update(usuarioExistente);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult RemoverUsuario(int id)
    {
        var usuario = _context.Usuarios.SingleOrDefault(u => u.Id == id);

        if (usuario is null)
            return NotFound();

        _context.Usuarios.Remove(usuario);
        _context.SaveChanges(); 

        return NoContent();
    }
}
