namespace Eduardo.Models;

public class Funcionario
{
    

    public string? Nome { get; set; }
    public string? Cpf {get;set;}

    public int Id{get;set;}

    public Funcionario(string nome, string cpf)
    {
        Nome = nome;
        Cpf = cpf;
    }
}