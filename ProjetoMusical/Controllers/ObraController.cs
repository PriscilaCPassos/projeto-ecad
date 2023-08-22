using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoMusical.Models;
using ProjetoMusical.Repository.Interface;

namespace ProjetoMusical.Controllers
{
    // O acesso para essa Api será: A porta e O IP da nossa Api/Titular -> 'https://localhost:7271/api/Obra'
    [Route("api/[controller]")]
    [ApiController]
    public class ObraController : ControllerBase
    {
        // Criando construtor e definindo as injeções de dependências.
        private readonly IObraRepository _obraRepository;
        public ObraController(IObraRepository obraRepository)
        {
            _obraRepository = obraRepository;
        }

        //Método criado para buscar as obras.
        // Definindo o endpoint.
        [HttpGet]
        public async Task<ActionResult<List<ObraModel>>> ListarTodasObras()
        {
            List<ObraModel> obras = await _obraRepository.BuscarTodasObras();
            return Ok(obras);
        }

        // Método Buscar, passando {Id} por parâmetro.
        [HttpGet("{id}")]
        public async Task<ActionResult<ObraModel>> BuscarPorId(int id)
        {
            ObraModel obra = await _obraRepository.BuscarPorId(id);
            return Ok(obra);
        }

        // Método Cadastrar.
        [HttpPost]
        public async Task<ActionResult<ObraModel>> Cadastrar([FromBody] ObraModel obraModel)
        {
            ObraModel obra = await _obraRepository.Adicionar(obraModel);
            return Ok(obra);
        }

        // Método Atualizar, passando {Id} por parâmetro.
        [HttpPut("{id}")]
        public async Task<ActionResult<ObraModel>> Atualizar([FromBody] ObraModel obraModel, int id)
        {
            obraModel.Id = id;
            ObraModel obra = await _obraRepository.Atualizar(obraModel, id);
            return Ok(obra);
        }

        // Método Deletar, passando {Id} por parâmetro.
        [HttpDelete("{id}")]
        public async Task<ActionResult<ObraModel>> Deletar(int id)
        {
            bool deletado = await _obraRepository.Deletar(id);
            return Ok(deletado);
        }
    }
}

