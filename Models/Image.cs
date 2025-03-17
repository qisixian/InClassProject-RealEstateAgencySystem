using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateAgencySystem.Models
{
    public class Image
    {
        [Key]
        public int ImageID { get; set; }
        
        [Required]
        public int PropertyID { get; set; }
        
        [Required]
        public byte[] ImageData { get; set; }

        public string FileName { get; set; }
        
        public string ContentType { get; set; }

        // CreatTime & UpdateTime
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreateTime { get; set; } = DateTime.Now;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdateTime { get; set; } = DateTime.Now;
        
        // Navigation property to link back to the Property
        [ForeignKey(nameof(PropertyID))]
        public Property Property { get; set; }
    }
}