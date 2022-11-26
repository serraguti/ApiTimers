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

        [HttpGet]
        public ActionResult<List<TiempoEmpresaSala>> GetTiempoEmpresaSalas()
        {
            return this.repo.GetTiempoEmpresaSalas();
        }

        [HttpGet("{id}")]
        public ActionResult<TiempoEmpresaSala> FindTiempoEmpresaSalas(int id)
        {
            return this.repo.FindTiempoEmpresaSalas(id);
        }

        [HttpPost]
        public ActionResult CreateTiempoEmpresaSala(TiempoEmpresaSala tiempo)
        {
            this.repo.CreateTiempoEmpresaSalas(tiempo.IdTimer
                , tiempo.IdEmpresa, tiempo.IdSala, tiempo.IdEvento);
            return Ok();
        }
    }
}
