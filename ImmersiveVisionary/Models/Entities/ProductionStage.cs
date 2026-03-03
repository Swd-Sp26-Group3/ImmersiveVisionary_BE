using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models.Entities;

[Table("ProductionStage")]
public partial class ProductionStage
{
    [Key]
    public int StageId { get; set; }

    public int OrderId { get; set; }

    [StringLength(100)]
    public string? StageName { get; set; }

    public int StageOrder { get; set; }

    public int? AssignedTo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? StartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EndDate { get; set; }

    [StringLength(50)]
    public string? Status { get; set; }

    [ForeignKey("AssignedTo")]
    [InverseProperty("ProductionStages")]
    public virtual User? AssignedToNavigation { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("ProductionStages")]
    public virtual CreativeOrder Order { get; set; } = null!;
}
