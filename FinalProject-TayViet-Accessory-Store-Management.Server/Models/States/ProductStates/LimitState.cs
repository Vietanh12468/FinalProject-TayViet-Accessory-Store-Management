using FinalProject_TayViet_Accessory_Store_Management.Server.States;
namespace FinalProject_TayViet_Accessory_Store_Management.Server.Models
{
    public class LimitState : IReviewState
    {
        public int GetReviewScore()
        {
            // Implement the method
            return 1;
        }

        public string GetReviewDescription()
        {
            // Implement the method
            return "des";
        }

        public override string ToString()
        {
            return "Limited";
        }
    }
}