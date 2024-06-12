namespace FinalProject_TayViet_Accessory_Store_Management.Models.ExceptionModels 
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base()
        {
        }
        public override string ToString()
        {
            return "No Result";
        }
    }
}
