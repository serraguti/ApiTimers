using ApiTimers.Models;
using ApiTimers.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace ApiTimers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [OpenApiTag("EMPRESAS")]
    public class EmpresasController : ControllerBase
    {
        RepositoryTimers repo;
        public EmpresasController(RepositoryTimers repo)
        {
            this.repo = repo;
        }

        // GET: api/Empresa
        /// <summary>
        /// Obtiene el conjunto de empresas, tabla EMPRESAS.
        /// </summary>
        /// <remarks>
        /// Método para devolver todas las empresas de la BBDD
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Empresa>> GetEmpresas()
        {
            return this.repo.GetEmpresas();
        }

        // GET: api/Empresa/id
        /// <summary>
        /// Obtiene una Empresa por su Id, tabla EMPRESAS.
        /// </summary>
        /// <remarks>
        /// Permite buscar una Empresa por el ID de empresa
        /// </remarks>
        /// <param name="id">Id (GUID) del objeto.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Empresa> FindEmpresa(int id)
        {
            var empresa = this.repo.FindEmpresa(id);
            if (empresa == null)
            {
                return NotFound();
            }
            return empresa;
        }

        // POST: api/empresa
        /// <summary>
        /// Crea una nueva Empresa en la BD, tabla EMPRESAS..
        /// </summary>
        /// <remarks>
        /// Este método crea una empresa enviando el Nombre de la empresa por URL
        /// </remarks>
        /// <param name="nombre">String con el nombre de la Empresa.</param>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPost]
        [Route("[action]/{nombre}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Empresa> CreateEmpresa(string nombre)
        {
            Empresa empresa =
                this.repo.CreateEmpresa(nombre);
            return Ok(empresa);
        }

        // PUT: api/empresa
        /// <summary>
        /// Modifica una empresa en la BBDD, tabla EMPRESAS..
        /// </summary>
        /// <remarks>
        /// Modifica una Empresa en la BBDD mediante su ID y el Nombre en URL
        /// </remarks>
        /// <param name="idempresa">ID (Guid) de la Empresaa modificar.</param>
        /// <param name="nombre">String con el nuevo nombre de la Empresa.</param>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPut]
        [Route("[action]/{idempresa}/{nombre}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult UpdateEmpresa(int idempresa, string nombre)
        {
            this.repo.UpdateEmpresa(idempresa, nombre);
            return Ok();
        }
    }
}
