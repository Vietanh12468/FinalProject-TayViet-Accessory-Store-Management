using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace FinalProject_TayViet_Accessory_Store_Management.Server.Models;

public class CustomerSupport
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? id { get; set; }

    // Customer supported by this support agent
    public Customer Customer { get; set; }

    // List of support messages
    public List<CustomerSupportMessage> MessageList { get; set; }

    // Constructor to initialize customer support
    public CustomerSupport(string supportID, Customer customer, List<CustomerSupportMessage> messageList)
    {
        id = supportID;
        Customer = customer;
        MessageList = messageList;
    }

    // Get Support ID
    public string GetSupportID()
    {
        return id;
    }

    // Get Customer
    public Customer GetCustomer()
    {
        return Customer;
    }

    // Get Message List
    public List<CustomerSupportMessage> GetMessageList()
    {
        return MessageList;
    }

    // Add a new support message
    public void AddMessage(CustomerSupportMessage message)
    {
        MessageList.Add(message);
    }

    // Remove a support message
    public void RemoveMessage(CustomerSupportMessage message)
    {
        MessageList.Remove(message);
    }
}

public class CustomerSupportMessage
{
    // Message time
    public DateTime Time { get; set; }

    // Message content
    public string Message { get; set; }

    // Constructor to initialize a support message
    public CustomerSupportMessage(DateTime time, string message)
    {
        Time = time;
        Message = message;
    }
}
