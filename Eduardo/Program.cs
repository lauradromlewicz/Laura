using Microsoft.EntityFrameworkCore;
using Eduardo.Models;
using Microsoft.AspNetCore.Mvc;
using Eduardo.Utils;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
var app = builder.Build();

List<Funcionario> funcionarios = new List<Funcionario>();
List<Folha> folhas = new List<Folha>();

app.MapGet("/", () => "Hello World!");

//cadastro de funcionário
app.MapPost("/api/funcionario/cadastrar", ([FromBody] Funcionario funcionario, [FromServices] AppDbContext context) =>
{
    Funcionario? funcionarioBuscado = context.Funcionarios.FirstOrDefault(x =>
        x.Nome == funcionario.Nome);

    if (funcionarioBuscado is null)
    {
        funcionario.Nome = funcionario.Nome.ToUpper();
        context.Funcionarios.Add(funcionario);
        context.SaveChanges();
        return Results.Created($"/api/produto/buscar/{funcionario.Id}", funcionario);
    }
    return Results.BadRequest("Já existe um produto com o mesmo nome");
});
//listagem de funcionários
app.MapGet("/api/funcionario/listar", ([FromServices] AppDbContext context) =>
{
    if (context.Funcionarios.Any())
    {
        return Results.Ok(context.Funcionarios.ToList());
    }
    return Results.NotFound("Não existem produtos na tabela");
});


//cadastro de folha

app.MapPost("api/folha/cadastrar", ([FromBody] Folha folha, [FromServices] AppDbContext context) =>
{

    Calculos calculos = new Calculos();
    folha.SalarioBruto = Calculos.CalcularSalarioBruto(folha.Quantidade, folha.Valor);

    folha.ImpostoIrrf =
        Calculos.CalcularImpostoRenda(folha.SalarioBruto);

    folha.ImpostoInss =
        Calculos.CalcularImpostoInss(folha.SalarioBruto);

    folha.ImpostoFgts =
        Calculos.CalcularFgts(folha.SalarioBruto);

    folha.SalarioLiquido =
        Calculos.CalculaSalarioLiquido
        (
            folha.SalarioBruto,
            folha.ImpostoIrrf,
            folha.ImpostoInss
        );

    context.Folhas.Add(folha);
    context.SaveChanges();
    return Results.Created("", folha);
});

//Listar folhas

app.MapGet("/api/folha/listar", ([FromServices] AppDbContext context) =>
{
    if (context.Folhas.Any())
    {
        return Results.Ok(context.Folhas.ToList());
    }
    return Results.NotFound("Não existem folhas na tabela");
});

//Buscar folhas
app.MapGet("api/folha/buscar/{cpf}", ([FromRoute] string cpf, [FromServices] AppDbContext context) =>
{
    
}
   
);

       
        


app.Run();
