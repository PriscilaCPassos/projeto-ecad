using ProjetoMusical.Models;

namespace ProjetoMusical.Repository.Interface
{
    
    // Contratos do Titular = Buscar, Adicionar, Atualizar e Deletar.
    public interface ITitularRepository
    {
        Task<List<TitularModel>> BuscarTodosTitulares();
        Task<TitularModel> BuscarPorId(int id);
        Task<TitularModel> Adicionar(TitularModel titular);
        Task<TitularModel> Atualizar(TitularModel titular, int id);
        Task<bool> Deletar(int id);
    }
}
