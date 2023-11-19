using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDBConnect.Models;
using MongoDBConnect.Services;

namespace MongoDBConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetController : ControllerBase
    {
        private readonly MongoDBService _mongoDBService;

        public PlanetController(MongoDBService mongoDBService) 
        {
         _mongoDBService = mongoDBService;
        }

        [HttpGet]
        public async Task<List<Planet>> Get()
        {
            return await _mongoDBService.GetPlanetsAsync();
        }

        [HttpGet("findByName/{name}")]
        public async Task<Planet> FindByName(String Name)
        {
            var result = await _mongoDBService.GetPlanetByName(Name);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        [HttpPost("Save")]
        public async Task<Planet> SavePlanet(Planet planet)
        {
            var result = await _mongoDBService.SavePlanet(planet);
            if (result == null)
            {
                return null;
            }
            return result;
        }
    }
}
