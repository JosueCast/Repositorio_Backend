using Microsoft.AspNetCore.Mvc;
using PoryectoCatedraPrograIII.Data;
using PoryectoCatedraPrograIII.Models;
using PoryectoCatedraPrograIII.Repository;

namespace PoryectoCatedraPrograIII.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TipoTiendaController : Controller
    {
        private readonly TipoTiendaDAO _dao;

        public TipoTiendaController(DBContext context)
        {
            _dao = new TipoTiendaDAO(context);
        }


        //Metodo Get obtner TipoTiendas
        [HttpGet("LeerTipoTiendas")]
        public async Task<ActionResult<List<TipoTienda>>> ObtenerListado()
        {
            var tipoTiendas = await _dao.Get();

            // Verificar si la lista está vacía o es nula
            if (tipoTiendas == null || !tipoTiendas.Any())
            {
                return NotFound("No se encontraron tipoTiendas.");
            }
            return Ok(tipoTiendas);
        }


        //metodo para obtenerpor ID
        [HttpGet("ObtenerPorId/{id}")]
        public async Task<ActionResult<TipoTiendaDAO>> ObtenerPorId(int id)
        {
            var tipoTiendas = await _dao.GetById(id);

            if (tipoTiendas == null)
            {
                return NotFound($"No se encontró el tipoTiendas con ID {id}");
            }

            return Ok(tipoTiendas);
        }

        //Metodo para Insertar
        [HttpPost("Insertar_TipoTienda")]
        public async Task<ActionResult> InsertarTipoUsuario([FromBody] TipoTienda tipotiendaDTO)
        {
            // Validamos los datos recibidos
            if (tipotiendaDTO == null || string.IsNullOrWhiteSpace(tipotiendaDTO.Nombre))
            {
                return BadRequest("Datos de Tipo Tipo Tienda inválidos. El campo 'Nombre' es obligatorio.");
            }

            var nuevoTipoTienda = new TipoTienda
            {
                Nombre = tipotiendaDTO.Nombre
            };

            try
            {
                // Insertamos en la base de datos               
                await _dao.Add(nuevoTipoTienda); // Método Add debe estar configurado en tu servicio/repo
                await _dao.Save(); // Método Save para confirmar cambios

                // Devolvemos el registro creado con su ID
                return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevoTipoTienda.Id }, nuevoTipoTienda);
            }
            catch (Exception ex)
            {
                // Manejo de errores internos
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        //Metodo update Tipo Tienda
        [HttpPut("Editar_TipoTienda/{id}")]
        public async Task<ActionResult> ActualizarTipoTienda(int id, [FromBody] TipoTienda tipoTiendaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipoTiendaExistente = await _dao.GetById(id);
            if (tipoTiendaExistente == null)
            {
                return NotFound("TipoTienda no encontrado.");
            }

            // Actualización básica de campos permitidos
            tipoTiendaExistente.Nombre = tipoTiendaDTO.Nombre;

            try
            {
                _dao.Update(tipoTiendaExistente);
                await _dao.Save();
                return Ok(tipoTiendaExistente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar: {ex.Message}");
            }
        }

        //Eliminar TipoTienda
        [HttpDelete("Eliminar_TipoTienda/{id}")]
        public async Task<ActionResult> EliminarTipoTienda(int id)
        {
            try
            {
                var tipotienda= await _dao.GetById(id);
                if (tipotienda == null)
                {
                    return NotFound("Tipotienda no encontrado.");
                }

                _dao.Delete(tipotienda);
                await _dao.Save();

                return Ok(new { mensaje = "tipotienda eliminado con éxito" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error interno del servidor", error = ex.Message });
            }
        }







    }
}
