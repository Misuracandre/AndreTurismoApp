using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AndreTurismoApp.AddressesService.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreTurismoApp.Models;
using System.Net.Http;
using Newtonsoft.Json;
using AndreTurismoApp.Models.DTO;

namespace Proj_Turismo_API_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly AndreTurismoAppAddressesServiceContext _context;

        public AddressesController(AndreTurismoAppAddressesServiceContext context)
        {
            _context = context;
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddress()
        {
            if (_context.Address == null)
            {
                return NotFound();
            }
            return await _context.Address.Include(a => a.IdCity).ToListAsync();
        }

        // GET: api/Addresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddress(int id)
        {
            if (_context.Address == null)
            {
                return NotFound();
            }
            //var address = await _context.Address.FindAsync(id);
            var address = await _context.Address.Include(a => a.IdCity).Where(a => a.Id == id).FirstOrDefaultAsync();

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }

        // PUT: api/Addresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddress(int id, Address address)
        {
            if (id != address.Id)
            {
                return BadRequest();
            }

            _context.Entry(address).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
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

        // POST: api/Addresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress(Address address)
        {
            if (_context.Address == null)
            {
                return Problem("Entity set 'Proj_Turismo_API_EFContext.Address'  is null.");
            }

            if (address.ZipCode == null)
            {
                return BadRequest("ZipCode  is required.");
            }

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://viacep.com.br/ws/{address.ZipCode}/json/");
            if (response == null)
            {
                return BadRequest("Invalid ZipCode");
            }

            var content = await response.Content.ReadAsStringAsync();
            var viaCepAddress = JsonConvert.DeserializeObject<ViaCepAddressDto>(content);

            address.Street = viaCepAddress.Logradouro;
            address.Neighborhood = viaCepAddress.Bairro;
            address.IdCity.Description = viaCepAddress.Localidade;
            address.Extension = viaCepAddress.Uf;

            _context.Address.Add(address);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddress", new { id = address.Id }, address);
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            if (_context.Address == null)
            {
                return NotFound();
            }
            var address = await _context.Address.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            _context.Address.Remove(address);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddressExists(int id)
        {
            return (_context.Address?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
