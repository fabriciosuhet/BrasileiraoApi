using BrasileiraoApi.Entities;
using BrasileiraoApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace BrasileiraoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class JogadorController : ControllerBase
{
    private readonly IJogadorService _jogadorService;
    private readonly ITituloService _tituloService;

    public JogadorController(IJogadorService jogadorService, ITituloService tituloService)
    {
        _jogadorService = jogadorService;
        _tituloService = tituloService;
    }

    [HttpGet]
    public async Task<IActionResult> ObterTodos()
    {
        var jogadores = await _jogadorService.ObterTodosAsync();
        return Ok(jogadores);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterPorId(int id)
    {
        var jogador = await _jogadorService.ObterPorIdAsync(id);
        return Ok(jogador);
    }

    [HttpGet("{id}/titulo")]
    public async Task<IActionResult> ObterTitulosPorJogador(int id)
    {
        var titulos = await _tituloService.ObterTitulosPorJogador(id);
        if (!titulos.Any())
        {
            return NotFound("Nenhum título encontrado para esse jogador");
        }
        return Ok(titulos);
    }

    [HttpPost]
    public async Task<IActionResult> Adicionar([FromBody] Jogador? jogador)
    {
        if (jogador == null)
        {
            return BadRequest("Jogador não pode ser nulo");
        }

        await _jogadorService.AdicionarJogador(jogador);
        return CreatedAtAction(nameof(ObterPorId), new { id = jogador.Id }, jogador);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] Jogador jogador)
    {
        if (id != jogador.Id)
        {
            return BadRequest("Id não existe.");
        }
        try
        {
            await _jogadorService.EditarJogador(id, jogador);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound($"Jogador não encontrado: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Excluir(int id)
    {
        await _jogadorService.RemoverJogador(id);
        return NoContent();
    }
    
}