using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models.Entities;

[Table("Payment")]
public partial class Payment
{
    [Key]
    public int PaymentId { get; set; }

    public int? OrderId { get; set; }

    public int? AssetId { get; set; }

    public int CompanyId { get; set; }

    [Column(TypeName = "decimal(12, 2)")]
    public decimal Amount { get; set; }

    [StringLength(50)]
    public string? PaymentType { get; set; }

    [StringLength(50)]
    public string? PaymentStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PaymentDate { get; set; }

    [ForeignKey("AssetId")]
    [InverseProperty("Payments")]
    public virtual Asset3D? Asset { get; set; }

    [ForeignKey("CompanyId")]
    [InverseProperty("Payments")]
    public virtual Company Company { get; set; } = null!;

    [ForeignKey("OrderId")]
    [InverseProperty("Payments")]
    public virtual CreativeOrder? Order { get; set; }
}
