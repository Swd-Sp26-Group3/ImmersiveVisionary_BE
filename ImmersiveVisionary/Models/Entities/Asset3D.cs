using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models.Entities;

[Table("Asset3D")]
[Index("IsMarketplace", Name = "IX_Asset3D_IsMarketplace")]
[Index("PublishStatus", Name = "IX_Asset3D_PublishStatus")]
public partial class Asset3D
{
    [Key]
    public int AssetId { get; set; }

    public int? OrderId { get; set; }

    [StringLength(200)]
    public string AssetName { get; set; } = null!;

    [StringLength(500)]
    public string? PreviewImage { get; set; }

    public int CreatedBy { get; set; }

    public int? OwnerCompanyId { get; set; }

    [StringLength(50)]
    public string? AssetType { get; set; }

    [Column(TypeName = "decimal(12, 2)")]
    public decimal? Price { get; set; }

    public bool? IsMarketplace { get; set; }

    [StringLength(100)]
    public string? Category { get; set; }

    [StringLength(100)]
    public string? Industry { get; set; }

    [StringLength(50)]
    public string? PublishStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    [InverseProperty("Asset")]
    public virtual ICollection<AssetVersion> AssetVersions { get; set; } = new List<AssetVersion>();

    [ForeignKey("CreatedBy")]
    [InverseProperty("Asset3Ds")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [InverseProperty("Asset")]
    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();

    [InverseProperty("Asset")]
    public virtual ICollection<MarketplaceOrder> MarketplaceOrders { get; set; } = new List<MarketplaceOrder>();

    [ForeignKey("OrderId")]
    [InverseProperty("Asset3Ds")]
    public virtual CreativeOrder? Order { get; set; }

    [ForeignKey("OwnerCompanyId")]
    [InverseProperty("Asset3Ds")]
    public virtual Company? OwnerCompany { get; set; }

    [InverseProperty("Asset")]
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
