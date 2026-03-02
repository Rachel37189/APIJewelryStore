using System;
using System.Collections.Generic;

namespace Entities;

public partial class Size
{
    public int SizeId { get; set; }

    public int ProductId { get; set; }

    public double ProductSize { get; set; }

    public int Amount { get; set; }

    public virtual Product Product { get; set; } = null!;
}
