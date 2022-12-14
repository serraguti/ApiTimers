using ApiTimers.Models;
using ApiTimers.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace ApiTimers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [OpenApiTag("EVENTOS")]
    public class EventosController : ControllerBase
    {
        RepositoryTimers repo;

        public EventosController(RepositoryTimers repo)
        {
            this.repo = repo;
        }

        // GET: api/Eventos
        /// <summary>
        /// Obtiene el conjunto de Eventos, tabla EVENTOS.
        /// </summary>
        /// <remarks>
        /// Método para devolver todos los eventos de la BBDD
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Evento>> GetEventos()
        {
            return this.repo.GetEventos();
        }

        // GET: api/Eventos/id
        /// <summary>
        /// Obtiene un Evento por su Id, tabla EVENTOS.
        /// </summary>
        /// <remarks>
        /// Permite buscar un Evento por el ID de Evento
        /// </remarks>
        /// <param name="id">Id (GUID) del objeto.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Evento> FindEvento(int id)
        {
            Evento evento = this.repo.FindEvento(id);
            if (evento == null)
            {
                return NotFound();
            }
            return evento;
        }


        // POST: api/Evento
        /// <summary>
        /// Crea un nuevo Evento en la BBDD, tabla EVENTOS.
        /// </summary>
        /// <remarks>
        /// El ID del evento se genera en la BBDD.
        /// </remarks>
        /// <param name="evento">Objeto Evento a crear a la BD.</param>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="400">BadRequest. No se ha creado el objeto en la BD. Formato del objeto incorrecto.</response>
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>///  
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Evento> CreateEvento(Evento evento)
        {
            Evento newEvento = 
                this.repo.CreateEvento(evento.NombreEvento, evento.InicioEvento
                , evento.FinEvento);
            return Ok(newEvento);
        }

        // PUT: api/Evento
        /// <summary>
        /// Modifica un Evento en la BBDD, tabla EVENTOS.
        /// </summary>
        /// <remarks>
        /// Debemos enviar un objeto Evento con el ID existente
        /// </remarks>
        /// <param name="evento">Objeto Evento a modificar en la BD.</param>
        /// <response code="201">Modified. Objeto correctamente modificado en la BBDD.</response>        
        /// <response code="400">BadRequest. No se ha creado el objeto en la BD. Formato del objeto incorrecto.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha modificado el objeto en la BD. Error en la BBDD.</response>///  
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult UpdateEvento(Evento evento)
        {
            if (this.repo.FindEvento(evento.IdEvento) == null) {
                return NotFound();
            }
            else
            {
                this.repo.UpdateEvento(evento.IdEvento, evento.NombreEvento
                    , evento.InicioEvento, evento.FinEvento);
                return Ok();
            }
        }

        // DELETE: api/Evento/{id}
        /// <summary>
        /// Elimina un Evento en la BBDD mediante su ID.
        /// </summary>
        /// <remarks>
        /// Enviaremos el ID mediante la URL
        /// </remarks>
        /// <param name="id">ID del evento a eliminar</param>
        /// <response code="201">Deleted. Objeto eliminado en la BBDD.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha eliminado el objeto en la BD. Error en la BBDD.</response>/// 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult DeleteEvento(int id)
        {
            if (this.repo.FindEvento(id) == null)
            {
                return NotFound();
            }
            else
            {
                this.repo.DeleteEvento(id);
                return Ok();
            }
        }
    }
}
