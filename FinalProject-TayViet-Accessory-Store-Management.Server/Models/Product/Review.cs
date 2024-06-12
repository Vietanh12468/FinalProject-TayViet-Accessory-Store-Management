using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

public class Review
{
    // Product ID
    private string ProductID { get; set; }

    // Customer ID
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    private string? CustomerID { get; set; }

    // Rated score
    private int RatedScore { get; set; }

    // Review description
    private string ReviewDescription { get; set; }

    // State of the review
    private IReviewState State { get; set; }

    // Constructor
    public Review(string customerID, string productID, int ratedScore, string reviewDescription, IReviewState state)
    {
        CustomerID = customerID;
        ProductID = productID;
        RatedScore = ratedScore;
        ReviewDescription = reviewDescription;
        State = state;
    }

    // Get Product ID
    public string GetProductID()
    {
        return ProductID;
    }

    // Get Customer ID
    public string GetCustomerID()
    {
        return CustomerID;
    }

    // Get Review Description
    public string GetReviewDescription()
    {
        return ReviewDescription;
    }

    // Get Rated Score
    public int GetRatedScore()
    {
        return RatedScore;
    }

    // Set State
    public void SetState(IReviewState state)
    {
        State = state;
    }
}
