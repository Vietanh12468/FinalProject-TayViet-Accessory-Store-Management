namespace FinalProject_TayViet_Accessory_Store_Management.Models.ExceptionModels
{
    public class UnknownException : Exception
    {
        public UnknownException() : base()
        {
        }
        public override string ToString()
        {
            return "Unknown Error";
        }
    }
}
