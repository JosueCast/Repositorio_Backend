using Microsoft.AspNetCore.Mvc;
using PoryectoCatedraPrograIII.Data;
using PoryectoCatedraPrograIII.DTO;
using PoryectoCatedraPrograIII.Models;
using PoryectoCatedraPrograIII.Repository;

namespace PoryectoCatedraPrograIII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : Controller
    {
       
        private readonly TipoUsuarioDAO _dao;

        public TipoUsuarioController(DBContext context)
        {
            _dao = new TipoUsuarioDAO(context);
        }

        //Metodo Get obtner TiposUsuarios
        [HttpGet("LeerTiposUsuarios")]
        public async Task<ActionResult<List<TipoUsuario>>> ObtenerListado()
        {
            var tipousuarios = await _dao.Get();

            // Verificar si la lista está vacía o es nula
            if (tipousuarios == null || !tipousuarios.Any())
            {
                return NotFound("No se encontraron usuarios.");
            }
            return Ok(tipousuarios);
        }


        //metodo para obtenerpor ID
        [HttpGet("ObtenerPorId/{id}")]
        public async Task<ActionResult<TipoUsuarioDAO>> ObtenerPorId(int id)
        {
            var tipousuarios = await _dao.GetById(id);

            if (tipousuarios == null)
            {
                return NotFound($"No se encontró el usuario con ID {id}");
            }

            return Ok(tipousuarios);
        }


        //Metodo para Insertar
        [HttpPost("Insertar_TipoUsuario")]
        public async Task<ActionResult> InsertarTipoUsuario([FromBody] TipoUsuario tipoUsuarioDTO)
        {
            // Validamos los datos recibidos
            if (tipoUsuarioDTO == null || string.IsNullOrWhiteSpace(tipoUsuarioDTO.Nombre))
            {
                return BadRequest("Datos de TipoUsuario inválidos. El campo 'Nombre' es obligatorio.");
            }

            var nuevoTipoUsuario = new TipoUsuario
            {
                Nombre = tipoUsuarioDTO.Nombre
            };

            try
            {
                // Insertamos en la base de datos
                await _dao.Add(nuevoTipoUsuario); // Método Add debe estar configurado en tu servicio/repo
                await _dao.Save(); // Método Save para confirmar cambios

                // Devolvemos el registro creado con su ID
                return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevoTipoUsuario.Id }, nuevoTipoUsuario);
            }
            catch (Exception ex)
            {
                // Manejo de errores internos
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }


        //Metodo update Tipo Usuario
        [HttpPut("Editar_TipoUsuario/{id}")]
        public async Task<ActionResult> ActualizarTipoUsuario(int id, [FromBody] TipoUsuario tipoUsuarioDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuarioExistente = await _dao.GetById(id);
            if (usuarioExistente == null)
            {
                return NotFound("TipoUsuario no encontrado.");
            }

            // Actualización básica de campos permitidos
            usuarioExistente.Nombre = tipoUsuarioDTO.Nombre;

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

        //Eliminar TipoUsuario
        [HttpDelete("Eliminar_TipoUsuario/{id}")]
        public async Task<ActionResult> EliminarTipoUsuario(int id)
        {
            try
            {
                var tipousuarios = await _dao.GetById(id);
                if (tipousuarios == null)
                {
                    return NotFound("Tipousuario no encontrado.");
                }

                _dao.Delete(tipousuarios);
                await _dao.Save();

                return Ok(new { mensaje = "Tipousuario eliminado con éxito" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error interno del servidor", error = ex.Message });
            }
        }



    }


}
