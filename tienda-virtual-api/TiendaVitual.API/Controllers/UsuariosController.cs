using Microsoft.AspNetCore.Mvc;
using TiendaVirtual.Logica;
using TiendaVirtual.Modelos;

namespace TiendaVitual.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        [HttpGet]
        public IActionResult ObtenerListaUsuarios()
        {
            UsuarioServicio servicio = new UsuarioServicio();
            List<Usuario> listaUsuarios = servicio.ObtenerUsuarios();
            return Ok(listaUsuarios);
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerUsuarioPorId(int id)
        {
            UsuarioServicio servicio = new UsuarioServicio();
            Usuario usuario = servicio.ObtenerUsuarioPorId(id);
            return Ok(usuario);
        }


        [HttpPost()]
        public IActionResult RegistroUsuario([FromBody] Usuario nuevoUsuario)
        {
            UsuarioServicio servicio = new UsuarioServicio();
            
            servicio.AgregarUsuario(nuevoUsuario);

            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginCredenciales credenciales)
        {
            UsuarioServicio servicio = new UsuarioServicio();
            Usuario usuario = servicio.ObtenerUsuarioPorCredenciales(credenciales);
           
            if (usuario == null) return Unauthorized();
            return Ok(usuario);
        }


    }
}

