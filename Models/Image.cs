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
        
        // Navigation property to link back to the Property
        [ForeignKey("PropertyID")]
        public Property Property { get; set; }
        
        // Optional: Add additional properties like file name, content type, etc.
        public string FileName { get; set; }
        
        public string ContentType { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UploadDate { get; set; } = DateTime.Now;
    }
}