using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBConnect.Models;

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
    }
}
