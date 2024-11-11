using BrasileiraoApi.Entities;
using BrasileiraoApi.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BrasileiraoApi.Repositories;

public class TituloRepository : ITituloRepository
{
    private readonly BrasileiraoDbContext _context;

    public TituloRepository(BrasileiraoDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Titulo>> ObterTodos()
    {
        return await _context.Titulos.ToListAsync();
    }

    public async Task AdicionarTitulo(Titulo titulo)
    {
        await _context.AddAsync(titulo);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverTitulo(Titulo titulo)
    {
        _context.Remove(titulo);
        await _context.SaveChangesAsync();
    }

    public async Task<Titulo?> ObterTituloPorId(int id)
    {
        return await _context.Titulos.FindAsync(id);
        
    }
    
    public async Task EditarTituloPorId(int id, Titulo titulo)
    {
        await _context.Titulos.FindAsync(id);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Titulo>> ObterJogadorComTitulorPorId(int jogadorId)
    {
        return await _context.Titulos
            .Where(t => t.JogadorId == jogadorId)
            .Include(t => t.Jogador)
            .ToListAsync();
    }
}