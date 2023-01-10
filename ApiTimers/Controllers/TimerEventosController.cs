using ApiTimers.Models;
using ApiTimers.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace ApiTimers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [OpenApiTag("TIEMPOS_EVENTOS")]
    public class TimerEventosController : ControllerBase
    {
        RepositoryTimers repo;

        public TimerEventosController(RepositoryTimers repo)
        {
            this.repo = repo;
        }

        // GET: api/TimerEventos
        /// <summary>
        /// Obtiene el conjunto de TIEMPOS EVENTOS (Vista TIEMPOS_EVENTOS).
        /// </summary>
        /// <remarks>
        /// Devuelve los datos de la Vista TIEMPOS_EVENTOS
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<TimerEvento>> GetTimerEventos()
        {
            return this.repo.GetTimersEventos();
        }

        // GET: api/TimerEventos/EventosEmpresa/{idempresa}
        /// <summary>
        /// Busca los TIEMPOS EVENTOS por EMPRESA (Vista TIEMPOS_EVENTOS).
        /// </summary>
        /// <remarks>
        /// Devuelve los datos de la Vista TIEMPOS_EVENTOS filtrados por el ID Empresa
        /// </remarks>
        /// <param name="idempresa">Id empresa a filtrar</param>        
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("[action]/{idempresa}")]
        public ActionResult<List<TimerEvento>> EventosEmpresa
            (int idempresa)
        {
            return this.repo.GetTimersEventosEmpresa(idempresa);
        }

    // GET: api/TimerEventos/EventosCategoria/{idcategoria}
    /// <summary>
    /// Busca los TIEMPOS EVENTOS por CATEGORIA (Vista TIEMPOS_EVENTOS).
    /// </summary>
    /// <remarks>
    /// Devuelve los datos de la Vista TIEMPOS_EVENTOS filtrados por el ID Empresa
    /// </remarks>
    /// <param name="idcategoria">Id categoria a filtrar</param>        
    /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
    [HttpGet]
        [Route("[action]/{idcategoria}")]
        public ActionResult<List<TimerEvento>> EventosCategoria
            (int idcategoria)
        {
            return this.repo.GetTimersEventosCategoria(idcategoria);
        }

        // GET: api/TimerEventos/EventosSala/{idsala}
        /// <summary>
        /// Busca los TIEMPOS EVENTOS por SALAS (Vista TIEMPOS_EVENTOS).
        /// </summary>
        /// <remarks>
        /// Devuelve los datos de la Vista TIEMPOS_EVENTOS filtrados por el ID Sala
        /// </remarks>
        /// <param name="idsala">Id sala a filtrar</param>        
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [Route("[action]/{idsala}")]
        public ActionResult<List<TimerEvento>> EventosSala
            (int idsala)
        {
            return this.repo.GetTimersEventosSalas(idsala);
        }

        // GET: api/Timers/id
        /// <summary>
        /// Obtiene un TIEMPOS EVENTOS por su Id. Vista TIEMPOS_EVENTOS
        /// </summary>
        /// <remarks>
        /// Permite buscar un TIEMPOS EVENTOS por el ID
        /// </remarks>
        /// <param name="id">Id (GUID) del objeto.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<TimerEvento> FindTimerEvento(int id)
        {
            TimerEvento timer = this.repo.FindTimersEventos(id);
            if (timer == null)
            {
                return NotFound();
            }
            return timer;
        }

        // GET: api/EmpresasTimers
        /// <summary>
        /// Busca las DISTINTAS EMPRESAS que están asignadas en tiempos (Vista TIEMPOS_EVENTOS).
        /// </summary>
        /// <remarks>
        /// Devuelve los datos de la Vista TIEMPOS_EVENTOS de Empresas
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("[action]")]
        public ActionResult<List<Empresa>> EmpresasTimers()
        {
            var empresas = this.repo.GetTimersEmpresa();
            if (empresas == null)
            {
                return NotFound();
            }
            else
            {
                return empresas;
            }
            
        }
    }
}
