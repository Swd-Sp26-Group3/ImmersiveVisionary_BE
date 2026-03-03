using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models.Entities;

[Table("ServicePackage")]
public partial class ServicePackage
{
    [Key]
    public int PackageId { get; set; }

    [StringLength(200)]
    public string PackageName { get; set; } = null!;

    [StringLength(500)]
    public string? Description { get; set; }

    [Column(TypeName = "decimal(12, 2)")]
    public decimal? BasePrice { get; set; }

    public int? EstimatedDays { get; set; }

    [InverseProperty("Package")]
    public virtual ICollection<CreativeOrder> CreativeOrders { get; set; } = new List<CreativeOrder>();
}
