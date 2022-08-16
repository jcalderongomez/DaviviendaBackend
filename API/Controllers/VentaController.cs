using Core.Dto;
using Core.Entidades;
using Infraestructura.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private ResponseDto _response;
        public VentaController(ApplicationDbContext db)
        {
            _db = db;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venta>>> GetVentas(){
            var lista = await _db.Venta.Include(x=>x.Cliente).Include(x=>x.Producto).ToListAsync();
            _response.Resultado = lista;
            _response.Mensaje = "Listado de Ventas";
            return Ok(_response);
        }
        
        [HttpGet("{id}", Name = "GetVenta")]
        public async Task<ActionResult<Venta>> GetVenta(int id){
            var venta = await _db.Venta.FindAsync(id);
            _response.Resultado = venta;
            _response.Mensaje = "Datos del venta " + venta?.Id;
            return Ok(_response); // Status code = 200
        }

        [HttpPost]
        public async Task<ActionResult<Venta>> PostVenta([FromBody] Venta venta){
            if(ModelState.IsValid){
                await _db.Venta.AddAsync(venta);
                await _db.SaveChangesAsync();
                return CreatedAtRoute("GetVenta", new {id = venta.Id}, venta); //Status Code = 201
            }
            else{   
                return BadRequest();
            }

            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutVenta(int id, [FromBody] Venta venta){
            if(id != venta.Id){
                return BadRequest("Id del venta no coincide");
            }
            _db.Update(venta);
            await _db.SaveChangesAsync();
            return Ok(venta);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVenta(int id){
            var venta = await _db.Venta.FindAsync(id);
            if( venta == null){
                return NotFound();
            }
            _db.Venta.Remove(venta);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}