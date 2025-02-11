using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Generic_MOngo
{
    public class Person
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string? Name { get;set; }
        public string? Description { get; set; }
        public string? mail { get;set; }

    }
    public class Product
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }
        public string price { get; set; }

    }
}
