namespace InterviewTask.Models
{
    public class ShoppingCartRemoveViewModel
    {
        public string Message { get; set; }
        public decimal CartTotal { get; set; }
        public int ItemCount { get; set; }
        public int DeleteId { get; set; }
    }
}
