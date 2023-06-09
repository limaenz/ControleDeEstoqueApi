using ControleEstoqueApi.Data;
using ControleEstoqueApi.Repositories;
using ControleEstoqueApi.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<ControleEstoqueDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("ControleEstoque"))
    );

builder.Services.AddScoped<IFuncionarioRepositorio, FuncionarioRepositorio>();
builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
builder.Services.AddScoped<IEstoqueRepositorio, EstoqueRepositorio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Controle Estoque");
        c.RoutePrefix = "swagger";
    });

    app.UseCors(builder =>
        builder.WithOrigins("http://localhost:3000")
               .AllowAnyHeader()
               .AllowAnyMethod()
               .WithExposedHeaders("Content-Disposition")
               .SetPreflightMaxAge(TimeSpan.FromSeconds(86400)));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
