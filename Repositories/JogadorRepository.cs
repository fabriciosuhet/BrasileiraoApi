using BrasileiraoApi.Entities;
using BrasileiraoApi.Infrastructure;
using Microsoft.EntityFrameworkCore;
using BrasileiraoApi.Entities;


namespace BrasileiraoApi.Repositories;

public class JogadorRepository : IJogadorRepository
{
    private readonly BrasileiraoDbContext _context;

    public JogadorRepository(BrasileiraoDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Jogador>> ObterTodosAsync()
    {
        return await _context.Jogadores.ToListAsync();
    }
    
    public async Task Adicionar(Jogador jogador)
    {
        await _context.Jogadores.AddAsync(jogador);
        await _context.SaveChangesAsync();
    }

    public async Task Remover(Jogador jogador)
    {
        _context.Jogadores.Remove(jogador);
        await _context.SaveChangesAsync();
    }

    public async Task<Jogador?> ObterJogadorPorId(int id)
    {
        return await _context.Jogadores.FindAsync(id);
    }

    public async Task EditarJogadorPorId(int id, Jogador jogador)
    {
        await _context.Jogadores.FindAsync(id);
        _context.Jogadores.Update(jogador);
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