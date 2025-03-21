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
        
        // Navigation property to link back to the Property
        [ForeignKey(nameof(PropertyID))]
        public Property Property { get; set; }
    }
}