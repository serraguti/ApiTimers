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

        [HttpGet]
        public ActionResult<List<Sala>> GetSalas()
        {
            return this.repo.GetSalas();
        }

        [HttpGet("{id}")]
        public ActionResult<Sala> FindSala(int id)
        {
            return this.repo.FindSala(id);
        }


        [HttpPost]
        [Route("[action]/{nombresala}")]
        public void CreateSala(string nombresala)
        {
            this.repo.CreateSala(nombresala);
        }

        [HttpPut]
        [Route("[action]/{id}/{nombresala}")]
        public void UpdateSala(int id, string nombresala)
        {
            this.repo.UpdateSala(id, nombresala);
        }

        //DELETE api/[controller]/{id}
        [HttpDelete("{id}")]
        public void DeleteSala(int id)
        {
            this.repo.DeleteSala(id);
        }
    }
}
