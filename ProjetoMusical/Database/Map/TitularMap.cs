using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoMusical.Models;

// Mapeamento das Entidades(Propriedades) e Implementação dos métodos por IEntityTypeConfiguration.

namespace ProjetoMusical.Database.Map
{

    public class TitularMap : IEntityTypeConfiguration<TitularModel>
    {
        public void Configure(EntityTypeBuilder<TitularModel> builder)
        {
            // Definindo as características de cada propriedade.
            // Chave Primária, Campo Obrigatoriedade e Caracteres. 
            builder.HasKey(x => x.Id); 
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255); 
            builder.Property(x => x.Nacionalidade).HasMaxLength(150);
            builder.Property(x => x.Categoria).IsRequired().HasMaxLength(255);
            
        }
    }
}
