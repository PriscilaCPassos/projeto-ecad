using Microsoft.EntityFrameworkCore;
using ProjetoMusical.Database;
using ProjetoMusical.Models;
using ProjetoMusical.Repository.Interface;

namespace ProjetoMusical.Repository
{

    // Implementando de ITitularRepository e assinando todos os métodos da interface.
    public class TitularRepository : ITitularRepository
    {
        //Criando um construtor com injeção do DbContext
        // Com esse método é possível pegar o contexto e buscar os titulares.

        private readonly ProjetoMusicalDBContext _dbContext;
        public TitularRepository(ProjetoMusicalDBContext projetoMusicalDBContext) 
        {
            _dbContext = projetoMusicalDBContext;
        }

        public async Task<TitularModel> BuscarPorId(int id)
        {
            return await _dbContext.Titulares.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TitularModel>> BuscarTodosTitulares()
        {
            return await _dbContext.Titulares.ToListAsync();
        }

        public async Task<TitularModel> Adicionar(TitularModel titular)
        {
           await _dbContext.Titulares.AddAsync(titular); // Adicionando o Titular na base de dados.
           await _dbContext.SaveChangesAsync(); // Salvando o Titular na base de dados. 

            return titular;

        }

        public async Task<TitularModel> Atualizar(TitularModel titular, int id)
        {
            TitularModel titularPorId = await BuscarPorId(id);

            // Validação
            if (titularPorId == null)
            {
                throw new Exception($"Titular para o ID: {id} não foi encontrado no banco de dados ");
            }

            titularPorId.Nome = titular.Nome;
            titularPorId.Nacionalidade = titular.Nacionalidade;
            titularPorId.Categoria = titular.Categoria;

            _dbContext.Titulares.Update(titularPorId); // Titular encontrado a ser atualizado.
            await _dbContext.SaveChangesAsync(); // Confirmando a alteração realizada.

            return titularPorId;
        }


        public async Task<bool> Deletar(int id)
        {
            TitularModel titularPorId = await BuscarPorId(id);

            // Validação
            if (titularPorId == null)
            {
                throw new Exception($"Titular para o ID: {id} não foi encontrado no banco de dados ");
            }

            _dbContext.Titulares.Remove(titularPorId); // Titular encontrado a ser removido.
            await _dbContext.SaveChangesAsync(); // Confirmando a ação que será realizada.

            return true;

        }



    }
}
