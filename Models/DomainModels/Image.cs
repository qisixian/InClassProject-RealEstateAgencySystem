using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateAgencySystem.Models
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }
        
        [Required]
        public int PropertyId { get; set; }
        
        [Required]
        public required byte[] ImageData { get; set; }

        public required string FileName { get; set; }
        
        public required string ContentType { get; set; }
        
        // Navigation property to link back to the Property
        [ForeignKey(nameof(PropertyId))]
        public Property? Property { get; set; }
    }
}