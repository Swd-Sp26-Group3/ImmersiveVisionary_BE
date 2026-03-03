using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models.Entities;

[Table("MarketplaceOrder")]
public partial class MarketplaceOrder
{
    [Key]
    public int MpOrderId { get; set; }

    public int AssetId { get; set; }

    public int BuyerCompanyId { get; set; }

    public int SellerCompanyId { get; set; }

    [Column(TypeName = "decimal(12, 2)")]
    public decimal? Price { get; set; }

    [StringLength(50)]
    public string? Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [ForeignKey("AssetId")]
    [InverseProperty("MarketplaceOrders")]
    public virtual Asset3D Asset { get; set; } = null!;

    [ForeignKey("BuyerCompanyId")]
    [InverseProperty("MarketplaceOrderBuyerCompanies")]
    public virtual Company BuyerCompany { get; set; } = null!;

    [ForeignKey("SellerCompanyId")]
    [InverseProperty("MarketplaceOrderSellerCompanies")]
    public virtual Company SellerCompany { get; set; } = null!;
}
