using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models.Entities;

[Table("RefreshToken")]
public partial class RefreshToken
{
    [Key]
    public int RefreshTokenId { get; set; }

    public int UserId { get; set; }

    [StringLength(500)]
    public string Token { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime ExpiresAt { get; set; }

    public bool Revoked { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("RefreshTokens")]
    public virtual User User { get; set; } = null!;
}
