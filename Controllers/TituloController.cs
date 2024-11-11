using BrasileiraoApi.DTOs;
using BrasileiraoApi.Entities;
using BrasileiraoApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace BrasileiraoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TituloController : ControllerBase
{
    private readonly ITituloService _tituloService;

    public TituloController(ITituloService tituloService)
    {
        _tituloService = tituloService;
    }

    [HttpGet]
    public async Task<IActionResult> ObterTitulos(string? filter)
    {
        var titulos = await _tituloService.ObterTodosAsync();
        return Ok(titulos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterTituloId(int id)
    {
        var titulo = await _tituloService.ObterTituloPorId(id);
        return Ok(titulo);
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarTitulo([FromBody] TituloDTO? tituloDto)
    {
        var titulo = new Titulo
        {
            Nome = tituloDto.Nome,
            Quantidade = tituloDto.Quantidade,
            JogadorId = tituloDto.JogadorId
        };

        await _tituloService.AdicionarTitulo(titulo);
        return CreatedAtAction(nameof(ObterTituloId), new { id = titulo.Id }, titulo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarTitulo(int id, [FromBody] Titulo? titulo)
    {
        if (id != titulo?.Id)
        {
            return BadRequest("Título não existe");
        }

        try
        {
            await _tituloService.EditarTitulo(id, titulo);
            return NoContent();
        }
        catch (Exception e)
        {
            throw new Exception($"Erro: {e.Message}");
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Excluir(int id)
    {
        await _tituloService.RemoverTitulo(id);
        return NoContent();
    }
    
}