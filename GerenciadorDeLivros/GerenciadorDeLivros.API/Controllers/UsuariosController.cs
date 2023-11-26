using GerenciadorDeLivros.API.Context;
using GerenciadorDeLivros.API.Entities;
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

        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public IActionResult ConsultarUmUsuario(int id)
    {
        var usuario = _context.Usuarios.SingleOrDefault(u => u.Id == id);

        if (usuario is null)
            return NotFound();

        return Ok(usuario);
    }

    [HttpPost]
    public IActionResult AdicionarUsuario(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);

        return CreatedAtAction(
            nameof(ConsultarUmUsuario), 
            new {id = usuario.Id}, 
            usuario);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarUsuario(Usuario usuario, int id)
    {
        var usuarioExistente = _context.Usuarios.SingleOrDefault(u => u.Id == id);

        if (usuarioExistente is null)
            return NotFound();

        usuarioExistente.AtualizarUsuario(usuario.Nome, usuario.Email);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult RemoverUsuario(int id)
    {
        var usuario = _context.Usuarios.SingleOrDefault(u => u.Id == id);

        if (usuario is null)
            return NotFound();

        _context.Usuarios.Remove(usuario);

        return NoContent();
    }
}
