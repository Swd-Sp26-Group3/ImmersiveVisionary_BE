using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models.Entities;

[Table("User")]
[Index("Email", Name = "IX_User_Email")]
[Index("Email", Name = "UQ__User__A9D105343583E831", IsUnique = true)]
[Index("UserName", Name = "UQ__User__C9F284567BC77107", IsUnique = true)]
public partial class User
{
    [Key]
    public int UserId { get; set; }

    public int? CompanyId { get; set; }

    public int RoleId { get; set; }

    [StringLength(100)]
    public string UserName { get; set; } = null!;

    [StringLength(100)]
    public string Email { get; set; } = null!;

    [StringLength(200)]
    public string PasswordHash { get; set; } = null!;

    [StringLength(50)]
    public string? Phone { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    public bool? IsDeleted { get; set; }

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Asset3D> Asset3Ds { get; set; } = new List<Asset3D>();

    [ForeignKey("CompanyId")]
    [InverseProperty("Users")]
    public virtual Company? Company { get; set; }

    [InverseProperty("AssignedToNavigation")]
    public virtual ICollection<ProductionStage> ProductionStages { get; set; } = new List<ProductionStage>();

    [InverseProperty("User")]
    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    [ForeignKey("RoleId")]
    [InverseProperty("Users")]
    public virtual Role Role { get; set; } = null!;
}
