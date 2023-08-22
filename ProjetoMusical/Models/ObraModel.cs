using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProjetoMusical.Models
{
    public class ObraModel
    {
        // Métodos com modificadores de acesso.
        // O Id é tratado como Código da Obra.
        public int Id { get; set; } 
        public string? Nome { get; set; }
        public string? Genero { get; set; }

        //Criando o relacionamento entre as Entidades Titular e Obra.
        public int TitularId { get; set; }

        //Criando a referência, uma propriedade que é do tipo TitularModel.
        public virtual TitularModel? Titular { get; set; }
        private ICollection<TitularModel> Titulares { get; set; } = new List<TitularModel>();

    }
}
