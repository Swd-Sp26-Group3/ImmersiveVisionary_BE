using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models.Entities;

[Table("AssetVersion")]
public partial class AssetVersion
{
    [Key]
    public int VersionId { get; set; }

    public int AssetId { get; set; }

    [StringLength(50)]
    public string? FileFormat { get; set; }

    [StringLength(500)]
    public string? FileUrl { get; set; }

    public int? PolyCount { get; set; }

    [StringLength(50)]
    public string? TextureSize { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [ForeignKey("AssetId")]
    [InverseProperty("AssetVersions")]
    public virtual Asset3D Asset { get; set; } = null!;
}
