using Microsoft.AspNetCore.Mvc;
using PoryectoCatedraPrograIII.Data;
using PoryectoCatedraPrograIII.Models;
using PoryectoCatedraPrograIII.Repository;

namespace PoryectoCatedraPrograIII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioDAO _dao;

        public UsuarioController(DBContext context)
        {
            _dao = new UsuarioDAO(context);
        }

        [HttpGet("LeerUsuarios")]
        public async Task<ActionResult<List<Usuario>>> ObtenerListado()
        {
            var usuarios = await _dao.Get();

            // Verificar si la lista está vacía o es nula
            if (usuarios == null || !usuarios.Any())
            {
                return NotFound("No se encontraron usuarios.");
            }
            return Ok(usuarios);
        }


        [HttpGet("ObtenerPorId/{id}")]
        public async Task<ActionResult<Usuario>> ObtenerPorId(int id)
        {
            var usuarios = await _dao.GetById(id);

            if (usuarios == null)
            {
                return NotFound($"No se encontró el usuario con ID {id}");
            }

            return Ok(usuarios);
        }


        [HttpDelete("EliminarUsuario/{id}")]
        public async Task<ActionResult> EliminarUsuario(int id)
        {
            try
            {
                var usuarios = await _dao.GetById(id);
                if (usuarios == null)
                {
                    return NotFound("usuario no encontrado.");
                }

                _dao.Delete(usuarios);
                await _dao.Save();

                return Ok(new { mensaje = "usuario eliminado con éxito" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error interno del servidor", error = ex.Message });
            }
        }


        [HttpPost("InsertarUsuarios")]
        public async Task<ActionResult> InsertarProducto([FromBody] Usuario usuariosDTO)
        {
            if (usuariosDTO == null ||
                string.IsNullOrWhiteSpace(usuariosDTO.Nombre) ||
                string.IsNullOrWhiteSpace(usuariosDTO.Correo) ||
                string.IsNullOrWhiteSpace(usuariosDTO.Contraseña) ||
                
                usuariosDTO.FechaRegistro == default)
            {
                return BadRequest("Datos de producto inválidos.");
            }

            var nuevoProducto = new Usuario
            {
                Nombre = usuariosDTO.Nombre,
                Correo = usuariosDTO.Correo,
                Contraseña = usuariosDTO.Contraseña,
                FotoPerfil = usuariosDTO.FotoPerfil,
                
                FechaRegistro = usuariosDTO.FechaRegistro,
                reviews = usuariosDTO.reviews,
                Favoritos = usuariosDTO.Favoritos,

            };

            await _dao.Add(nuevoProducto);
            await _dao.Save();

            return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevoProducto.Id }, nuevoProducto);
        }


        [HttpPut("EditarUsuarios/{id}")]
        public async Task<ActionResult> ActualizarUsuario(int id, [FromBody] Usuario usuarioDTO)
        {
            if (usuarioDTO == null ||
                string.IsNullOrWhiteSpace(usuarioDTO.Nombre) ||
                string.IsNullOrWhiteSpace(usuarioDTO.Correo) ||
                
                usuarioDTO.FechaRegistro == default)
            {
                return BadRequest("Todos los campos obligatorios deben estar completos.");
            }

            // Obtener el usuario desde la base de datos
            var usuarioExistente = await _dao.GetById(id);
            if (usuarioExistente == null)
            {
                return NotFound("Usuario no encontrado.");
            }

            // Actualizar los datos del usuario existente
            usuarioExistente.Nombre = usuarioDTO.Nombre;
            usuarioExistente.Correo = usuarioDTO.Correo;
            usuarioExistente.Contraseña = usuarioDTO.Contraseña; // Se recomienda encriptarla antes de guardar
            usuarioExistente.FotoPerfil = usuarioDTO.FotoPerfil;
            
            usuarioExistente.FechaRegistro = usuarioDTO.FechaRegistro;
            usuarioExistente.reviews = usuarioDTO.reviews;
            usuarioExistente.Favoritos = usuarioDTO.Favoritos;

            // Realizar la actualización
            _dao.Update(usuarioExistente);
            await _dao.Save();

            return Ok(usuarioExistente);  // Retornar el usuario actualizado
        }




    }
}

