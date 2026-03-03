using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class Asset3DDTO
    {
        public int AssetId { get; set; }
        public string AssetName { get; set; } = null!;
        public string? PreviewImage { get; set; }
        public string? AssetType { get; set; }
        public decimal? Price { get; set; }
        public bool? IsMarketplace { get; set; }
        public string? Category { get; set; }
        public string? Industry { get; set; }
        public string? PublishStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
 
}
