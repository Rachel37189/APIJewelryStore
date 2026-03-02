using System;
using System.Collections.Generic;

namespace Entities;

public partial class Category
{
    public int CaregoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
