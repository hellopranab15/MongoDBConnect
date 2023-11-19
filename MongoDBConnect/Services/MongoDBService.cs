using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBConnect.Models;
using System.Xml.Linq;

namespace MongoDBConnect.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<Planet> _planets;

        public MongoDBService(IOptions<MongoDBSettings> settings)
        {
            MongoClient client = new MongoClient(settings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(settings.Value.DatabaseName);
            _planets = database.GetCollection<Planet>(settings.Value.CollectionName);
        }

        public async Task<List<Planet>> GetPlanetsAsync()
        {
            return await _planets.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Planet> GetPlanetByName(String Name)
        {
            var filter = Builders<Planet>.Filter.Eq("name", Name);
            var document = await _planets.Find(filter).FirstOrDefaultAsync();
            var existingPlanet = await _planets.Find(filter).FirstOrDefaultAsync();
            if (existingPlanet == null)
            {
                return null;
            }

            return document;
        }

        public async Task<Planet> SavePlanet(Planet planet)
        {
            var filter = Builders<Planet>.Filter.Eq("name", planet.Name);

            var existingPlanet = await _planets.Find(filter).FirstOrDefaultAsync();
            if (existingPlanet == null)
            {
                await _planets.InsertOneAsync(planet);
                return planet;
            }
            return null;
        }
    }
}
