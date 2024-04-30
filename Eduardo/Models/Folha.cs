namespace Eduardo.Models;
public class Folha


{

    public Folha(double valor, int quantidade, int mes, int ano)
    {

        Valor = valor;
        Id = Guid.NewGuid().ToString();
        Quantidade = quantidade;
        Mes = mes;
        Ano = ano;

    }
    public string? Id { get; set; }
    public double Valor { get; set; }
    public int Quantidade { get; set; }
    public int Mes { get; set; }
    public int Ano { get; set; }
    public double SalarioBruto { get; set; }
    public double ImpostoIrrf { get; set; }
    public double ImpostoInss { get; set; }
    public double ImpostoFgts { get; set; }
    public double SalarioLiquido { get; set; }
    public int FuncionarioId {get;set;}
    public Funcionario Funcionario {get;set;}

}