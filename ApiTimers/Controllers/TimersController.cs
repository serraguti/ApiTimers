using ApiTimers.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTimers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimersController : ControllerBase
    {
        RepositoryTimers repo;

        public TimersController(RepositoryTimers repo)
        {
            this.repo = repo;
        }


    }
}
