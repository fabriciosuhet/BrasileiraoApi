namespace BrasileiraoApi.Entities;

public class Jogador
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Posicao { get; set; }
    public int? Idade { get; set; }
    public string? NumeroCamisa { get; set; }
    public int IdTitulo { get; set; }

    public Jogador()
    {
        
    }

    public Jogador(int id, string? nome, string? posicao, int? idade, string? numeroCamisa, int idTitulo)
    {
        Id = id;
        Nome = nome;
        Posicao = posicao;
        Idade = idade;
        NumeroCamisa = numeroCamisa;
        IdTitulo = idTitulo;
    }
}