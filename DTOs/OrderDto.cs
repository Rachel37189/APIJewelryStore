namespace DTOs
{
    public record OrderDto
    (
        int OrderId = 0,
        DateOnly? OrderDate = null,
        double OrderSum = 0, // שימי לב: ב-Entity זה נקרא TotalPrice
        int UserId = 0,
        int Status = 0
    );
}
