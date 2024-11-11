using BrasileiraoApi.Entities;
using BrasileiraoApi.Repositories;

namespace BrasileiraoApi.Service;

public class TituloService : ITituloService
{
    private readonly ITituloRepository _tituloRepository;

    public TituloService(ITituloRepository tituloRepository)
    {
        _tituloRepository = tituloRepository;
    }
    public async Task<IEnumerable<Titulo>> ObterTodosAsync()
    {
        return await _tituloRepository.ObterTodos();
    }

    public async Task AdicionarTitulo(Titulo titulo)
    {
        if (titulo == null)
        {
            throw new ArgumentException("Título inválido. Adicione um título válido.");
        }
        await _tituloRepository.AdicionarTitulo(titulo);
        
    }

    public async Task RemoverTitulo(int id)
    {
        var tituloExistente = await _tituloRepository.ObterTituloPorId(id);
        if (tituloExistente == null)
        {
            throw new Exception("Título não encontrado");
        }
        await _tituloRepository.RemoverTitulo(tituloExistente);
    }

    public async Task<Titulo?> ObterTituloPorId(int id)
    {
        var tituloExistente = await _tituloRepository.ObterTituloPorId(id);
        if (tituloExistente == null)
        {
            throw new Exception("Título não encontrado");
        }
        return tituloExistente;
    }

    public async Task EditarTitulo(int id, Titulo titulo)
    {
        var tituloExistente = await _tituloRepository.ObterTituloPorId(id);
        if (tituloExistente == null)
        {
            throw new Exception("Título não encontrado");
        }
        tituloExistente.Quantidade = titulo.Quantidade;
        await _tituloRepository.EditarTituloPorId(id, titulo);
    }

    public async Task<List<Titulo>> ObterTitulosPorJogador(int idJogador)
    {
        return await _tituloRepository.ObterJogadorComTitulorPorId(idJogador);
    }
}