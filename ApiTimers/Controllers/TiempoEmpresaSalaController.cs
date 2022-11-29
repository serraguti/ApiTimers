using ApiTimers.Models;
using ApiTimers.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTimers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiempoEmpresaSalaController : ControllerBase
    {
        RepositoryTimers repo;

        public TiempoEmpresaSalaController(RepositoryTimers repo)
        {
            this.repo = repo;
        }


        // GET: api/TiempoEmpresaSala
        /// <summary>
        /// Obtiene el conjunto de TIEMPOS_EMPRESAS_SALAS.
        /// </summary>
        /// <remarks>
        /// Método para devolver todos los datos de la tabla TIEMPOS_EMPRESAS_SALAS de la BBDD
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<TiempoEmpresaSala>> GetTiempoEmpresaSalas()
        {
            return this.repo.GetTiempoEmpresaSalas();
        }

        // GET: api/Timers/id
        /// <summary>
        /// Obtiene un TIEMPOS_EMPRESAS_SALAS por su Id. Tabla TIEMPOS_EMPRESAS_SALAS
        /// </summary>
        /// <remarks>
        /// Permite buscar un TIEMPOS_EMPRESAS_SALAS por el ID
        /// </remarks>
        /// <param name="id">Id (GUID) del objeto.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<TiempoEmpresaSala> FindTiempoEmpresaSalas(int id)
        {
            TiempoEmpresaSala tiempoEmpresaSala =
                this.repo.FindTiempoEmpresaSalas(id);
            if (tiempoEmpresaSala == null)
            {
                return NotFound();
            }
            return tiempoEmpresaSala;
        }


        // POST: api/Timers
        /// <summary>
        /// Crea un nuevo registro en TIEMPOS_EMPRESAS_SALAS
        /// </summary>
        /// <remarks>
        /// El ID del evento se genera en la BBDD.
        /// </remarks>
        /// <param name="tiempo">Objeto TiempoEmpresaSala a crear a la BD.</param>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="400">BadRequest. No se ha creado el objeto en la BD. Formato del objeto incorrecto.</response>
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>///  
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult CreateTiempoEmpresaSala
            (TiempoEmpresaSala tiempo)
        {
            TiempoEmpresaSala newTiempo = 
                this.repo.CreateTiempoEmpresaSalas(tiempo.IdTimer
                , tiempo.IdEmpresa, tiempo.IdSala, tiempo.IdEvento);
            return Ok(newTiempo);
        }
    }
}
