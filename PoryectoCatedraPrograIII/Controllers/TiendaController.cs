using Microsoft.AspNetCore.Mvc;
using PoryectoCatedraPrograIII.Data;
using PoryectoCatedraPrograIII.DTO;
using PoryectoCatedraPrograIII.Models;
using PoryectoCatedraPrograIII.Repository;

namespace PoryectoCatedraPrograIII.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class TiendaController : Controller
    {

        private readonly TiendaDAO _dao;

        public TiendaController(DBContext context)
        {
            _dao = new TiendaDAO(context);
        }


        //Metodo Get obtner Tiendas
        [HttpGet("LeerTiendas")]
        public async Task<ActionResult<List<Tienda>>> ObtenerListado()
        {
            var tiendas = await _dao.Get();

            // Verificar si la lista está vacía o es nula
            if (tiendas == null || !tiendas.Any())
            {
                return NotFound("No se encontraron tiendas.");
            }
            return Ok(tiendas);
        }



        //metodo para obtenerpor ID
        [HttpGet("ObtenerPorId/{id}")]
        public async Task<ActionResult<Tienda>> ObtenerPorId(int id)
        {
            var tiendas = await _dao.GetById(id);

            if (tiendas == null)
            {
                return NotFound($"No se encontró el tiendas con ID {id}");
            }

            return Ok(tiendas);
        }

  




        //Metodo para Insertar

        [HttpPost("Insertar_Tiendas")]
        public async Task<ActionResult> InsertarTienda([FromBody] TiendaCreateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                return BadRequest(string.Join(", ", errors));
            }

            var nuevaTienda = new Tienda
            {
                Nombre = dto.Nombre,
                HorarioInicio = dto.HorarioInicio,
                HorarioSalida = dto.HorarioSalida,
                FotoFachada = dto.FotoFachada,
                Slogan = dto.Slogan,
                NumeroContacto = dto.NumeroContacto,
                FacebookContacto = dto.FacebookContacto,
                PaginaWeb = dto.PaginaWeb,
                TieneEnvio = dto.TieneEnvio,
                idTipoTiendas = dto.idTipoTiendas
            };

            try
            {
                await _dao.Add(nuevaTienda);
                await _dao.Save();
                return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevaTienda.Id }, nuevaTienda);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }


        [HttpPut("EditarTiendas/{id}")]
        public async Task<ActionResult> ActualizarTienda(int id, [FromBody] TiendaUpdateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tiendaExistente = await _dao.GetById(id);
            if (tiendaExistente == null)
            {
                return NotFound("Tienda no encontrado.");
            }

            // Actualización básica de campos permitidos
            tiendaExistente.Nombre = dto.Nombre;
            tiendaExistente.HorarioInicio = dto.HorarioInicio;
            tiendaExistente.HorarioSalida = dto.HorarioSalida;
            tiendaExistente.FotoFachada = dto.FotoFachada;
            tiendaExistente.Slogan = dto.Slogan;
            tiendaExistente.NumeroContacto = dto.NumeroContacto;
            tiendaExistente.FacebookContacto = dto.FacebookContacto;
            tiendaExistente.PaginaWeb = dto.PaginaWeb;
            tiendaExistente.TieneEnvio = dto.TieneEnvio;
            tiendaExistente.idTipoTiendas = dto.idTipoTiendas;


            try
            {
                _dao.Update(tiendaExistente);
                await _dao.Save();
                return Ok(tiendaExistente);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Error al actualizar: {ex.Message}");
            }
        }

        [HttpDelete("EliminarTienda/{id}")]
        public async Task<ActionResult> EliminarTienda(int id)
        {
            try
            {
                var tienda = await _dao.GetById(id);
                if (tienda == null)
                {
                    return NotFound("tienda no encontrado.");
                }

                _dao.Delete(tienda);
                await _dao.Save();

                return Ok(new { mensaje = "tienda eliminado con éxito" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error interno del servidor", error = ex.Message });
            }
        }




    }
}
