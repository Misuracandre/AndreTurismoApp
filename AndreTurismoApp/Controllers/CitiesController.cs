using AndreTurismoApp.Models;
using AndreTurismoApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AndreTurismoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private CitiesService _citiesService;

        public CitiesController(CitiesService citiesService)
        {
            _citiesService = citiesService;
        }

        [HttpPost]
       // public bool PostCity(City city) => _citiesService.PostCity(city);

        [HttpGet]
        public Task<List<City>> GetCity() => _citiesService.GetCity();


       // [HttpGet("{id}", Name = "GetById")]
       // public City GetById(int id) => _citiesService.GetById(id);
    }
}
