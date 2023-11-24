﻿using GerenciadorDeLivros.API.Context;
using GerenciadorDeLivros.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeLivros.API.Controllers;

[Route("api/emprestimo")]
[ApiController]
public class EmprestimosController : ControllerBase
{
    private readonly LivrosDbContext _context;

    public EmprestimosController(LivrosDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult ConsultarEmprestimos()
    {
        var emprestimos = _context.Emprestimos;

        return Ok(emprestimos);
    }

    [HttpGet("{id}")]
    public IActionResult ConsultarUmEmprestimo(int id)
    {
        var emprestimo = _context.Emprestimos.SingleOrDefault(e => e.Id == id);

        if (emprestimo is null)
            return NotFound();

        return Ok(emprestimo);
    }

    [HttpPost]
    public IActionResult CriarEmprestimo(Emprestimo emprestimo)
    {
        _context.Emprestimos.Add(emprestimo);

        return CreatedAtAction(nameof(ConsultarUmEmprestimo), new { id = emprestimo.Id }, emprestimo);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarEmprestimo(int id, Emprestimo emprestimo)
    {
        var emprestimoExistente = _context.Emprestimos.SingleOrDefault(e => e.Id == id);

        if (emprestimoExistente is null)
            return NotFound();

        emprestimoExistente.AtualizarEmprestimo(emprestimo.IdUsuario, emprestimo.IdUsuario);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarEmprestimo(int id)
    {
        var emprestimo = _context.Emprestimos.SingleOrDefault(e => e.Id == id);

        if (emprestimo is null)
            return NotFound();

        _context.Emprestimos.Remove(emprestimo);

        return NoContent();
    }
}