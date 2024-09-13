using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using lab5_backend.Models;
using lab5_backend.Handlers;

namespace lab5_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        private readonly PaisHandler paisesHandler;
        public PaisController()
        {
            paisesHandler = new PaisHandler();
        }

        [HttpGet]
        public List<PaisModel> Get()
        {
            var paises = paisesHandler.ObtenerPaises();
            return paises;
        }

    }
}
