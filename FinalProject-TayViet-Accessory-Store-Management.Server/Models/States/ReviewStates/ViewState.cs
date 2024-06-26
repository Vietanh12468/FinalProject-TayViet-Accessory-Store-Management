using FinalProject_TayViet_Accessory_Store_Management.Server.States;
namespace FinalProject_TayViet_Accessory_Store_Management.Server.Models
{
    public class ViewState : IReviewState
    {
        public int GetReviewScore(Review review)
        {
            // Implement the method
            return 1;
        }

        public string GetReviewDescription(Review review)
        {
            return "";
            // Implement the method
        }

        public override string ToString()
        {
            return "View";
        }
    }
}