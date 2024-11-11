using BrasileiraoApi.Entities;

namespace BrasileiraoApi.Service;

public interface IJogadorService
{
    Task<IEnumerable<Jogador>> ObterTodosAsync();
    Task<Jogador?> ObterPorIdAsync(int id);
    Task AdicionarJogador(Jogador jogador);
    Task EditarJogador(int id, Jogador jogador);
    Task RemoverJogador(int id);
}