using GerenciadorDeLivros.API.Context;
using GerenciadorDeLivros.API.Entities;
using GerenciadorDeLivros.API.MappingViewModels;
using GerenciadorDeLivros.API.Models.InputModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeLivros.API.Controllers;

[Route("api/livros")]
[ApiController]
public class LivrosController : ControllerBase
{
    private readonly GerenciadorLivrosDbContext _context;

    public LivrosController(GerenciadorLivrosDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult ConsultadarTodosLivros()
    {
        var livros = _context.Livros;

        var livrosViewModel = livros.ParaViewModel();

        return Ok(livrosViewModel);
    }

    [HttpGet("{id}")]
    public IActionResult ConsultarUmLivro(int id)
    {
        var livro = _context.Livros.SingleOrDefault(l => l.Id == id);

        if (livro is null)
            return NotFound();

        var livroViewModel = livro.ParaViewModelComId();

        return Ok(livroViewModel);
    }

    [HttpPost]
    public IActionResult AdicionarLivro(LivroInputModel livroInputModel)
    {
        var livro = new Livro(
            livroInputModel.Titulo, 
            livroInputModel.Autor, 
            livroInputModel.Resumo,
            livroInputModel.Isbn,
            livroInputModel.AnoPublicacao);

        _context.Livros.Add(livro);
        _context.SaveChanges();

        return CreatedAtAction(
            nameof(ConsultarUmLivro),
            new { id = livro.Id },
            livro);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarLivro(int id, LivroInputModel livroInputModel)
    {
        var livroExistente = _context.Livros.SingleOrDefault(l => l.Id == id);

        if (livroExistente is null)
            return NotFound();

        livroExistente.AtualizarLivro(
            livroInputModel.Titulo, 
            livroInputModel.Autor, 
            livroInputModel.Resumo, 
            livroInputModel.Isbn, 
            livroInputModel.AnoPublicacao);

        _context.Update(livroExistente);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarLivro(int id)
    {
        var livro = _context.Livros.SingleOrDefault(l => l.Id == id);

        if (livro is null)
            return NotFound();

        _context.Livros.Remove(livro);
        _context.SaveChanges();

        return NoContent();
    }
}
