using ClienteApi.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projeto_MVC_Angular.Context;

namespace ClienteApi.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ClienteController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Cliente
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _context.Clientes.ToListAsync();
            return StatusCode(201, clientes);
        }

        // POST: api/Cliente
        [HttpPost]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return Ok(cliente);
        }

        // PUT: api/Cliente/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Cliente cliente)
        {
            try
            {
                var clienteDb = await _context.Clientes.FirstAsync(c => c.Id == id);

                clienteDb.Nome = cliente.Nome;
                clienteDb.Endereco = cliente.Endereco;
                clienteDb.Telefone = cliente.Telefone;

                _context.Clientes.Update(clienteDb);
                await _context.SaveChangesAsync();
                return Ok(clienteDb);

            }
            catch (InvalidOperationException err)
            {
                Console.WriteLine(err.Message);
                return NotFound("Cliente não encontrado!");
                throw;
            }
        }

        // DELETE: api/Cliente/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                var cliente = await _context.Clientes.Where(c => c.Id == id).FirstAsync();
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
                return NoContent();


            }
            catch (InvalidOperationException err)
            {
                Console.WriteLine(err.Message);
                return NotFound("Cliente não encontrado!");
                throw;
            }
        }
    }
}