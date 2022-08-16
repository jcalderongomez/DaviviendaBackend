using Core.Dto;
using Core.Entidades;
using Infraestructura.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private ResponseDto _response;
        public ProveedorController(ApplicationDbContext db)
        {
            _db = db;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proveedor>>> GetProveedores(){
            var lista = await _db.Proveedor.ToListAsync();
            _response.Resultado = lista;
            _response.Mensaje = "Listado de Proveedores";
            return Ok(_response);
        }
        
        [HttpGet("{id}", Name = "GetProveedor")]
        public async Task<ActionResult<Proveedor>> GetProveedor(int id){
            var proveedor = await _db.Proveedor.FindAsync(id);
            _response.Resultado = proveedor;
            _response.Mensaje = "Datos del proveedor " + proveedor?.Id;
            return Ok(_response); // Status code = 200
        }

        [HttpPost]
        public async Task<ActionResult<Proveedor>> PostProveedor([FromBody] Proveedor proveedor){
            await _db.Proveedor.AddAsync(proveedor);
            await _db.SaveChangesAsync();
            return CreatedAtRoute("GetProveedor", new {id = proveedor.Id}, proveedor); //Status Code = 201
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutProveedor(int id, [FromBody] Proveedor proveedor){
            if(id != proveedor.Id){
                return BadRequest("Id del proveedor no coincide");
            }
            _db.Update(proveedor);
            await _db.SaveChangesAsync();
            return Ok(proveedor);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProveedor(int id){
            var proveedor = await _db.Proveedor.FindAsync(id);
            if( proveedor == null){
                return NotFound();
            }
            _db.Proveedor.Remove(proveedor);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}