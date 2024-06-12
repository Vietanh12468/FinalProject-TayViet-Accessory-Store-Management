using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using FinalProject_TayViet_Accessory_Store_Management.Server.States;
namespace FinalProject_TayViet_Accessory_Store_Management.Server.Models
{
    public class Review
    {
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
        public Review(string customerID, int ratedScore, string reviewDescription, IReviewState state)
        {
            CustomerID = customerID;
            RatedScore = ratedScore;
            ReviewDescription = reviewDescription;
            State = state;
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
}