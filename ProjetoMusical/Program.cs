using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using ProjetoMusical.Database;
using ProjetoMusical.Repository;
using ProjetoMusical.Repository.Interface;
using System;
using Microsoft.Extensions.DependencyInjection;

// Configura��es importantes para o contexto do banco de dados e para o reposit�rio.
namespace ProjetoMusical
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // M�todo configure Services = Realiza a configura��o de servi�os usados na aplica��o.
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            //Leitura da string de conec��o do arquivo de configura��o.
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            //Configura��o do Banco de Dados = Configurando o DbContext com a string de conex�o.
            builder.Services.AddDbContext<ProjetoMusicalDBContext>(options =>
             options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


            //Configurando a inje��o de depend�ncias.
            // Toda vez que chamar a Interface ITitularRepository, a classe que vai resolver intanciar ser� a TitularRepository.
            // Toda vez que chamar a Interface IObraRepository, a classe que vai resolver intanciar ser� a ObraRepository.
            builder.Services.AddScoped<ITitularRepository, TitularRepository>();
            builder.Services.AddScoped<IObraRepository, ObraRepository>();


            // Coment�rios a retirar depois:
            // builder.Services.AddEntityFrameworkMySql()
            //  .AddDbContext<ProjetoMusicalDBContext>(
            //    Options => Options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection")));

            // builder.Services.AddScoped<ITitularRepository, TitularRepository>();


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