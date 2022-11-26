using ApiTimers.Models;
using ApiTimers.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTimers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimerEventosController : ControllerBase
    {
        RepositoryTimers repo;

        public TimerEventosController(RepositoryTimers repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<TimerEvento>> GetTimerEventos()
        {
            return this.repo.GetTimersEventos();
        }

        [HttpGet]
        [Route("[action]/{idempresa}")]
        public ActionResult<List<TimerEvento>> EventosEmpresa(int idempresa)
        {
            return this.repo.GetTimersEventosEmpresa(idempresa);
        }

        [HttpGet]
        [Route("[action]/{idcategoria}")]
        public ActionResult<List<TimerEvento>> EventosCategoria(int idcategoria)
        {
            return this.repo.GetTimersEventosCategoria(idcategoria);
        }

        [HttpGet]
        [Route("[action]/{idsala}")]
        public ActionResult<List<TimerEvento>> EventosSala(int idsala)
        {
            return this.repo.GetTimersEventosSalas(idsala);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<TimerEvento> FindTimerEvento(int id)
        {
            return this.repo.FindTimersEventos(id);
        }
    }
}
