using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using lab5_backend.Models;
using lab5_backend.Handlers;
using System.Linq.Expressions;

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
        [HttpPost]
        public async Task<ActionResult<bool>> CrearPais(PaisModel pais)
        {
            try{
                if (pais == null)
                {
                    return BadRequest();
                }

                PaisHandler paisesHandler = new PaisHandler();
                var resultado = paisesHandler.CrearPais(pais);
                return new JsonResult(resultado);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creando país");
            }
        }
    }

}
