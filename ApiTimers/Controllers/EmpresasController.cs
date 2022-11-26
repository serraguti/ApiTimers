using ApiTimers.Models;
using ApiTimers.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTimers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        RepositoryTimers repo;

        public EmpresasController(RepositoryTimers repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Empresa>> GetEmpresas()
        {
            return this.repo.GetEmpresas();
        }

        [HttpGet("{id}")]
        public ActionResult<Empresa> FindEmpresa(int id)
        {
            return this.repo.FindEmpresa(id);
        }

        [HttpPost]
        [Route("[action]/{nombre}")]
        public ActionResult CreateEmpresa(string nombre)
        {
            this.repo.CreateEmpresa(nombre);
            return Ok();
        }

        [HttpPost]
        [Route("[action]/{idempresa}/{nombre}")]
        public ActionResult UpdateEmpresa(int id, string nombre)
        {
            this.repo.UpdateEmpresa(id,nombre);
            return Ok();
        }
    }
}
