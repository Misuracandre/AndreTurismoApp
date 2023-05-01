using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreTurismoApp.Models;
using AndreTurismoapp.CustomersService.Data;
using AndreTurismoApp.AddressesService.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AndreTurismoapp.CustomersService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly AndreTurismoappCustomersServiceContext _context;
        private readonly AndreTurismoAppAddressesServiceContext _contextAddress;

        public CustomersController(AndreTurismoappCustomersServiceContext context, AndreTurismoAppAddressesServiceContext contextAddress)
        {
            _context = context;
            _contextAddress = contextAddress;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<List<Client>>> GetClient()
        {
            if (_context.Client == null)
            {
                return NotFound();
            }
            var clients = await _context.Client
                .Include(c => c.IdAddress)
                    .ThenInclude(a => a.IdCity)
                .ToListAsync();

            return clients;
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            if (_context.Client == null)
            {
                return NotFound();
            }
            var client = await _context.Client
                .Include(c => c.IdAddress)
                    .ThenInclude(a => a.IdCity)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, Client client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
            if (_context.Client == null)
            {
                return Problem("Entity set 'AndreTurismoappCustomersServiceContext.Client'  is null.");
            }

            var address = await _contextAddress.Address.FindAsync(client.IdAddress);
            if (address == null)
            {
                return NotFound();
            }

            client.IdAddress = address;

            _context.Client.Add(client);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClient", new { id = client.Id }, client);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            if (_context.Client == null)
            {
                return NotFound();
            }
            var client = await _context.Client.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.Client.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientExists(int id)
        {
            return (_context.Client?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
