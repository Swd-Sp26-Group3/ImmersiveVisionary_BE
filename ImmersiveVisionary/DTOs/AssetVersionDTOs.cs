using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class AssetVersionDTO
    {
        public int VersionId { get; set; }
        public int AssetId { get; set; }
        public string? FileFormat { get; set; }
        public string? FileUrl { get; set; }
        public int? PolyCount { get; set; }
        public string? TextureSize { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

}
