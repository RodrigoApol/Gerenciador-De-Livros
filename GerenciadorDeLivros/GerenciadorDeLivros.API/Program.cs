using GerenciadorDeLivros.API.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("GerenciadorDeLivros");

builder.Services.AddDbContext<GerenciadorLivrosDbContext>(o => o.UseSqlServer(connectionString));
// builder.Services.AddDbContext<GerenciadorLivrosDbContext>(o => o.UseInMemoryDatabase("GerenciadorLivros"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
