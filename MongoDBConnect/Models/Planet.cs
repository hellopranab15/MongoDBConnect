using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDBConnect.Models
{
    public class Planet
    {
            [BsonId]
            public ObjectId Id { get; set; }

            [BsonElement("name")]
            public string Name { get; set; }

            [BsonElement("orderFromSun")]
            public int OrderFromSun { get; set; }

            [BsonElement("hasRings")]
            public bool HasRings { get; set; }

            [BsonElement("mainAtmosphere")]
            public List<string> MainAtmosphere { get; set; }

            [BsonElement("surfaceTemperatureC")]
            public SurfaceTemperature SurfaceTemperatureC { get; set; }
    }

     public class SurfaceTemperature
     {
         [BsonElement("min")]
         public double? Min { get; set; }
     
         [BsonElement("max")]
         public double? Max { get; set; }
     
         [BsonElement("mean")]
         public double Mean { get; set; }
     }

}
