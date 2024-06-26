using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using FinalProject_TayViet_Accessory_Store_Management.Server.States;
namespace FinalProject_TayViet_Accessory_Store_Management.Server.Models
{
    public class Review
    {
        public string customerID { get; set; } = null!;
        public int ratedScore { get; set; } = 0;
        public string reviewDescription { get; set; } = null!;
        public string? state { get; set; } = "Hide";

        public IReviewState GetState()
        {
            switch (state)
            {
                case "Hide":
                    return new HideState();
                case "View":
                    return new ViewState();
                default:
                    throw new Exception("Invalid State");
            }
        }

        public void GetReviewScore()
        {
            GetState().GetReviewScore(this);
        }

        public void GetReviewDescription()
        {
            GetState().GetReviewDescription(this);
        }

        /*        // State of the review
                public IReviewState state { get; set; } = null!;*/

        /*        // Set State
                public void SetState(IReviewState state)
                {
                    State = state;
                }*/
    }
}