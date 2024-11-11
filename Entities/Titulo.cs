namespace BrasileiraoApi.Entities;

public class Titulo
{
    
    public int Id { get; set; }
    public string? Nome { get; set; }
    public int Quantidade { get; set; }

    public int JogadorId { get; set; }
    public Jogador? Jogador { get; set; }

    public Titulo()
    {
        
    }
    
    public Titulo(int id, string? nome, int quantidade, int jogadorId)
    {
        Id = id;
        Nome = nome;
        Quantidade = quantidade;
        JogadorId = jogadorId;
    }
}

