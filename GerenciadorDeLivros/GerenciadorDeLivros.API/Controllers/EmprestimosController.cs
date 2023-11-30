using GerenciadorDeLivros.API.Context;
using GerenciadorDeLivros.API.Entities;
using GerenciadorDeLivros.API.MappingViewModels;
using GerenciadorDeLivros.API.Models.InputModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeLivros.API.Controllers;

[Route("api/emprestimo")]
[ApiController]
public class EmprestimosController : ControllerBase
{
    private readonly GerenciadorLivrosDbContext _context;

    public EmprestimosController(GerenciadorLivrosDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult ConsultarEmprestimos()
    {
        var emprestimos = _context
            .Emprestimos
            .Include(e => e.Livro)
            .Include(e => e.Usuario);

        var emprestimosViewModel = emprestimos.ParaViewModel();

        return Ok(emprestimosViewModel);
    }

    [HttpGet("{id}")]
    public IActionResult ConsultarUmEmprestimo(int id)
    {
        var emprestimo = _context
            .Emprestimos
            .Include(e => e.Livro)
            .Include(e => e.Usuario)
            .SingleOrDefault(e => e.Id == id);

        if (emprestimo is null)
            return NotFound();

        var emprestimoViewModel = emprestimo.ParaViewModelComId();

        return Ok(emprestimoViewModel);
    }

    [HttpPost]
    public IActionResult CriarEmprestimo(EmprestimoInputModel emprestimoInputModel)
    {
        // Consultar ids
        var livro = _context.Livros.SingleOrDefault(l => l.Id == emprestimoInputModel.IdLivro);
        var usuario = _context.Usuarios.SingleOrDefault(u => u.Id == emprestimoInputModel.IdUsuario);

        if (livro is null || usuario is null)
        {
            return NotFound("Livro ou Usuario não existente!");
        }

        var emprestimo = new Emprestimo(emprestimoInputModel.IdUsuario, emprestimoInputModel.IdLivro);

        _context.Emprestimos.Add(emprestimo);
        _context.SaveChanges();

        return CreatedAtAction(
            nameof(ConsultarUmEmprestimo), 
            new { id = emprestimo.Id }, 
            emprestimo);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarEmprestimo(int id, EmprestimoInputModel emprestimoInputModel)
    {
        var emprestimoExistente = _context.Emprestimos.SingleOrDefault(e => e.Id == id);

        if (emprestimoExistente is null)
            return NotFound();

        emprestimoExistente.AtualizarEmprestimo(emprestimoInputModel.IdUsuario, emprestimoInputModel.IdUsuario);
        
        _context.Update(emprestimoExistente);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarEmprestimo(int id)
    {
        var emprestimo = _context.Emprestimos.SingleOrDefault(e => e.Id == id);

        if (emprestimo is null)
            return NotFound();

        _context.Emprestimos.Remove(emprestimo);
        _context.SaveChanges();

        return NoContent();
    }
}
