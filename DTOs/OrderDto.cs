namespace DTOs
{
    //public record OrderDto
    //(
    //    int OrderId = 0,
    //    DateOnly? OrderDate = null,
    //    double OrderSum = 0,
    //    int UserId = 0,
    //    int Status = 0,
    //    List<OrderItemDto> OrderItems = null // הוספת הרשימה כאן
    //);

    public class OrderDTO
    {
        public int OrderId { get; set; }
        public DateOnly? OrderDate { get; set; }
        public double OrderSum { get; set; }
        public int UserId { get; set; }
        public int Status { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; }// הוספת הרשימה כאן
    }
}
