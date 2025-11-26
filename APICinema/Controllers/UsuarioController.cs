using APICinema.Data;
using APICinema.DTOS;
using APICinema.Model;
using APICinema.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace APICinema.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> CriarUsuario([FromBody] UsuarioCreateDto usuarioDto)
        {
            var usuario = await _usuarioService.CriarUsuarioAsync(usuarioDto);
            return CreatedAtAction(nameof(BuscarUsuario), new {id = usuario.Id}, usuario);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarUsuario(int id)
        {
            var usuario = await _usuarioService.FindByIdAsync(id);
            if(usuario == null) return NotFound();
            return Ok(usuario);
        }

    }
}
