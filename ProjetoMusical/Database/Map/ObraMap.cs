using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoMusical.Models;

// Mapeamento das Entidades(Propriedades) e Implementação dos métodos por IEntityTypeConfiguration.

namespace ProjetoMusical.Database.Map
{
    public class ObraMap : IEntityTypeConfiguration<ObraModel>
    {
        public void Configure(EntityTypeBuilder<ObraModel> builder)
        { 
            // Definindo as características de cada propriedade.
            // Chave Primária, Campo Obrigatoriedade e Caracteres. 
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Genero).IsRequired().HasMaxLength(255);
            builder.Property(x => x.TitularId); // Mapeando a nova propriedade.

            // Definindo o relacionamento(vínculo).
            builder.HasOne(x => x.Titular);


            // Código que possivelmente seria o relacionamento entre as entidades (Titular e Obra)
            // builder.HasOne(x => x.Titular).WithMany(x => x.).HasForeignKey(x => x.TitularId);
        }

    }
}
