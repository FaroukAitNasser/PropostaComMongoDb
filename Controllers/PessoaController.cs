using Microsoft.AspNetCore.Mvc;
using MyApiProject.Models;
using MyApiProject.Repositories;

namespace MyApiProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PessoaController : ControllerBase
{
    private readonly PessoaRepository _repo;

    public PessoaController(PessoaRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pessoa>>> GetAll()
        => Ok(await _repo.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<Pessoa>> GetById(string id)
    {
        var pessoa = await _repo.GetByIdAsync(id);
        return pessoa == null ? NotFound() : Ok(pessoa);
    }

    [HttpPost]
    public async Task<ActionResult<Pessoa>> Create(Pessoa pessoa)
    {
        await _repo.CreateAsync(pessoa);
        return CreatedAtAction(nameof(GetById), new { id = pessoa.Id }, pessoa);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, Pessoa updatedPessoa)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing == null) return NotFound();

        updatedPessoa.Id = id;
        await _repo.UpdateAsync(id, updatedPessoa);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing == null) return NotFound();

        await _repo.DeleteAsync(id);
        return NoContent();
    }
}
