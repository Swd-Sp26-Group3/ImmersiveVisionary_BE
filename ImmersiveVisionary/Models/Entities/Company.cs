using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models.Entities;

[Table("Company")]
public partial class Company
{
    [Key]
    public int CompanyId { get; set; }

    [StringLength(200)]
    public string CompanyName { get; set; } = null!;

    [StringLength(200)]
    public string? Address { get; set; }

    [StringLength(100)]
    public string? Email { get; set; }

    [StringLength(50)]
    public string? Phone { get; set; }

    [StringLength(200)]
    public string? Website { get; set; }

    [StringLength(50)]
    public string? CompanyType { get; set; }

    [StringLength(50)]
    public string? Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    [InverseProperty("OwnerCompany")]
    public virtual ICollection<Asset3D> Asset3Ds { get; set; } = new List<Asset3D>();

    [InverseProperty("Company")]
    public virtual ICollection<CreativeOrder> CreativeOrders { get; set; } = new List<CreativeOrder>();

    [InverseProperty("BuyerCompany")]
    public virtual ICollection<MarketplaceOrder> MarketplaceOrderBuyerCompanies { get; set; } = new List<MarketplaceOrder>();

    [InverseProperty("SellerCompany")]
    public virtual ICollection<MarketplaceOrder> MarketplaceOrderSellerCompanies { get; set; } = new List<MarketplaceOrder>();

    [InverseProperty("Company")]
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    [InverseProperty("Company")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    [InverseProperty("Company")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
