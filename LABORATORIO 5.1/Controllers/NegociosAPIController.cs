using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LABORATORIO_5._1.Entities;
using LABORATORIO_5._1.DAO;

namespace LABORATORIO_5._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class NegociosAPIController : Controller
    {
        /* Definir los metodos Get() */
        [HttpGet("GetClientes")]public async Task<ActionResult<List<Cliente>>> Get()
        {
            var lista = await Task.Run(() => (new ClienteDAO()).GetClientes());
            return Ok(lista);
        }

        [HttpPost("GetPaises")]public async Task<ActionResult<List<Cliente>>> GetPais()
        {
            var lista = await Task.Run(() => (new PaisDAO()).GetPaises());
            return Ok(lista);
        }

        /* Definir los metodos InsertaCliente() */
        [HttpPost("AddCliente")] public async Task<ActionResult<string>> InsertaCliente(Cliente reg)
        {
            var mensaje = await Task.Run(() => (new ClienteDAO()).Agregar(reg));
            return Ok(mensaje);
        }

        [HttpPost("UpdateCliente")] public async Task<ActionResult<string>> ActualizaCliente(Cliente reg)
        {
            var mensaje = await Task.Run(() => (new ClienteDAO()).Actualizar(reg));
            return Ok(mensaje);
        }
    }
}
