using ApiTimers.Models;
using ApiTimers.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTimers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalasController : ControllerBase
    {
        RepositoryTimers repo;

        public SalasController(RepositoryTimers repo)
        {
            this.repo = repo;
        }

        // GET: api/Salas
        /// <summary>
        /// Obtiene el conjunto de Salas, tabla SALAS.
        /// </summary>
        /// <remarks>
        /// Método para devolver todas las salas de la BBDD
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Sala>> GetSalas()
        {
            return this.repo.GetSalas();
        }

        // GET: api/Salas/id
        /// <summary>
        /// Obtiene una Sala por su Id, tabla SALAS.
        /// </summary>
        /// <remarks>
        /// Permite buscar una Sala por su ID
        /// </remarks>
        /// <param name="id">Id (GUID) del objeto.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Sala> FindSala(int id)
        {
            Sala sala = this.repo.FindSala(id);
            if (sala == null)
            {
                return NotFound();
            }
            return sala;
        }


        // POST: api/CreateSala/{nombresala}
        /// <summary>
        /// Crea una nueva Sala en la BBDD, tabla SALAS.
        /// </summary>
        /// <remarks>
        /// El ID de la sala se genera en la BBDD.
        /// El parámetro del nombre se envía mediante URL
        /// </remarks>
        /// <param name="nombresala">Nombre de la sala a crear en la BD.</param>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>///  
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("[action]/{nombresala}")]
        public ActionResult CreateSala(string nombresala)
        {
            Sala sala = this.repo.CreateSala(nombresala);
            return Ok(sala);
        }

        // POST: api/UpdateSala/{id},{nombresala}
        /// <summary>
        /// Modifica una Sala en la BBDD.
        /// </summary>
        /// <remarks>
        /// El ID de la sala y el nombre se envía mediante URL.
        /// </remarks>
        /// <param name="id">Id de la Sala a modificar</param>
        /// <param name="nombresala">Nuevo nombre de la Sala</param>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>  
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>            
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>///  
        [HttpPut]
        [Route("[action]/{id}/{nombresala}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult UpdateSala(int id, string nombresala)
        {
            if (this.repo.FindSala(id) == null)
            {
                return NotFound();
            }
            else
            {
                this.repo.UpdateSala(id, nombresala);
                return Ok();
            }
            
        }

        //DELETE api/[controller]/{id}
        // DELETE: api/Evento/{id}
        /// <summary>
        /// Elimina una Sala en la BBDD mediante su ID.
        /// </summary>
        /// <remarks>
        /// Enviaremos el ID mediante la URL
        /// </remarks>
        /// <param name="id">ID de la Sala a eliminar</param>
        /// <response code="201">Deleted. Objeto eliminado en la BBDD.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha eliminado el objeto en la BD. Error en la BBDD.</response>/// 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult DeleteSala(int id)
        {
            if (this.repo.FindSala(id) == null)
            {
                return NotFound();
            }
            else
            {
                this.repo.DeleteSala(id);
                return Ok();
            }
        }
    }
}
