using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ToDoListAPI.Src.Modelos;
using ToDoListAPI.Src.Repositorios;

namespace ToDoListAPI.Src.Controllers
{
    [ApiController]
    [Route("api/Listas")]
    [Produces("application/json")]
    public class ListaControlador : ControllerBase
    {
        #region Atributos
        private readonly ILista _repositorio;
        #endregion

        #region Construtores
        public ListaControlador(ILista repositorio)
        {
            _repositorio = repositorio;
        }
        #endregion

        #region Métodos
        [HttpGet]
        public async Task<ActionResult> PegarTodaListaAsync()
        {
            var lista = await _repositorio.PegarTodaListaAsync();
            if (lista.Count < 1) return NoContent();
            return Ok(lista);
        }

        [HttpGet("id/{idLista}")]
        public async Task<ActionResult> PegarListaPeloPeloIdAsync([FromRoute] int idLista)
        {
            try
            {
                return Ok(await _repositorio.PegarListaPeloIdAsync(idLista));
            }
            catch (Exception ex)
            {
                return NotFound(new { Mensagem = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> NovaListaAsync([FromBody] Lista lista)
        {
            try
            {
                await _repositorio.NovaListaAsync(lista);
                return Created($"api/Listas", lista);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        [HttpPut]
        public async Task<ActionResult> AtualizarListaAsync([FromBody] Lista lista)
        {
            try
            {
                await _repositorio.AtualizarListaAsync(lista);
                return Ok(lista);
            }
            catch(Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        [HttpDelete("deletar/idLista")]
        public async Task<ActionResult> DeletarLista([FromRoute] int idLista)
        {
            try
            {
                await _repositorio.DeletarListaAsync(idLista);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { Mensagem = ex.Message });
            }
        }
        #endregion

    }
}
