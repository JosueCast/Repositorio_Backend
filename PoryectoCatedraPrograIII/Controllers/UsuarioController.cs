using Microsoft.AspNetCore.Mvc;
using PoryectoCatedraPrograIII.Data;
using PoryectoCatedraPrograIII.DTO;
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
        public async Task<ActionResult> InsertarUsuario([FromBody] UsuarioCreateDTO dto)
        {
            if (dto == null ||
                string.IsNullOrWhiteSpace(dto.Nombre) ||
                string.IsNullOrWhiteSpace(dto.Correo) ||
                string.IsNullOrWhiteSpace(dto.Contraseña) ||
                dto.TipoUsuarioId <= 0)
            {
                return BadRequest("Datos de usuario inválidos.");
            }

            var nuevoUsuario = new Usuario
            {
                Nombre = dto.Nombre,
                Correo = dto.Correo,
                Contraseña = dto.Contraseña,
                FotoPerfil = dto.FotoPerfil,
                FechaRegistro = dto.FechaRegistro,
                TipoUsuarioId = dto.TipoUsuarioId
            };

            try
            {
                await _dao.Add(nuevoUsuario);
                await _dao.Save();
                return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevoUsuario.Id }, nuevoUsuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }




        [HttpPut("EditarUsuarios/{id}")]
        public async Task<ActionResult> ActualizarUsuario(int id, [FromBody] UsuarioUpdateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuarioExistente = await _dao.GetById(id);
            if (usuarioExistente == null)
            {
                return NotFound("Usuario no encontrado.");
            }

            // Actualización básica de campos permitidos
            usuarioExistente.Nombre = dto.Nombre;
            usuarioExistente.Correo = dto.Correo;

            if (!string.IsNullOrWhiteSpace(dto.Contraseña))
            {
                usuarioExistente.Contraseña = dto.Contraseña; // Encriptala si es necesario
            }

            usuarioExistente.FotoPerfil = dto.FotoPerfil;

            try
            {
                _dao.Update(usuarioExistente);
                await _dao.Save();
                return Ok(usuarioExistente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar: {ex.Message}");
            }
        }





    }
}

