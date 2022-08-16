using Core.Dto;
using Core.Entidades;
using Infraestructura.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private ResponseDto _response;
        public ProductoController(ApplicationDbContext db)
        {
            _db = db;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos(){
            var lista = await _db.Producto.Include(x=>x.Proveedor).ToListAsync();
            _response.Resultado = lista;
            _response.Mensaje = "Listado de Productos";
            return Ok(_response);
        }

        [HttpGet("{id}", Name = "GetProducto")]
        public async Task<ActionResult<Producto>> GetProducto(int id){
            var producto = await _db.Producto.FindAsync(id);
            _response.Resultado = producto;
            _response.Mensaje = "Datos del producto " + producto?.Id;
            return Ok(_response); // Status code = 200
        }

        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto([FromBody] Producto producto){
            await _db.Producto.AddAsync(producto);
            await _db.SaveChangesAsync();
            return CreatedAtRoute("GetProducto", new {id = producto.Id}, producto); //Status Code = 201
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutProducto(int id, [FromBody] Producto producto){
            if(id != producto.Id){
                return BadRequest("Id del producto no coincide");
            }
            _db.Update(producto);
            await _db.SaveChangesAsync();
            return Ok(producto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProducto(int id){
            var producto = await _db.Producto.FindAsync(id);
            if( producto == null){
                return NotFound();
            }
            _db.Producto.Remove(producto);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}