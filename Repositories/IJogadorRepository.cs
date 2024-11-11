using BrasileiraoApi.Entities;

namespace BrasileiraoApi.Repositories;

public interface IJogadorRepository
{
    Task<IEnumerable<Jogador>> ObterTodosAsync();
    Task Adicionar(Jogador jogador);
    Task Remover(Jogador jogador);
    Task<Jogador?> ObterJogadorPorId(int id);
    Task EditarJogadorPorId(int id, Jogador jogador);
    
}