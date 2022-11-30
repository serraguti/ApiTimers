using ApiTimers.Models;
using ApiTimers.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace ApiTimers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [OpenApiTag("USUARIOS")]
    public class UsuariosController : ControllerBase
    {
        RepositoryTimers repo;

        public UsuariosController(RepositoryTimers repo)
        {
            this.repo = repo;
        }

        // GET: api/Usuarios
        /// <summary>
        /// Obtiene el conjunto de USUARIOS
        /// </summary>
        /// <remarks>
        /// Devuelve los datos de la Vista USUARIOS
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Usuario>> GetUsuarios()
        {
            return this.repo.GetUsuarios();
        }

        // POST: api/Usuarios
        /// <summary>
        /// Crea un nuevo USUARIO en la BBDD, tabla USUARIOS.
        /// </summary>
        /// <remarks>
        /// El ID del Usuario se genera en la BBDD.
        /// Devuelve un objeto Usuario creado
        /// </remarks>
        /// <param name="user">Objeto USUARIO a crear a la BD.</param>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="400">BadRequest. No se ha creado el objeto en la BD. Formato del objeto incorrecto.</response>
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>///  
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Evento> CreateUsuario(Usuario user)
        {
            Usuario newUser =
                this.repo.CreateUser(user.UserName, user.Password);
            return Ok(newUser);
        }

        // PUT: api/Usuarios
        /// <summary>
        /// Modifica un Usuario en la BBDD, tabla USUARIOS.
        /// </summary>
        /// <remarks>
        /// Debemos enviar un objeto Usuario con el ID existente
        /// </remarks>
        /// <param name="user">Objeto Usuario a modificar en la BD.</param>
        /// <response code="201">Modified. Objeto correctamente modificado en la BBDD.</response>        
        /// <response code="400">BadRequest. No se ha creado el objeto en la BD. Formato del objeto incorrecto.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha modificado el objeto en la BD. Error en la BBDD.</response>///  
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult UpdateUsuario(Usuario user)
        {
            if (this.repo.FindUser(user.IdUsuario) == null)
            {
                return NotFound();
            }
            else
            {
                this.repo.UpdateUsuario(user.IdUsuario, user.UserName
                    , user.Password);
                return Ok();
            }
        }

        // DELETE: api/Usuarios/{id}
        /// <summary>
        /// Elimina un Usuario en la BBDD mediante su ID.
        /// </summary>
        /// <remarks>
        /// Enviaremos el ID de USUARIO mediante la URL
        /// </remarks>
        /// <param name="id">ID del Usuario a eliminar</param>
        /// <response code="201">Deleted. Objeto eliminado en la BBDD.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha eliminado el objeto en la BD. Error en la BBDD.</response>/// 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult DeleteUsuario(int id)
        {
            if (this.repo.FindUser(id) == null)
            {
                return NotFound();
            }
            else
            {
                this.repo.DeleteUsuario(id);
                return Ok();
            }
        }
    }
}
