namespace FinalProject_TayViet_Accessory_Store_Management.Models.ExceptionModels
{
    public class IncorrectFormatException : Exception
    {
        public IncorrectFormatException(string message) : base(message)
        {
        }
        public override string ToString()
        {
            return Message;
        }
    }
}
