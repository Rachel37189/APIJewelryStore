namespace DTOs
{
    public record OrderDto
    (
        int OrderId,

        DateOnly? OrderDate,

        double OrderSum ,

        int UserId

    //    ICollection<OrderItem> OrderItems= new List<OrderItem>()

    );
}
