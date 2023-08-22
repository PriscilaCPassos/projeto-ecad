using Microsoft.EntityFrameworkCore;
using ProjetoMusical.Database.Map;
using ProjetoMusical.Models;


// Trabalhando com ORM, que facilita o trabalho com o Banco de Dados independente qual for ele.
// Configurações gerais e de tabelas do banco de dados. 

namespace ProjetoMusical.Database
{
    // Criando a Classe de Configuração - Adicionando Herança, herdando caractrísticas do DbContext.
    public class ProjetoMusicalDBContext : DbContext
    {

        // Criando um construtor e passando para ele o nome do meu contxto.
        // Recebendo um objeto de configurações e passando para a classe mãe.
        public ProjetoMusicalDBContext(DbContextOptions<ProjetoMusicalDBContext> options)
            : base(options)
        {
        }

        // Representação da coleção de Tabelas no Banco de Dados. 
        //Indicando para o EF realizar o CRUD para as entidades Titular e Obra, com o Model utilizado e o nome para tabela no banco.
        public DbSet<TitularModel> Titulares { get; set; }
        public DbSet<ObraModel> Obras { get; set; }

        //Mapeamento das entidades no contexto do banco de dados.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TitularMap());
            modelBuilder.ApplyConfiguration(new ObraMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
