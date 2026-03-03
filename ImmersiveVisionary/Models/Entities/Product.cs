using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models.Entities;

[Table("Product")]
public partial class Product
{
    [Key]
    public int ProductId { get; set; }

    public int CompanyId { get; set; }

    [StringLength(200)]
    public string ProductName { get; set; } = null!;

    [StringLength(500)]
    public string? Description { get; set; }

    [StringLength(100)]
    public string? Category { get; set; }

    [StringLength(200)]
    public string? SizeInfo { get; set; }

    [StringLength(200)]
    public string? ColorInfo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    [ForeignKey("CompanyId")]
    [InverseProperty("Products")]
    public virtual Company Company { get; set; } = null!;

    [InverseProperty("Product")]
    public virtual ICollection<CreativeOrder> CreativeOrders { get; set; } = new List<CreativeOrder>();
}
