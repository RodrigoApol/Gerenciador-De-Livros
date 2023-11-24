using GerenciadorDeLivros.API.Context;
using GerenciadorDeLivros.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeLivros.API.Controllers;

[Route("api/livros")]
[ApiController]
public class LivrosController : ControllerBase
{
    private readonly LivrosDbContext _context;

    public LivrosController(LivrosDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult ConsultadarTodosLivros()
    {
        var livro = _context.Livros.ToList();

        return Ok(livro);
    }

    [HttpGet("{id}")]
    public IActionResult ConsultarUmLivro(int id)
    {
        var resultado = _context.Livros.SingleOrDefault(l => l.Id == id);

        if (resultado is null)
            return NotFound();

        return Ok(resultado);
    }

    [HttpPost]
    public IActionResult AdicionarLivro(Livro livro)
    {
        _context.Livros.Add(livro);

        return CreatedAtAction(
            nameof(ConsultarUmLivro),
            new { id = livro.Id },
            livro);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarLivro(int id, Livro livro)
    {
        var livroExistente = _context.Livros.SingleOrDefault(l => l.Id == id);

        if (livroExistente is null)
            return NotFound();

        livroExistente.AtualizarLivro(livro.Titulo, livro.Autor, livro.Resumo, livro.Isbn, livro.AnoPublicacao);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarLivro(int id)
    {
        var livro = _context.Livros.SingleOrDefault(l => l.Id == id);

        if (livro is null)
            return NotFound();

        _context.Livros.Remove(livro);

        return NoContent();
    }
}
