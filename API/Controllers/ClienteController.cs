using Core.Dto;
using Core.Entidades;
using Infraestructura.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private ResponseDto _response;
        public ClienteController(ApplicationDbContext db)
        {
            _db = db;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes(){
            var lista = await _db.Cliente.ToListAsync();
            _response.Resultado = lista;
            _response.Mensaje = "Listado de CLientes";
            return Ok(_response);
        }
        
        [HttpGet("{id}", Name = "GetCliente")]
        public async Task<ActionResult<Cliente>> GetCliente(int id){
            var cliente = await _db.Cliente.FindAsync(id);
            _response.Resultado = cliente;
            _response.Mensaje = "Datos del cliente" + cliente?.Id;
            return Ok(_response); // Status code = 200
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente([FromBody] Cliente cliente){
            await _db.Cliente.AddAsync(cliente);
            await _db.SaveChangesAsync();
            return CreatedAtRoute("GetCliente", new {id = cliente.Id}, cliente); //Status Code = 201
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutCliente(int id, [FromBody] Cliente cliente){
            if(id != cliente.Id){
                return BadRequest("Id del cliente no coincide");
            }
            _db.Update(cliente);
            await _db.SaveChangesAsync();
            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCliente(int id){
            var cliente = await _db.Cliente.FindAsync(id);
            if( cliente == null){
                return NotFound();
            }
            _db.Cliente.Remove(cliente);
            await _db.SaveChangesAsync();
            return NoContent();
        }


    }
}