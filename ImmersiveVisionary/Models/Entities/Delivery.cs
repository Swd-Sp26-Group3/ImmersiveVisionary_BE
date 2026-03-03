using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models.Entities;

[Table("Delivery")]
public partial class Delivery
{
    [Key]
    public int DeliveryId { get; set; }

    public int OrderId { get; set; }

    public int AssetId { get; set; }

    [StringLength(500)]
    public string? DownloadUrl { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeliveredAt { get; set; }

    [StringLength(50)]
    public string? Status { get; set; }

    [ForeignKey("AssetId")]
    [InverseProperty("Deliveries")]
    public virtual Asset3D Asset { get; set; } = null!;

    [ForeignKey("OrderId")]
    [InverseProperty("Deliveries")]
    public virtual CreativeOrder Order { get; set; } = null!;
}
