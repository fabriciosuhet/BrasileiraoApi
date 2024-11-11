using BrasileiraoApi.Entities;

namespace BrasileiraoApi.Repositories;

public interface ITituloRepository
{
    Task<IEnumerable<Titulo>> ObterTodos();
    Task AdicionarTitulo(Titulo titulo);
    Task RemoverTitulo(Titulo titulo);
    Task<Titulo?> ObterTituloPorId(int id);
    Task EditarTituloPorId(int id, Titulo titulo);
    Task<List<Titulo>> ObterJogadorComTitulorPorId(int jogadorId);
}