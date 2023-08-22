using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoMusical.Models;
using ProjetoMusical.Repository.Interface;

namespace ProjetoMusical.Controllers
{
    // O acesso para essa Api será: A porta e O IP da nossa Api/Titular -> 'https://localhost:7271/api/Titular'
    [Route("api/[controller]")]
    [ApiController]
    public class TitularController : ControllerBase
    {
        // Criando construtor e definindo as injeções de dependências.
        private readonly ITitularRepository _titularRepository;
        public TitularController(ITitularRepository titularRepository)
        {
            _titularRepository = titularRepository;
        }

        // Método criado para buscar os titulares.
        // Definindo o endpoint.
        [HttpGet] 
        public async Task<ActionResult<List<TitularModel>>> BuscarTodosTitulares()
        {
            List<TitularModel> titulares = await _titularRepository.BuscarTodosTitulares();
            return Ok(titulares); // Retornando uma lista com todos meus titulares cadastrados.
        }

        // Método Buscar, passando {Id} por parâmetro.
        [HttpGet("{id}")]
        public async Task<ActionResult<TitularModel>> BuscarPorId(int id)
        {
            TitularModel titular = await _titularRepository.BuscarPorId(id);
            return Ok(titular);
        }

        // Método Cadastrar.
        [HttpPost]
        public async Task<ActionResult<TitularModel>> Cadastrar([FromBody] TitularModel titularModel)
        {
            TitularModel titular = await _titularRepository.Adicionar(titularModel);
            return Ok(titular);
        }

        // Método Atualizar, passando {Id} por parâmetro.
        [HttpPut("{id}")]
        public async Task<ActionResult<TitularModel>> Atualizar([FromBody] TitularModel titularModel, int id)
        {
            titularModel.Id = id;
            TitularModel titular = await _titularRepository.Atualizar(titularModel, id);
            return Ok(titular);
        }

        // Método Deletar, passando {Id} por parâmetro.
        [HttpDelete("{id}")]
        public async Task<ActionResult<TitularModel>> Deletar(int id)
        {
            bool deletado = await _titularRepository.Deletar(id);
            return Ok(deletado);
        }
    }
}

