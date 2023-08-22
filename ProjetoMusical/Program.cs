using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using ProjetoMusical.Database;
using ProjetoMusical.Repository;
using ProjetoMusical.Repository.Interface;
using System;
using Microsoft.Extensions.DependencyInjection;

// Configurações importantes para o contexto do banco de dados e para o repositório.
namespace ProjetoMusical
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Método configure Services = Realiza a configuração de serviços usados na aplicação.
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            //Leitura da string de conecção do arquivo de configuração.
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            //Configuração do Banco de Dados = Configurando o DbContext com a string de conexão.
            builder.Services.AddDbContext<ProjetoMusicalDBContext>(options =>
             options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


            //Configurando a injeção de dependências.
            // Toda vez que chamar a Interface ITitularRepository, a classe que vai resolver intanciar será a TitularRepository.
            // Toda vez que chamar a Interface IObraRepository, a classe que vai resolver intanciar será a ObraRepository.
            builder.Services.AddScoped<ITitularRepository, TitularRepository>();
            builder.Services.AddScoped<IObraRepository, ObraRepository>();

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
        }
    }
}
