using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Runtime.CompilerServices;

public class BankCard
{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    private string? bankCardID;
    private string cardNumber = null!;
    private string bankName = null!;
    private string ownerName = null!;

    public BankCard(string cardNumber, string bankName, string ownerName)
    {
        this.cardNumber = cardNumber;
        this.bankName = bankName;
        this.ownerName = ownerName;
    }
    public BankCard GetBankCardInfo()
    {
        return this;
    }

}