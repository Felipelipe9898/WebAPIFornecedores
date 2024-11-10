using APIFornecedores.Models;
using APIFornecedores.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIFornecedores.Controllers
{
    [Route("api/fornecedores")]
    [ApiController]
    [Produces("application/json")]
    public class FornecedoresController : ControllerBase
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        public FornecedoresController(IFornecedorRepository fornecedorRepository)
        {
          _fornecedorRepository = fornecedorRepository; 
        }

        /// <summary>
        /// Retorna todos os fornecedores.
        /// </summary>
        /// <returns>Uma lista de objetos Fornecedores</returns>
        /// <response code="200">Retorna a lista de fornecedores</response>
        /// <response code="404">Fornencedores não encontrados</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Fornecedor>>> Get()
        {
            var fornecedores = await _fornecedorRepository.GetFornecedoresAsync();

            if (fornecedores is null)
            {
                return NotFound("Não existem fornecedores cadastrados.");
            }
            return Ok(fornecedores);
        }

        /// <summary>
        /// Retorna um Fornecedor específico pelo seu Id
        /// </summary>
        /// <param name="id">O identificador único do fornecedor a ser consultado.</param>
        /// <returns>Dados do fornecedor.</returns>
        /// <response code="200">Retorna o fornecedor</response>
        /// <response code="404">Fornecedor não encontrado</response>
        [HttpGet("{id:int}", Name = "ObterFornecedor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Fornecedor>> Get(int id)
        {
            var fornecedor = await _fornecedorRepository.GetFornecedorAsync(id);
            if (fornecedor is  null)
                return NotFound("Fornecedor não encontrado.");

            return Ok(fornecedor);
        }

        /// <summary>
        /// Inclui um novo fornecedor
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        ///
        ///     POST api/fornecedores
        ///     {
        ///       "nome": "Felipe Marciano",
        ///       "email": "felipe.marciano@gmail.com",
        ///       "telefone": "47996018805",
        ///       "cnpJ_CPF": "026.982.440-54",
        ///       "nomeFantasia": "Felipe LTDA"
        ///     }
        /// </remarks> 
        /// <param name="fornecedor">Objeto Fornecedor</param>
        /// <returns>O fornecedor criado</returns>
        /// <response code="200">Retorna o fornecedor criado com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Fornecedor>> Post(Fornecedor fornecedor)
        {
            if (fornecedor is null)
                return BadRequest("Dados inválidos");

            var forneccedorExistente = await _fornecedorRepository.GetFornecedorAsync(fornecedor.Id);

            if (forneccedorExistente != null)
            {
                return BadRequest($"O id:{fornecedor.Id} não pode ser usado, pois já existe um fornecedor com este identificador.");
            }

            var fornecedorCriado = await _fornecedorRepository.CreateAsync(fornecedor);
            return new CreatedAtRouteResult("ObterFornecedor",
                   new { id = fornecedorCriado.Id }, fornecedorCriado);

        }

        /// <summary>
        /// Atualiza os dados de um fornecedor que já existe.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        ///
        ///     PUT api/fornecedores/{id}
        ///     {
        ///       "id": 1,
        ///       "nome": "Felipe Marciano 2",
        ///       "email": "felipe.marciano@gmail.com",
        ///       "telefone": "47996018805",
        ///       "cnpJ_CPF": "026.982.440-54",
        ///       "nomeFantasia": "Felipe LTDA"
        ///     }
        /// </remarks> 
        /// <param name="id">ID do fornecedor á ser atualizado.</param>
        /// <param name="fornecedor">Dados atualizados do fornecedor.</param>
        /// <returns>Fornecedor atualizado.</returns>
        /// <response code="200">Retorna o fornecedor atualizado com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="404">Fornecedor não encontrado</response>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Fornecedor>> Put(int id, Fornecedor fornecedor)
        {
            if (id != fornecedor.Id)
                return BadRequest("O identificador informado não é o mesmo do Fornecedor que está sendo atualizado. Para atualizar o fornecedor informe identificadores iguais.");

            var result = await _fornecedorRepository.UpdateAsync(fornecedor);
            if (result is null)
                return NotFound("Fornecedor não encontrado.");

            return Ok(result);
        }
        /// <summary>
        /// Remove um fornecedor pelo ID.
        /// </summary>
        /// <param name="id">ID do fornecedor que deseja remover.</param>
        /// <returns>Fornecedor deletado.</returns>
        /// <response code="200">Retorna o fornecedor que foi removido com sucesso</response>
        /// <response code="404">Fornecedor não encontrado</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Fornecedor>> Delete(int id)
        {
            var fornecedor = await _fornecedorRepository.GetFornecedorAsync(id);


            if (fornecedor is null)
            {
                return NotFound("Fornecedor não encontrado. Informe um identificador existente para excluir um fornecedor.");
            }

            var fornecedorExcluido = await _fornecedorRepository.DeleteAsync(id);

            return Ok(fornecedorExcluido);
        }
    }
}
