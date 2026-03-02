using System;
using System.Collections.Generic;

namespace Entities;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string ShortDescription { get; set; } = null!;

    public string LongDescription { get; set; } = null!;

    public double ProductPrice { get; set; }

    public int CategoryId { get; set; }

    public string Color { get; set; } = null!;

    public DateOnly DateAdded { get; set; }

    public string Image1 { get; set; } = null!;

    public string? Image2 { get; set; }

    public bool JustOnline { get; set; }

    public bool IsClassic { get; set; }

    public bool IsTrendy { get; set; }

    public bool IsPearls { get; set; }

    public bool IsStudio { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Size> Sizes { get; set; } = new List<Size>();
}
