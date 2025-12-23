namespace DTOs
{
    public record OrderDto
    (
      
        DateOnly? OrderDate,

        double OrderSum ,

        int UserId

    //    ICollection<OrderItem> OrderItems= new List<OrderItem>()

    );
}
