using ApiTimers.Models;
using ApiTimers.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTimers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimersController : ControllerBase
    {
        RepositoryTimers repo;

        public TimersController(RepositoryTimers repo)
        {
            this.repo = repo;
        }

        // GET: api/Timers
        /// <summary>
        /// Obtiene el conjunto de Timers (Tabla TEMPORIZADORES).
        /// </summary>
        /// <remarks>
        /// Devuelve los datos de la tabla TEMPORIZADORES
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Temporizador>> GetTimers()
        {
            return this.repo.GetTiempos();
        }

        // GET: api/Timers/id
        /// <summary>
        /// Obtiene un TEMPORIZADOR por su Id. Tabla TEMPORIZADORES
        /// </summary>
        /// <remarks>
        /// Permite buscar un TEMPORIZADOR por el ID
        /// </remarks>
        /// <param name="id">Id (GUID) del objeto.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Temporizador> FindTimer(int id)
        {
            Temporizador timer = this.repo.FindTemporizador(id);
            if (timer == null)
            {
                return NotFound();
            }
            return timer;
        }

        // POST: api/Timers
        /// <summary>
        /// Crea un nuevo Timer en TEMPORIZADORES BBDD.
        /// </summary>
        /// <remarks>
        /// El ID del TEMPORIZADOR se genera en la BBDD.
        /// </remarks>
        /// <param name="timer">Objeto Evento a crear a la BD.</param>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="400">BadRequest. No se ha creado el objeto en la BD. Formato del objeto incorrecto.</response>
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>///  
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Temporizador> CreateTimer(Temporizador timer)
        {
            Temporizador newTimer = this.repo.CreateTemporizador(timer.Inicio
                , timer.IdCategoria);
            return Ok(newTimer);
        }

        // PUT: api/Timers
        /// <summary>
        /// Modifica un Timer en la tabla TEMPORIZADORES.
        /// </summary>
        /// <remarks>
        /// Debemos enviar un objeto Temporizador con un ID existente
        /// </remarks>
        /// <param name="timer">Objeto Evento a modificar en la BD.</param>
        /// <response code="201">Modified. Objeto correctamente modificado en la BBDD.</response>        
        /// <response code="400">BadRequest. No se ha creado el objeto en la BD. Formato del objeto incorrecto.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha modificado el objeto en la BD. Error en la BBDD.</response>///  
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult UpdateTimer(Temporizador timer)
        {
            if (this.repo.FindTemporizador(timer.IdTemporizador) == null)
            {
                return NotFound();
            }
            else
            {
                this.repo.UpdateTemporizador(timer.IdTemporizador
                    , timer.Inicio, timer.IdCategoria, timer.Pausa);
                return Ok();
            }
        }

        // PUT: api/Times/{id}
        /// <summary>
        /// Pausa un Timer en la tabla TEMPORIZADORES.
        /// </summary>
        /// <remarks>
        /// Debemos enviar un ID del Temporizador para pausar a True
        /// </remarks>
        /// <param name="idtimer">Id del TEMPORIZADOR a modificar</param>
        /// <response code="201">Modified. Objeto TEMPORIZADOR modificado.</response>        
        /// <response code="400">BadRequest. No se ha creado el objeto en la BD. Formato del objeto incorrecto.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha modificado el objeto en la BD. Error en la BBDD.</response>///  
        [HttpPut]
        [Route("[action]/{idtimer}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult PausarTimer(int idtimer)
        {
            if (this.repo.FindTemporizador(idtimer) == null)
            {
                return NotFound();
            }
            else
            {
                this.repo.PausarTemporizador(idtimer);
                return Ok();
            }
        }

        // DELETE: api/Timers/{id}
        /// <summary>
        /// Elimina un TEMPORIZADOR en la BBDD mediante su ID.
        /// </summary>
        /// <remarks>
        /// Enviaremos el ID del TEMPORIZADOR mediante la URL
        /// </remarks>
        /// <param name="id">ID del TEMPORIZADOR a eliminar</param>
        /// <response code="201">Deleted. Objeto eliminado en la BBDD.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha eliminado el objeto en la BD. Error en la BBDD.</response>/// 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult DeleteTimer(int id)
        {
            if (this.repo.FindTemporizador(id) == null)
            {
                return NotFound();
            }
            else
            {
                this.repo.DeleteTemporizador(id);
                return Ok();
            }
        }
    }
}
