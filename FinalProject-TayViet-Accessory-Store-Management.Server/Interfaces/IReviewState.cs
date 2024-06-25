using FinalProject_TayViet_Accessory_Store_Management.Server.Models;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.States
{
    public interface IReviewState : IState
    {
        int GetReviewScore(Review review);
        string GetReviewDescription(Review review);
        new string ToString();
    }
}