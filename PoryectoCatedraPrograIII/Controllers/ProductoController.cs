using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PoryectoCatedraPrograIII.Data;
using PoryectoCatedraPrograIII.DTO;
using PoryectoCatedraPrograIII.Models;
using PoryectoCatedraPrograIII.Repository;

namespace PoryectoCatedraPrograIII.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoDAO _dao;

        public ProductoController(DBContext context)
        {
            _dao = new ProductoDAO(context);
        }

        [HttpGet("LeerProductos")]
        public async Task<ActionResult<List<Producto>>> ObtenerListado()
        {
            var productos = await _dao.Get();

            // productos si la lista está vacía o es nula
            if (productos == null || !productos.Any())
            {
                return NotFound("No se encontraron productos.");
            }
            return Ok(productos);
        }

        [HttpGet("ObtenerPorId/{id}")]
        public async Task<ActionResult<Producto>> ObtenerPorId(int id)
        {
            var productos = await _dao.GetById(id);

            if (productos == null)
            {
                return NotFound($"No se encontró el productos con ID {id}");
            }

            return Ok(productos);
        }

        [HttpGet("ObtenerPorTienda/{tiendaId}")]
        public async Task<IActionResult> ObtenerPorTienda(int tiendaId)
        {
            var productos = await _dao.GetByTiendaId(tiendaId);

            if (productos == null || !productos.Any())
                return NotFound("No se encontraron productos para esta tienda.");

            return Ok(productos);
        }



        [HttpDelete("EliminarProducto/{id}")]
        public async Task<ActionResult> EliminarProducto(int id)
        {
            try
            {
                var productos = await _dao.GetById(id);
                if (productos == null)
                {
                    return NotFound("productos no encontrado.");
                }

                _dao.Delete(productos);
                await _dao.Save();

                return Ok(new { mensaje = "productos eliminado con éxito" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error interno del servidor", error = ex.Message });
            }
        }


        [HttpPost("Insertar_Producto")]
        public async Task<ActionResult<Producto>> PostProducto(ProductoCreateDTO dto)
        {
            // Validar que exista la tienda
            var tienda = await _dao.GetTiendaById(dto.TiendaId);
            if (tienda == null)
            {
                return BadRequest("La tienda especificada no existe.");
            }

            var producto = new Producto
            {
                Nombre = dto.Nombre,
                Precio = dto.Precio,
                Foto = dto.Foto,
                Descripcion = dto.Descripcion,
                Marca = dto.Marca,
                Estado = dto.Estado,
                TiendaId = dto.TiendaId
            };

            _dao.Add(producto);
            await _dao.Save();

            return CreatedAtAction(nameof(ObtenerListado), new { id = producto.Id }, producto);
        }


        [HttpPut("Actualizar_Producto/{id}")]
        public async Task<ActionResult> ActualizarProducto(int id, [FromBody] ProductoUpdateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                return BadRequest(string.Join(", ", errors));
            }

            var productoExistente = await _dao.GetById(id);
            if (productoExistente == null)
            {
                return NotFound("Producto no encontrado.");
            }

            var tienda = await _dao.GetTiendaById(dto.TiendaId);
            if (tienda == null)
            {
                return BadRequest("La tienda especificada no existe.");
            }

            // Actualizar campos
            productoExistente.Nombre = dto.Nombre;
            productoExistente.Precio = dto.Precio;
            productoExistente.Foto = dto.Foto;
            productoExistente.Descripcion = dto.Descripcion;
            productoExistente.Marca = dto.Marca;
            productoExistente.Estado = dto.Estado;
            productoExistente.TiendaId = dto.TiendaId;

            try
            {
                await _dao.Update(productoExistente);
                await _dao.Save();
                return Ok("Producto actualizado correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }








    }
}
