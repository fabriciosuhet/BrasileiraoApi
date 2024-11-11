using System.Collections;
using BrasileiraoApi.Entities;

namespace BrasileiraoApi.Service;

public interface ITituloService
{
    Task<IEnumerable<Titulo>> ObterTodosAsync();
    Task AdicionarTitulo(Titulo titulo);
    Task RemoverTitulo(int id);
    Task<Titulo?> ObterTituloPorId(int id);
    Task EditarTitulo(int id, Titulo titulo);
    Task<List<Titulo>> ObterTitulosPorJogador(int idJogador);
}