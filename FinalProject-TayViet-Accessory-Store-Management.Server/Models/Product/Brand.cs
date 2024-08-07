using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace FinalProject_TayViet_Accessory_Store_Management.Server.Models
{
    public class Brand
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? id { get; set; }
        public string name { get; set; } = null!;
        public string phone { get; set; } = null!;
        public string email { get; set; } = null!;
        public string image { get; set; } = null!;
        public string description { get; set; } = null!;

        public Brand(string name, string phone, string email, string image, string description)
        {
            this.name = name;
            this.phone = phone;
            this.email = email;
            this.image = image;
            this.description = description;
        }
    }
}