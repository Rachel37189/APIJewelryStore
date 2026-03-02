using System;
using System.Collections.Generic;

namespace Entities;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string Password { get; set; } = null!;

    public int Phone { get; set; }

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public int HouseNumber { get; set; }

    public bool IsAdmin { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
