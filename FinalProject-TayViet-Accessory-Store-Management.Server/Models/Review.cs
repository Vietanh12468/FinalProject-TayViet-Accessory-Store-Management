public class Review
{
    // Product ID
    public string ProductID { get; set; }

    // Customer ID
    public string CustomerID { get; set; }

    // Rated score
    public int RatedScore { get; set; }

    // Review description
    public string ReviewDescription { get; set; }

    // State of the review
    public IReviewState State { get; set; }

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
