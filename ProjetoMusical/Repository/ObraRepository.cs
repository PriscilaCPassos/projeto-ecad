using Microsoft.EntityFrameworkCore;
using ProjetoMusical.Database;
using ProjetoMusical.Models;
using ProjetoMusical.Repository.Interface;

namespace ProjetoMusical.Repository
{

    // Implementando de IObraRepository
    public class ObraRepository : IObraRepository
    {
        //Criando um construtor com injeção do DbContext
        // Com esse método é possível pegar o contexto e buscar as obras.

        private readonly ProjetoMusicalDBContext _dbContext;
        public ObraRepository(ProjetoMusicalDBContext projetoMusicalDBContext) 
        {
            _dbContext = projetoMusicalDBContext;
        }

        public async Task<ObraModel> BuscarPorId(int id)
        {
            return await _dbContext.Obras
                .Include(x => x.Titular)
                .FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<List<ObraModel>> BuscarTodasObras()
        {
            return await _dbContext.Obras
                .Include(x => x.Titular)
                .ToListAsync();
        }

        public async Task<ObraModel> Adicionar(ObraModel obra)
        {
           await _dbContext.Obras.AddAsync(obra); // Adicionando a obra na base de dados.
            await _dbContext.SaveChangesAsync(); // Salvando a obra na base de dados. 

            return obra;

        }

        public async Task<ObraModel> Atualizar(ObraModel obra, int id)
        {
            ObraModel obraPorId = await BuscarPorId(id);

            // Validação
            if(obraPorId == null)
            {
                throw new Exception($"Obra para o ID: {id} não foi encontrado no banco de dados ");
            }

            obraPorId.Nome = obra.Nome;
            obraPorId.Genero = obra.Genero;
            obraPorId.TitularId = obra.TitularId;

            _dbContext.Obras.Update(obraPorId); // Obra encontrada a ser atualizada.
            await _dbContext.SaveChangesAsync(); // Confirmando a alteração realizada.

            return obraPorId;
        }


        public async Task<bool> Deletar(int id)
        {
            ObraModel obraPorId = await BuscarPorId(id);

            // Validação
            if(obraPorId == null)
            {
                throw new Exception($"Obra para o ID: {id} não foi encontrado no banco de dados ");
            }

            _dbContext.Obras.Remove(obraPorId); // Obra encontrada a ser removida.
            await _dbContext.SaveChangesAsync(); // Confirmando a ação que será realizada.

            return true;

        }



    }
}
