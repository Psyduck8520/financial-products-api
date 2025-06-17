using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using WebAPI_roductManagement.Sevicios;

namespace WebAPI_roductManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductsService _Service; // siempre usamos  la interfaz para la inyección de dependencias

        public ProductController(IProductsService service)
        {
            _Service = service ?? throw new ArgumentNullException(nameof(service)); // Inyección de dependencias al controlador
        }
        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Listar()
        {
            var lista = await _Service.AllProduct();
            return Ok(lista);
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] Models.Product modelo)
        {
            var filas = await _Service.AddProduct(modelo);
            return Ok(filas);
        }
        [HttpPut]
        [Route("Modificar")]
        public async Task<IActionResult> Modificar([FromBody] Models.Product modelo)
        {
            var filas = await _Service.UpdateProduct(modelo);
            return Ok(filas);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public async Task<IActionResult> Eliminar( string id )
        {
            var filas = await _Service.DeleteProduct(id);
            if (filas==0)
            {
                return NotFound("Producto no encontrado o no se pudo eliminar.");
            }
            return NoContent();
        }
    }
}
