using DnsClient;

namespace FinalProject_TayViet_Accessory_Store_Management.Models
{
    public class DBSettings
    {
        public string ConnectionURI { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public readonly List<Collection> Collections = [
            new Collection("Brand", typeof(Brand))
        ];
    }

    public class Collection
    {
        public string nameCollection { get; set; }
        public Type classType { get; set; }

        public Collection(string nameCollection, Type classType)
        {
            this.nameCollection = nameCollection;
            this.classType = classType;
        }
    }
}