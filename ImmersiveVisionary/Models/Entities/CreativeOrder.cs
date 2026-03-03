using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models.Entities;

[Table("CreativeOrder")]
[Index("Status", Name = "IX_CreativeOrder_Status")]
public partial class CreativeOrder
{
    [Key]
    public int OrderId { get; set; }

    public int CompanyId { get; set; }

    public int ProductId { get; set; }

    public int PackageId { get; set; }

    public string? Brief { get; set; }

    [StringLength(200)]
    public string? TargetPlatform { get; set; }

    [StringLength(50)]
    public string? Status { get; set; }

    public DateOnly? Deadline { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    [InverseProperty("Order")]
    public virtual ICollection<Asset3D> Asset3Ds { get; set; } = new List<Asset3D>();

    [ForeignKey("CompanyId")]
    [InverseProperty("CreativeOrders")]
    public virtual Company Company { get; set; } = null!;

    [InverseProperty("Order")]
    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();

    [ForeignKey("PackageId")]
    [InverseProperty("CreativeOrders")]
    public virtual ServicePackage Package { get; set; } = null!;

    [InverseProperty("Order")]
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    [ForeignKey("ProductId")]
    [InverseProperty("CreativeOrders")]
    public virtual Product Product { get; set; } = null!;

    [InverseProperty("Order")]
    public virtual ICollection<ProductionStage> ProductionStages { get; set; } = new List<ProductionStage>();
}
