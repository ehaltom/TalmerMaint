using System.ComponentModel.DataAnnotations;

namespace TalmerMaint.Domain.Entities
{
    public class LocImage
    {
        public int Id { get; set; }
        public bool FeaturedImg { get; set; }
        public byte[] ImageData { get; set; }

        [MaxLength(50)]
        public string ImageMimeType { get; set; }
        public int LocationId { get; set; }
    }
}
