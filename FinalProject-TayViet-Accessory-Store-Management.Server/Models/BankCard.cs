using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace FinalProject_TayViet_Accessory_Store_Management.Server.Models
{
    public class BankCard
    {
        public string cardNumber = null!;
        public string bankName = null!;
        public string ownerName = null!;

        public BankCard(string cardNumber, string bankName, string ownerName)
        {
            this.cardNumber = cardNumber;
            this.bankName = bankName;
            this.ownerName = ownerName;
        }
    }
}