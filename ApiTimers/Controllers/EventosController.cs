using ApiTimers.Models;
using ApiTimers.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTimers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        RepositoryTimers repo;

        public EventosController(RepositoryTimers repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Evento>> GetEventos()
        {
            return this.repo.GetEventos();
        }

        [HttpGet("{id}")]
        public ActionResult<Evento> FindEvento(int id)
        {
            return this.repo.FindEvento(id);
        }


        [HttpPost]
        public void CreateEvento(Evento evento)
        {
            this.repo.CreateEvento(evento.NombreEvento, evento.InicioEvento
                , evento.FinEvento);
        }

        //PUT api/[controller]
        [HttpPut]
        public void UpdateEvento(Evento evento)
        {
            this.repo.UpdateEvento(evento.IdEvento, evento.NombreEvento
                , evento.InicioEvento, evento.FinEvento);
        }

        //DELETE api/[controller]/{id}
        [HttpDelete("{id}")]
        public void DeleteEvento(int id)
        {
            this.repo.DeleteEvento(id);
        }

    }
}
