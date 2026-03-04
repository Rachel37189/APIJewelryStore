#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public partial class Category
{

    [Key]
    public int CategoryId { get; set; }

    [Required]
    [StringLength(40)]
    public string CategoryName { get; set; }= null!;

    [InverseProperty("Category")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
 
