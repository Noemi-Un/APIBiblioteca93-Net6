using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi93.Services.IServices;

namespace WebApi93.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServices _usuarioServices;
        public UsuarioController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var response = await _usuarioServices.ObtenerUsuarios();

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUser(int id)
        {
            return Ok(await _usuarioServices.ByID(id));

        }

        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] UsuarioResponse request)
        {
            return Ok(await _usuarioServices.Crear(request));

        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutUser(int id, [FromBody] UsuarioResponse request)
        {
            var result = await _usuarioServices.Actualizar(id, request);
            if (result.Succeded)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _usuarioServices.Eliminar(id);
            if (result.Succeded)
                return Ok(result);
            return BadRequest(result);
        }

    }
}