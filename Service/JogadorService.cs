using BrasileiraoApi.Entities;
using BrasileiraoApi.Repositories;

namespace BrasileiraoApi.Service;

public class JogadorService : IJogadorService
{
    private readonly IJogadorRepository _jogadorRepository;

    public JogadorService(IJogadorRepository jogadorRepository)
    {
        _jogadorRepository = jogadorRepository;

    }
    public async Task<IEnumerable<Jogador>> ObterTodosAsync()
    {
        return await _jogadorRepository.ObterTodosAsync();
    }

    public async Task<Jogador?> ObterPorIdAsync(int id)
    {
        var jogador = await _jogadorRepository.ObterJogadorPorId(id);
        if (jogador == null)
        {
            throw new Exception("Jogador não encontrado");
        }
        return jogador;
    }

    public async Task AdicionarJogador(Jogador jogador)
    {
        if (jogador == null)
        {
            throw new ArgumentException("Jogador inválido. Adicione um jogador válido.");
        }
        await _jogadorRepository.Adicionar(jogador);
    }

    public async Task EditarJogador(int id, Jogador jogador)
    {
        var jogadorExistente = await _jogadorRepository.ObterJogadorPorId(id);
        if (jogadorExistente == null)
        {
            throw new Exception("Jogador não encontrado");
        }
        
        jogadorExistente.Nome = jogador.Nome;
        jogadorExistente.Idade = jogador.Idade;
        jogadorExistente.NumeroCamisa = jogador.NumeroCamisa;
        
        await _jogadorRepository.EditarJogadorPorId(id, jogadorExistente);
    }

    public async Task RemoverJogador(int id)
    {
        var jogadorExistente = await _jogadorRepository.ObterJogadorPorId(id);
        if (jogadorExistente == null)
        {
            throw new Exception("Jogador não encontrado");
        }

        await _jogadorRepository.Remover(jogadorExistente);
    }
    
 }