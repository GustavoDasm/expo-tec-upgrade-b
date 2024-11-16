using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace expo_tec_upgrade_b.Models
{
    public class Cliente
    {

            [BsonElement("_id")]
            [BsonRepresentation(BsonType.ObjectId)]  
            public string? Id { get; set; }

            [BsonElement("name")]  
            public string? Name { get; set; }
            [BsonElement("surname")]
            public string? Surname { get; set; }

            [BsonElement("phone")]
            public string? Phone { get; set; }

            [BsonElement("dni")]
            public string? Dni { get; set; }

            [BsonElement("email")]
            public string? Email { get; set; }

            [BsonElement("profesion")]
            public string? Profesion { get; set; }
    }
}

