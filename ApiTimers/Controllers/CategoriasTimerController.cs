using ApiTimers.Models;
using ApiTimers.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace ApiTimers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [OpenApiTag("CATEGORIAS_TIMER")]
    public class CategoriasTimerController : ControllerBase
    {
        RepositoryTimers repo;

        public CategoriasTimerController(RepositoryTimers repo)
        {
            this.repo = repo;
        }

        // GET: api/CategoriasTimer
        /// <summary>
        /// Obtiene el conjunto de Categorias (Tabla CATEGORIAS_TIMER).
        /// </summary>
        /// <remarks>
        /// Devuelve los datos de la tabla CATEGORIAS_TIMER
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<CategoriaTimer>> GetCategoriasTimers()
        {
            return this.repo.GetCategoriasTimer();
        }

        // GET: api/CategoriaTimers/id
        /// <summary>
        /// Obtiene un CATEGORIAS_TIMER por su Id. Tabla CATEGORIAS_TIMER
        /// </summary>
        /// <remarks>
        /// Permite buscar un CATEGORIAS_TIMER por el ID
        /// </remarks>
        /// <param name="id">Id (GUID) del objeto.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CategoriaTimer> 
            FindCategoriaTimer(int id)
        {
            CategoriaTimer cat = this.repo.FindCategoriasTimer(id);
            if (cat == null)
            {
                return NotFound();
            }
            return cat;
        }

        // POST: api/CategoriaTimers
        /// <summary>
        /// Crea una nueva categoria en CATEGORIAS_TIMER.
        /// </summary>
        /// <remarks>
        /// El ID de CATEGORIAS_TIMER se genera en la BBDD.
        /// </remarks>
        /// <param name="categoria">Objeto Evento a crear a la BD.</param>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="400">BadRequest. No se ha creado el objeto en la BD. Formato del objeto incorrecto.</response>
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>///  
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CategoriaTimer> 
            CreateCategoriaTimer(CategoriaTimer categoria)
        {
            CategoriaTimer newCat =
                this.repo.CreateCategoriaTimer
                (categoria.Categoria, categoria.Duracion);
            return Ok(newCat);
        }

        // PUT: api/CategoriaTimers
        /// <summary>
        /// Modifica una categoria en la tabla CATEGORIAS_TIMER.
        /// </summary>
        /// <remarks>
        /// Debemos enviar un objeto CATEGORIAS_TIMER con un ID existente
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
        public ActionResult UpdateCategoriaTimer(CategoriaTimer categoria)
        {
            if (this.repo.FindCategoriasTimer(categoria.IdCategoria) == null)
            {
                return NotFound();
            }
            else
            {
                this.repo.UpdateCategoriaTimer(categoria.IdCategoria
                    , categoria.Categoria, categoria.Duracion);
                return Ok();
            }
        }

        // DELETE: api/CategoriaTimer/{id}
        /// <summary>
        /// Elimina una categoria en la tabla CATEGORIAS_TIMER.
        /// </summary>
        /// <remarks>
        /// Enviaremos el ID del CATEGORIAS_TIMER mediante la URL
        /// </remarks>
        /// <param name="id">ID de CATEGORIAS_TIMER a eliminar</param>
        /// <response code="201">Deleted. Objeto eliminado en la BBDD.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha eliminado el objeto en la BD. Error en la BBDD.</response>/// 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult DeleteCategoriaTimer(int id)
        {
            if (this.repo.FindCategoriasTimer(id) == null)
            {
                return NotFound();
            }
            else
            {
                this.repo.DeleteCategoriaTimer(id);
                return Ok();
            }
        }
    }
}
