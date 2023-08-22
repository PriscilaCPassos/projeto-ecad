using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProjetoMusical.Models
{
    public class TitularModel
    {
        // Métodos com modificadores de acesso.
        // O Id é tratado como Código da Titular.
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Nacionalidade { get; set; }
        public string? Categoria { get; set; }

        // Será que seria essa alteração aqui que eu precisaria fazer ...
        //  public int ObraId { get; set; }
        // public virtual ObraModel? Obra { get; set; }

        private ICollection<ObraModel> Obras { get; set; } = new List<ObraModel>();

    }
}
