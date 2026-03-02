using System;
using System.Collections.Generic;

namespace Entities;

public partial class Order
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public DateOnly OrderDate { get; set; }

    public int Status { get; set; }

    public double TotalPrice { get; set; }

    public string ShippingMethod { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual User User { get; set; } = null!;
}
