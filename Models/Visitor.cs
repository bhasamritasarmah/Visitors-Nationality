using MongoDB.Bson.Serialization.Attributes;

namespace VisitorsNationality.Models
{
    [BsonIgnoreExtraElements]
    public class Visitor
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("country")]
        public string Country { get; set; }
    }
}
