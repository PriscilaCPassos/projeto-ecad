using ProjetoMusical.Models;

namespace ProjetoMusical.Repository.Interface
{
    
    // Contratos do Titular = Buscar, Adicionar, Atualizar e Deletar.
    public interface IObraRepository
    {
        Task<List<ObraModel>> BuscarTodasObras();
        Task<ObraModel> BuscarPorId(int id);
        Task<ObraModel> Adicionar(ObraModel obra);
        Task<ObraModel> Atualizar(ObraModel obra, int id);
        Task<bool> Deletar(int id);
    }
}
