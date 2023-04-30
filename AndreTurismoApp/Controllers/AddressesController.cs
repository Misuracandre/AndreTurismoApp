using AndreTurismoApp.Models;
using AndreTurismoApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AndreTurismoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly AddressesService _addressesService;

        public AddressesController(AddressesService addressesService)
        {
            _addressesService = addressesService;
        }

        [HttpGet]
        public async Task<List<Address>> GetAddress() => await _addressesService.GetAddress();

        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress(Address address)
        {
            return null;
        }
    }

    
}
