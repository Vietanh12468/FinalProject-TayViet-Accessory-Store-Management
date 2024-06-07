using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace FinalProject_TayViet_Accessory_Store_Management.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? id { get; set; }
        public string name { get; set; } = null!;
        public string email { get; set; } = null!;
        public string password { get; set; } = null!;
    }
}
